using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace ImageView
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
#if DEBUG == false
			string[] cmds = Environment.GetCommandLineArgs();
			if (cmds.Length < 2)
			{
				MessageBox.Show("Please, Give me an image filename.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			string filename = cmds[1];
#else
			string filename = @"test.jpg";

#endif
			if (File.Exists(filename) == false)
			{
				MessageBox.Show("not found image file.\n\n" + filename, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			Bitmap bmp = new Bitmap(filename);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(bmp, filename));
		}
	}
}
