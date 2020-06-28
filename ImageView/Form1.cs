using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Text;
using System.Windows.Forms;
//using System.IO;
//using System.Diagnostics;
//using System.Resources;

namespace ImageView
{
	public partial class Form1 : Form
	{
		private enum Grip { None, TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left, Angle, Move, Min, Max, Close, Translate };
		private const int GripWidth = 32;

		//------------------------------------------------------------------------------------
		#region メンバ
		//------------------------------------------------------------------------------------
		private readonly Bitmap _bmp_angle;
		private readonly Bitmap _bmp_min;
		private readonly Bitmap _bmp_max;
		private readonly Bitmap _bmp_close;
		private readonly Bitmap _bmp;
		private readonly string _fielname;
		private SolidBrush _sbRed;
		private SolidBrush _sbGreen;
		private SolidBrush _sbBlue;
		private SolidBrush _sbBlack;
		private Font _font;
		private bool _downShift;
		private bool _downCtrl;
		private Grip _gripDown;
		private Grip _gripNow;
		private Grip _gripOld;
		private Point _ptDown;
		private Point _ptGrip;
		private bool _optNoBorder;
		private bool _optShowGrip;
		private bool _optFitImage;
		private bool _optShowDebug;
		private double _centerX;
		private double _centerY;
		private double _zoom;
		private double _angle;
		#endregion

		//------------------------------------------------------------------------------------
		#region 最初の処理
		//------------------------------------------------------------------------------------
		public Form1(Bitmap bmp, string filename)
		{
            InitializeComponent();

			_bmp_angle = Properties.Resources.angle;
			_bmp_min = Properties.Resources.min;
			_bmp_max = Properties.Resources.max;
			_bmp_close = Properties.Resources.close;
			_bmp = bmp;
			_fielname = filename;

		}
        private void Form1_Load(object sender, EventArgs e)
		{
			Text = _fielname;

			_sbRed = new SolidBrush(Color.FromArgb(128, 255, 160, 160));
			_sbGreen = new SolidBrush(Color.FromArgb(128, 160, 255, 160));
			_sbBlue = new SolidBrush(Color.FromArgb(128, 160, 160, 255));
			_sbBlack = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
			_font = new Font(FontFamily.GenericMonospace, 12);

			_downShift = false;
			_downCtrl = false;
			_gripDown = Grip.None;
			_gripNow = Grip.None;
			_gripOld = Grip.None;
			_ptDown = new Point(0, 0);
			_ptGrip = new Point(0, 0);

			_optNoBorder = true;
			_optShowGrip = true;
			_optFitImage = true;
			_optShowDebug = false;
			CntMenuOptNoBorder.Checked = _optNoBorder;
			CntMenuOptShowGrip.Checked = _optShowGrip;
			CntMenuOptFitImage.Checked = _optFitImage;
			CntMenuOptShowDebug.Checked = _optShowDebug;
			CntMenuMirror.Checked = false;
			CntMenuFlip.Checked = false;

			ResizeBoundsToImage();
			ResetZoom();
			ResetAngle();
			ResetCenter();
		}
		#endregion

		//------------------------------------------------------------------------------------
		#region 描画関係
		//------------------------------------------------------------------------------------
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.InterpolationMode = _zoom < 1.0 ? InterpolationMode.High : InterpolationMode.Low;
			e.Graphics.CompositingMode = CompositingMode.SourceOver;
			e.Graphics.CompositingQuality = CompositingQuality.GammaCorrected;
			e.Graphics.SmoothingMode = SmoothingMode.None;
			e.Graphics.PixelOffsetMode = PixelOffsetMode.None;

			e.Graphics.TranslateTransform((float)_centerX, (float)_centerY);
			e.Graphics.RotateTransform((float)_angle);
			e.Graphics.ScaleTransform((float)_zoom, (float)_zoom);
			e.Graphics.DrawImage(_bmp, -_bmp.Width / 2f, -_bmp.Height / 2f, (float)_bmp.Width, (float)_bmp.Height);
			e.Graphics.ResetTransform();

			if (_optShowGrip)
			{
				switch (_gripNow)
				{
					case Grip.TopLeft:
						e.Graphics.FillRectangle(_sbBlue, 0, 0, GripWidth, GripWidth);
						break;
					case Grip.Top:
						e.Graphics.FillRectangle(_sbBlue, GripWidth, 0, ClientSize.Width - GripWidth * 2, GripWidth);
						break;
					case Grip.TopRight:
						e.Graphics.FillRectangle(_sbBlue, ClientSize.Width - GripWidth, 0, GripWidth, GripWidth);
						break;
					case Grip.Right:
						e.Graphics.FillRectangle(_sbBlue, ClientSize.Width - GripWidth, GripWidth, GripWidth, ClientSize.Height - GripWidth * 2);
						break;
					case Grip.BottomRight:
						e.Graphics.FillRectangle(_sbBlue, ClientSize.Width - GripWidth, ClientSize.Height - GripWidth, GripWidth, GripWidth);
						break;
					case Grip.Bottom:
						e.Graphics.FillRectangle(_sbBlue, GripWidth, ClientSize.Height - GripWidth, ClientSize.Width - GripWidth * 2, GripWidth);
						break;
					case Grip.BottomLeft:
						e.Graphics.FillRectangle(_sbBlue, 0, ClientSize.Height - GripWidth, GripWidth, GripWidth);
						break;
					case Grip.Left:
						e.Graphics.FillRectangle(_sbBlue, 0, GripWidth, GripWidth, ClientSize.Height - GripWidth * 2);
						break;
					default:
						break;
				}
			}
			switch (_gripNow)
			{
				case Grip.Angle:
					e.Graphics.FillRectangle(_sbGreen, GripWidth, GripWidth, GripWidth, GripWidth);
					e.Graphics.DrawImage(_bmp_angle, GripWidth, GripWidth, _bmp_angle.Width, _bmp_angle.Height);
					break;
				case Grip.Move:
					e.Graphics.FillRectangle(_sbGreen, GripWidth * 2, GripWidth, ClientSize.Width - GripWidth * 6, GripWidth);
					break;
				case Grip.Min:
					e.Graphics.FillRectangle(_sbGreen, ClientSize.Width - GripWidth * 4, GripWidth, GripWidth, GripWidth);
					e.Graphics.DrawImage(_bmp_min, ClientSize.Width - GripWidth * 4, GripWidth, _bmp_min.Width, _bmp_min.Height);
					break;
				case Grip.Max:
					e.Graphics.FillRectangle(_sbGreen, ClientSize.Width - GripWidth * 3, GripWidth, GripWidth, GripWidth);
					e.Graphics.DrawImage(_bmp_max, ClientSize.Width - GripWidth * 3, GripWidth, _bmp_max.Width, _bmp_max.Height);
					break;
				case Grip.Close:
					e.Graphics.FillRectangle(_sbRed, ClientSize.Width - GripWidth * 2, GripWidth, GripWidth, GripWidth);
					e.Graphics.DrawImage(_bmp_close, ClientSize.Width - GripWidth * 2, GripWidth, _bmp_close.Width, _bmp_close.Height);
					break;
				default:
					break;
			}
			if (_optShowDebug)
			{
				e.Graphics.DrawRectangle(Pens.Red, (int)_centerX - 2, (int)_centerY - 2, 5, 5);
				DrawString(e.Graphics, 0, 0, Application.ProductName + " Version " + Application.ProductVersion);
				DrawString(e.Graphics, 0, 1, "_fielname: " + _fielname);
				DrawString(e.Graphics, 0, 2, "_bmp.Width: " + _bmp.Width.ToString());
				DrawString(e.Graphics, 0, 3, "_bmp.Height: " + _bmp.Height.ToString());
				DrawString(e.Graphics, 0, 4, "_bmp.PixelFormat: " + _bmp.PixelFormat.ToString());
				DrawString(e.Graphics, 0, 5, "_bmp.RawFormat: " + GetRawFormatString(_bmp.RawFormat));
				DrawString(e.Graphics, 0, 6, "_centerX: " + _centerX.ToString("000.0"));
				DrawString(e.Graphics, 0, 7, "_centerY: " + _centerY.ToString("000.0"));
				DrawString(e.Graphics, 0, 8, "_angle: " + _angle.ToString("0.000"));
				DrawString(e.Graphics, 0, 9, "_zoom: " + _zoom.ToString("0.000"));
				DrawString(e.Graphics, 0, 10, "_gripDown: " + _gripDown.ToString());
				DrawString(e.Graphics, 0, 11, "_gripNow: " + _gripNow.ToString());
				DrawString(e.Graphics, 0, 12, "_gripOld: " + _gripOld.ToString());
				DrawString(e.Graphics, 0, 13, "_ptDown: " + _ptDown.ToString());
				DrawString(e.Graphics, 0, 14, "_ptGrip: " + _ptGrip.ToString());
				DrawString(e.Graphics, 0, 15, "_downShift: " + _downShift.ToString());
				DrawString(e.Graphics, 0, 16, "_downCtrl: " + _downCtrl.ToString());
				DrawString(e.Graphics, 0, 17, "_optFitImage: " + _optFitImage.ToString());
				DrawString(e.Graphics, 0, 18, "_optNoBorder: " + _optNoBorder.ToString());
				DrawString(e.Graphics, 0, 19, "_optShowGrip: " + _optShowGrip.ToString());
				DrawString(e.Graphics, 0, 20, "_optShowDebug: " + _optShowDebug.ToString());
			}
		}
		private void DrawString(Graphics g, int x, int y, string str)
		{
			SizeF ss = g.MeasureString(str, _font);
			float fx = x * ss.Width / str.Length;
			float fy = y * ss.Height;
			g.FillRectangle(_sbBlack, fx, fy, ss.Width, ss.Height);
			g.DrawString(str, _font, Brushes.White, fx, fy);
		}
		private void RefreshDebug()
		{
			if (_optShowDebug)
			{
				Refresh();
			}
		}
		#endregion

		//------------------------------------------------------------------------------------
		#region リサイズ関係
		//------------------------------------------------------------------------------------
		private void Form1_Resize(object sender, EventArgs e)
		{
			if (_optFitImage)
			{
				FitImage();
			}
			Refresh();
		}
		private void ResizeBoundsToImage()
		{
			Rectangle area = Screen.GetWorkingArea(this);
			double magw = (double)area.Width / _bmp.Width;
			double magh = (double)area.Height / _bmp.Height;
			Size ws = new Size();
			Point wp = new Point();
			if (magw >= 1.0 && magh >= 1.0)
			{
				wp.X = Location.X;
				wp.Y = Location.Y;
				ws.Width = _bmp.Width;
				ws.Height = _bmp.Height;
			}
			else
			{
				if (magw < magh)
				{
					ws.Width = area.Width;
					ws.Height = (int)(magw * _bmp.Height);
					wp.X = 0;
					if (Location.Y + ws.Height > area.Height)
					{
						wp.Y = area.Height - ws.Height;
					}
					else
					{
						wp.Y = Location.Y;
					}
				}
				else
				{
					ws.Width = (int)(magh * _bmp.Width);
					ws.Height = area.Height;
					wp.Y = 0;
					if (Location.X + ws.Width > area.Width)
					{
						wp.X = area.Width - ws.Width;
					}
					else
					{
						wp.X = Location.X;
					}
				}
			}
			Location = wp;
			Size = SizeFromClientSize(ws);
		}
		private void ResizeBounds(int x, int y, int width, int height, bool flgTop, bool flgLeft)
		{
			const int n = 7;
			int rx = Bounds.X + x;
			int ry = Bounds.Y + y;
			int rw = Bounds.Width + width;
			int rh = Bounds.Height + height;

			if (rw <= GripWidth * n)
			{
				if (flgLeft)
				{
					rx = Bounds.Right - GripWidth * n;
				}
				else
				{
					rx = Bounds.X;
				}
				rw = GripWidth * n;
			}
			if (rh <= GripWidth * n)
			{
				if (flgTop)
				{
					ry = Bounds.Bottom - GripWidth * n;
				}
				else
				{
					ry = Bounds.Y;
				}
				rh = GripWidth * n;
			}
			SetBounds(rx, ry, rw, rh);
		}
		private void ToNoBorder()
		{
			FormBorderStyle = FormBorderStyle.None;
		}
		private void ToBorder()
		{
			FormBorderStyle = FormBorderStyle.Sizable;
		}
		#endregion

		//------------------------------------------------------------------------------------
		#region マウスキーボード関係
		//------------------------------------------------------------------------------------
		private Grip GetGripType(int x, int y)
		{
			if (x < 0) return Grip.None;
			if (y < 0) return Grip.None;
			if (x >= ClientSize.Width) return Grip.None;
			if (y >= ClientSize.Height) return Grip.None;

			bool fT = y < GripWidth;
			bool fB = (ClientSize.Height - y) < GripWidth;
			bool fL = x < GripWidth;
			bool fR = (ClientSize.Width - x) < GripWidth;
			bool fC = y < GripWidth * 2;
			bool fTA = x < GripWidth * 2;
			bool fTN = (ClientSize.Width - GripWidth * 4) < x;
			bool fTX = (ClientSize.Width - GripWidth * 3) < x;
			bool fTC = (ClientSize.Width - GripWidth * 2) < x;

			if (fT && fL) return Grip.TopLeft;
			if (fT && !fL && !fR) return Grip.Top;
			if (fT && fR) return Grip.TopRight;
			if (fR && !fT && !fB) return Grip.Right;
			if (fB && fL) return Grip.BottomLeft;
			if (fB && !fL && !fR) return Grip.Bottom;
			if (fB && fR) return Grip.BottomRight;
			if (fL && !fT && !fB) return Grip.Left;
			if (fC && fTA) return Grip.Angle;
			if (fC && fTC) return Grip.Close;
			if (fC && fTX) return Grip.Max;
			if (fC && fTN) return Grip.Min;
			if (fC) return Grip.Move;

			return Grip.Translate;
		}
		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_ptDown.X = e.X;
				_ptDown.Y = e.Y;
				_ptGrip.X = e.X;
				_ptGrip.Y = e.Y;
				_gripDown = GetGripType(e.X, e.Y);
				RefreshDebug();
			}
			if (e.Button == MouseButtons.Right)
			{
				_ptDown.X = e.X;
				_ptDown.Y = e.Y;
				SetMenuInfo();
				RefreshDebug();
			}
		}
		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			_gripDown = Grip.None;
			RefreshDebug();
		}
		private void Form1_MouseLeave(object sender, EventArgs e)
		{
			_gripNow = Grip.None;
			_gripOld = _gripNow;
			Refresh();
		}
		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (_ptDown.X == e.X && _ptDown.Y == e.Y) return;

			if (_gripDown == Grip.None)
			{
				_gripNow = GetGripType(e.X, e.Y);
			}

			switch (_gripNow)
			{
				case Grip.TopLeft:
					Cursor = Cursors.SizeNWSE;
					break;
				case Grip.Top:
					Cursor = Cursors.SizeNS;
					break;
				case Grip.TopRight:
					Cursor = Cursors.SizeNESW;
					break;
				case Grip.Right:
					Cursor = Cursors.SizeWE;
					break;
				case Grip.BottomRight:
					Cursor = Cursors.SizeNWSE;
					break;
				case Grip.Bottom:
					Cursor = Cursors.SizeNS;
					break;
				case Grip.BottomLeft:
					Cursor = Cursors.SizeNESW;
					break;
				case Grip.Left:
					Cursor = Cursors.SizeWE;
					break;
				case Grip.Angle:
					Cursor = Cursors.Cross;
					break;
				case Grip.Move:
					Cursor = Cursors.SizeAll;
					break;
				case Grip.Close:
					Cursor = Cursors.Default;
					break;
				default:
					Cursor = Cursors.Default;
					break;
			}
			if (_gripDown == Grip.None && _gripOld != _gripNow)
			{
				Refresh();
				_gripOld = _gripNow;
				return;
			}
			_gripOld = _gripNow;

			int dx = e.X - _ptGrip.X;
			int dy = e.Y - _ptGrip.Y;
			switch (_gripDown)
			{
				case Grip.TopLeft:
					ResizeBounds(dx, dy, -dx, -dy, true, true);
					break;
				case Grip.Top:
					ResizeBounds(0, dy, 0, -dy, true, false);
					break;
				case Grip.TopRight:
					ResizeBounds(0, dy, dx, -dy, true, false);
					_ptGrip.X = e.X;
					break;
				case Grip.Right:
					ResizeBounds(0, 0, dx, 0, false, false);
					_ptGrip.X = e.X;
					break;
				case Grip.BottomRight:
					ResizeBounds(0, 0, dx, dy, false, false);
					_ptGrip.X = e.X;
					_ptGrip.Y = e.Y;
					break;
				case Grip.Bottom:
					ResizeBounds(0, 0, 0, dy, false, false);
					_ptGrip.Y = e.Y;
					break;
				case Grip.BottomLeft:
					ResizeBounds(dx, 0, -dx, dy, false, true);
					_ptGrip.Y = e.Y;
					break;
				case Grip.Left:
					ResizeBounds(dx, 0, -dx, 0, false, true);
					break;
				case Grip.Angle:
					_angle += (e.Y - _ptDown.Y) * 2.0 / ClientSize.Height * 360.0;
					while (_angle > 360.0) _angle -= 360.0;
					while (_angle < 0.0) _angle += 360.0;
					Refresh();
					_ptDown.Y = e.Y;
					break;
				case Grip.Move:
					Location = new Point(Location.X + (e.X - _ptDown.X), Location.Y + (e.Y - _ptDown.Y));
					break;
				case Grip.Translate:
					_centerX += (e.X - _ptDown.X);
					_centerY += (e.Y - _ptDown.Y);
					_ptDown.X = e.X;
					_ptDown.Y = e.Y;
					Refresh();
					break;
				default:
					break;
			}
			RefreshDebug();
		}
		private void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.X < 0) return;
			if (e.Y < 0) return;
			if (e.X >= ClientSize.Width) return;
			if (e.Y >= ClientSize.Height) return;
			if (e.Delta == 0) return;

			double step = 0.1;
			if (_downShift && !_downCtrl) step = 0.02;
			if (!_downShift && _downCtrl) step = 0.2;

			const double min_pix = 100.0;
			const double max_mag = 10.0;
			double zm = _zoom;
			if (e.Delta > 0) zm *= (1.0 + step);
			if (e.Delta < 0) zm /= (1.0 + step);
			if ((_bmp.Width + _bmp.Height) * zm < min_pix) zm = min_pix / (double)(_bmp.Width + _bmp.Height);
			if (zm > max_mag) zm = max_mag;

			if (!(_zoom > zm || _zoom < zm))
				return;

			// マウスポインタ部分を変化の中心にするようにcenterを移動する
			_centerX -= (e.X - _centerX) * (zm / _zoom - 1.0);
			_centerY -= (e.Y - _centerY) * (zm / _zoom - 1.0);

			_zoom = zm;
			Refresh();
		}
		private void Form1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			switch (_gripNow)
			{
				case Grip.Min:
					WindowState = WindowState == FormWindowState.Minimized ? FormWindowState.Normal : FormWindowState.Minimized;
					break;
				case Grip.Max:
					WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
					break;
				case Grip.Close:
					Application.Exit();
					break;
				default:
					break;
			}
		}
		private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Left) return;
			switch (_gripNow)
			{
				case Grip.TopLeft:
				case Grip.Top:
				case Grip.TopRight:
				case Grip.Right:
				case Grip.BottomRight:
				case Grip.Bottom:
				case Grip.BottomLeft:
				case Grip.Left:
				case Grip.Move:
					ResetCenter();
					break;
				case Grip.Angle:
					ResetAngle();
					break;
				case Grip.Translate:
					ResetAngle();
					ResetCenter();
					ResetZoom();
					break;
				default:
					break;
			}
			Refresh();
		}
		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			_downShift = e.Shift;
			_downCtrl = e.Control;
			RefreshDebug();
		}
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			_downShift = e.Shift;
			_downCtrl = e.Control;

			switch (e.KeyCode)
			{
				default:
					break;

				case Keys.Escape:
					Application.Exit();
					break;

				case Keys.Enter:
					if (FormBorderStyle == FormBorderStyle.Sizable)
					{
						ToNoBorder();
					}
					else
					{
						ToBorder();
					}
					break;

				case Keys.Up:
					Location = new Point(Location.X, Location.Y - 1);
					break;
				case Keys.Down:
					Location = new Point(Location.X, Location.Y + 1);
					break;
				case Keys.Left:
					Location = new Point(Location.X - 1, Location.Y);
					break;
				case Keys.Right:
					Location = new Point(Location.X + 1, Location.Y);
					break;
			}
			RefreshDebug();
		}
		#endregion

		//------------------------------------------------------------------------------------
		#region リセット関係
		//------------------------------------------------------------------------------------
		private void FitImage()
		{
			double magw = (double)ClientSize.Width / _bmp.Width;
			double magh = (double)ClientSize.Height / _bmp.Height;
			if (magw < magh)
			{
				_zoom = magw;
			}
			else
			{
				_zoom = magh;
			}
			ResetCenter();
		}
		private void ResetZoom()
		{
			if (!_optFitImage)
			{
				_zoom = 1.0;
			}
			else
			{
				FitImage();
			}
		}
		private void ResetCenter()
		{
			_centerX = ClientSize.Width / 2.0;
			_centerY = ClientSize.Height / 2.0;
		}
		private void ResetAngle()
		{
			_angle = 0.0;
		}
		#endregion

		//------------------------------------------------------------------------------------
		#region コンテキストメニュー関係
		//------------------------------------------------------------------------------------
		private void SetMenuInfo()
		{
			CntMenuAngle.Text = "Angle (" + _angle.ToString("F0") + " d)";
			CntMenuZoom.Text = "Zoom (" + (_zoom * 100.0).ToString("F0") + "%)";
		}
		private string GetRawFormatString(System.Drawing.Imaging.ImageFormat fmt)
		{
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Bmp)) return System.Drawing.Imaging.ImageFormat.Bmp.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Emf)) return System.Drawing.Imaging.ImageFormat.Emf.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Exif)) return System.Drawing.Imaging.ImageFormat.Exif.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Gif)) return System.Drawing.Imaging.ImageFormat.Gif.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Icon)) return System.Drawing.Imaging.ImageFormat.Icon.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Jpeg)) return System.Drawing.Imaging.ImageFormat.Jpeg.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp)) return System.Drawing.Imaging.ImageFormat.MemoryBmp.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Png)) return System.Drawing.Imaging.ImageFormat.Png.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Tiff)) return System.Drawing.Imaging.ImageFormat.Tiff.ToString();
			if (fmt.Equals(System.Drawing.Imaging.ImageFormat.Wmf)) return System.Drawing.Imaging.ImageFormat.Wmf.ToString();
			return fmt.ToString();
		}
		private void CntMenuClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void CntMenuReset_Click(object sender, EventArgs e)
		{
			ResizeBoundsToImage();
			ResetZoom();
			ResetAngle();
			ResetCenter();
			Refresh();
		}
		private void CntMenuZoomPer_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			if (item.Equals(CntMenuZoom025p)) _zoom = 0.25;
			if (item.Equals(CntMenuZoom050p)) _zoom = 0.5;
			if (item.Equals(CntMenuZoom075p)) _zoom = 0.75;
			if (item.Equals(CntMenuZoom100p)) _zoom = 1.0;
			if (item.Equals(CntMenuZoom150p)) _zoom = 1.5;
			if (item.Equals(CntMenuZoom200p)) _zoom = 2.0;
			if (item.Equals(CntMenuZoom400p)) _zoom = 4.0;
			if (item.Equals(CntMenuZoom600p)) _zoom = 6.0;
			if (item.Equals(CntMenuZoom800p)) _zoom = 8.0;
			Refresh();
		}
		private void CntMenuAngle_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;
			if (item.Equals(CntMenuAngle0d)) _angle = 0.0;
			if (item.Equals(CntMenuAngle90d)) _angle = 90.0;
			if (item.Equals(CntMenuAngle180d)) _angle = 180.0;
			if (item.Equals(CntMenuAngle270d)) _angle = 270.0;
			Refresh();
		}
		private void CntMenuMirror_Click(object sender, EventArgs e)
		{
			_bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
			Refresh();
		}
		private void CntMenuFlip_Click(object sender, EventArgs e)
		{
			_bmp.RotateFlip(RotateFlipType.RotateNoneFlipY);
			Refresh();
		}
		private void CntMenuOptNoBorder_Click(object sender, EventArgs e)
		{
			_optNoBorder = !_optNoBorder;
			CntMenuOptNoBorder.Checked = _optNoBorder;
			if (_optNoBorder)
			{
				ToNoBorder();
			}
			else
			{
				ToBorder();
			}
			RefreshDebug();
		}
		private void CntMenuOptShowGrip_Click(object sender, EventArgs e)
		{
			_optShowGrip = !_optShowGrip;
			CntMenuOptShowGrip.Checked = _optShowGrip;
			RefreshDebug();
		}
		private void CntMenuOptFitImage_Click(object sender, EventArgs e)
		{
			_optFitImage = !_optFitImage;
			CntMenuOptFitImage.Checked = _optFitImage;
			RefreshDebug();
		}
		private void CntMenuOptShowDebug_Click(object sender, EventArgs e)
		{
			_optShowDebug = !_optShowDebug;
			CntMenuOptShowDebug.Checked = _optShowDebug;
			Refresh();
		}
		#endregion
	}
}
