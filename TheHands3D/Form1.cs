using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheHands3D
{
	public partial class mainForm : Form
	{
		public mainForm()
		{
			InitializeComponent();
		}

		private void drawBoard_OpenGLInitialized(object sender, EventArgs e)
		{
			//Sự kiện "khởi tạo", xảy ra khi chương trình vừa được khởi chạy

			//Lấy đối tượng OpenGL
			OpenGL gl = drawBoard.OpenGL;

			//Set màu nền (đen)
			gl.ClearColor(0, 0, 0, 1);

			//Xóa toàn bộ drawBoard
			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
		}

		private void drawBoard_Resized(object sender, EventArgs e)
		{
			//Sự kiện "thay đổi kích thước cửa sổ"

			//Lấy đối tượng OpenGL
			OpenGL gl = drawBoard.OpenGL;

			//Set viewport theo kích thước cửa sổ
			gl.Viewport(0, 0, drawBoard.Width, drawBoard.Height);

			//Set ma trận chiếu
			gl.MatrixMode(OpenGL.GL_PROJECTION);
			gl.LoadIdentity();
			gl.Perspective(60.0, (double)(drawBoard.Width) / drawBoard.Height, 1.0, 100.0);

			//Set ma trận model view
			gl.MatrixMode(OpenGL.GL_MODELVIEW);
			gl.LoadIdentity();
			gl.LookAt
			(
				5, 5, 5,
				0, 0, 0,
				0, 1, 0
			);
		}

		private void drawBoard_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
		{
			//Sự kiện "vẽ", xảy ra liên tục và lặp vô hạn lần

			//Lấy đối tượng OpenGL
			OpenGL gl = drawBoard.OpenGL;

			//Vẽ 3 trục tọa độ
			gl.Begin(OpenGL.GL_LINES);
				//Trục Ox
				gl.Color(1.0f, 0.0f, 0.0f, 1.0f);
				gl.Vertex(0.0f, 0.0f, 0.0f);
				gl.Vertex(10.0f, 0.0f, 0.0f);
				//Trục Oy
				gl.Color(0.0f, 1.0f, 0.0f, 1.0f);
				gl.Vertex(0.0f, 0.0f, 0.0f);
				gl.Vertex(0.0f, 10.0f, 0.0f);
				//Trục Oz
				gl.Color(0.0f, 0.0f, 1.0f, 1.0f);
				gl.Vertex(0.0f, 0.0f, 0.0f);
				gl.Vertex(0.0f, 0.0f, 10.0f);
			gl.End();

			gl.Flush();
		}
	}
}