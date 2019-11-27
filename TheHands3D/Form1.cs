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
		Camera camera = new Camera();

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
				camera.camX, camera.camY, camera.camZ,
				camera.cenX, camera.cenY, camera.cenZ,
				camera.upX, camera.upY, camera.upZ
			);
		}

		private void drawBoard_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
		{
			//Sự kiện "vẽ", xảy ra liên tục và lặp vô hạn lần

			//Lấy đối tượng OpenGL
			OpenGL gl = drawBoard.OpenGL;

			//Xóa toàn bộ drawBoard
			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

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

		private void drawBoard_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Z)
			{
				camera.ZoomIn();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.X)
			{
				camera.ZoomOut();
				drawBoard_Resized(sender, e);
			}
		}
	}

	public class Camera
	{
		//Tọa độ đặt camera
		public double camX, camY, camZ;
		//Tọa độ nhìn
		public double cenX, cenY, cenZ;
		//Vector up
		public double upX, upY, upZ;

		//Tọa độ cầu của camera
		double radius;
		double alpha, theta;

		public Camera()
		{
			radius = 10.0;
			alpha = 45.0;
			theta = 30.0;

			ReCalc();
			cenX = cenY = cenZ = 0.0;
			upX = upY = 0.0;
			upZ = 1.0;
		}

		void ReCalc()
		{
			//Hàm tính lại tọa độ camera sau khi di chuyển
			camX = radius * Math.Cos(alpha * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
			camY = radius * Math.Sin(alpha * Math.PI / 180.0) * Math.Cos(theta * Math.PI / 180.0);
			camZ = radius * Math.Sin(theta * Math.PI / 180.0);

			if (90 < theta && theta <= 270)
				upZ = -1.0;
			else
				upZ = 1.0;
		}

		public void ZoomIn()
		{
			//Hàm phóng to (di chuyển camera lại gần điểm nhìn)
			radius -= 0.2;
			ReCalc();
		}

		public void ZoomOut()
		{
			//Hàm thu nhỏ (di chuyển camera ra xa điểm nhìn)
			radius += 0.2;
			ReCalc();
		}
	}
}