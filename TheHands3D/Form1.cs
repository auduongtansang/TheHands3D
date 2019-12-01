using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TheHands3D
{
	public partial class mainForm : Form
	{
		Camera camera = new Camera();
		Cube cube = new Cube();

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
			gl.LineWidth(3.0f);
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
			gl.LineWidth(1.0f);

			//Vẽ khối lập phương
			cube.Draw(gl);

			gl.Flush();
		}

		private void drawBoard_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Z)
			{
				//Phím Z, di chuyển camera lại gần điểm nhìn
				camera.ZoomIn();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.X)
			{
				//Phím X, di chuyển camera ra xa điểm nhìn
				camera.ZoomOut();
				drawBoard_Resized(sender, e);
			}
		}

		private void drawBoard_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				//Phím mũi tên trái, xoay camera sang trái (quanh điểm nhìn)
				camera.RotateLeft();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.Right)
			{
				//Phím mũi tên phải, xoay camera sang phải (quanh điểm nhìn)
				camera.RotateRight();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.Up)
			{
				//Phím mũi tên lên, xoay camera lên trên (quanh điểm nhìn)
				camera.RotateUp();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.Down)
			{
				//Phím mũi tên xuống, xoay camera xuống dưới (quanh điểm nhìn)
				camera.RotateDown();
				drawBoard_Resized(sender, e);
			}
		}
	}

	public class Cube
	{
		//Lớp "khối lập phương"

		//Màu hình vẽ
		public Color color;

		//Tập đỉnh
		public List<Tuple<double, double, double>> vertex;

		//Tập thứ tự các đỉnh vẽ
		public List<int> index;

		public Cube()
		{
			color = Color.White;

			//8 đỉnh
			vertex = new List<Tuple<double, double, double>>();
			vertex.Add(new Tuple<double, double, double>(0, 0, 0));
			vertex.Add(new Tuple<double, double, double>(0, 2, 0));
			vertex.Add(new Tuple<double, double, double>(2, 2, 0));
			vertex.Add(new Tuple<double, double, double>(2, 0, 0));
			vertex.Add(new Tuple<double, double, double>(0, 0, 2));
			vertex.Add(new Tuple<double, double, double>(0, 2, 2));
			vertex.Add(new Tuple<double, double, double>(2, 2, 2));
			vertex.Add(new Tuple<double, double, double>(2, 0, 2));

			//Thứ tự vẽ
			index = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 5, 4, 2, 3, 7, 6, 1, 2, 6, 5, 0, 3, 7, 4 };
		}

		public void Draw(OpenGL gl)
		{
			//Vẽ khối lập phương
			gl.Color(color.R, color.G, color.B, (byte)(50));

			gl.Begin(OpenGL.GL_QUADS);

			for (int i = 0; i < index.Count; i++)
				gl.Vertex(vertex[index[i]].Item1, vertex[index[i]].Item2, vertex[index[i]].Item3);

			gl.End();
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

		public void RotateLeft()
		{
			//Hàm xoay camera sang trái (quanh điểm nhìn)
			alpha -= 1.0;
			if (alpha < 0)
				alpha += 360;
			else if (alpha > 360)
				alpha -= 360;
			ReCalc();
		}

		public void RotateRight()
		{
			//Hàm xoay camera sang phải (quanh điểm nhìn)
			alpha += 1.0;
			if (alpha < 0)
				alpha += 360;
			else if (alpha > 360)
				alpha -= 360;
			ReCalc();
		}

		public void RotateUp()
		{
			//Hàm xoay camera lên trên (quanh điểm nhìn)
			theta += 1.0;
			if (theta < 0)
				theta += 360;
			else if (theta > 360)
				theta -= 360;
			ReCalc();
		}

		public void RotateDown()
		{
			//Hàm xoay camera xuống dưới (quanh điểm nhìn)
			theta -= 1.0;
			if (theta < 0)
				theta += 360;
			else if (theta > 360)
				theta -= 360;
			ReCalc();
		}
	}
}