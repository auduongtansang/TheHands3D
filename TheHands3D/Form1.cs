using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Data;

using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Lighting;
using SharpGL.SceneGraph.Cameras;
using SharpGL.SceneGraph.Collections;
using SharpGL.SceneGraph.Core;
using SharpGL.SceneGraph.Effects;
using SharpGL.SceneGraph.Primitives;

namespace TheHands3D
{
    public partial class mainForm : Form
	{
		Camera camera = new Camera();
		Shape cube = new Shape(Shape.ShapeType.CUBE, Color.White);
		Shape pyramid = new Shape(Shape.ShapeType.PYRAMID, Color.Red);
		Shape prismatic = new Shape(Shape.ShapeType.PRISMATIC, Color.Aqua);

        //  The texture identifier.
        Texture texture = new Texture();

        Color userColor = Color.White;
		Shape.ShapeType choosingShape = Shape.ShapeType.NONE;

        bool EnableTextureCube = false;
        bool EnableTexturePyramid = false;

        
        public mainForm()
		{
			InitializeComponent();

            Light light = new Light()
            {
                On = true,
                Position = new Vertex(3, 10, 3),
                GLCode = OpenGL.GL_LIGHT0
            };

            sceneControl1.Scene.SceneContainer.AddChild(new Grid());
            sceneControl1.Scene.SceneContainer.AddChild(new Axies());
            sceneControl1.Scene.SceneContainer.AddChild(light);

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

			//Vẽ các khối
            if(EnableTextureCube == true)
            {
                //  Bind the texture.
                texture.Bind(gl);

                gl.Begin(OpenGL.GL_QUADS);

                // Top Face
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 2.0f); // Bottom Left Of The Texture and Quad
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(2.0f, 0.0f, 2.0f);  // Bottom Right Of The Texture and Quad
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 2.0f);   // Top Right Of The Texture and Quad
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, 2.0f, 2.0f);  // Top Left Of The Texture and Quad

                // Bottom Face
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 0.0f);    // Bottom Right Of The Texture and Quad
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.0f, 2.0f, 0.0f); // Top Right Of The Texture and Quad
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 0.0f);  // Top Left Of The Texture and Quad
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(2.0f, 0.0f, 0.0f); // Bottom Left Of The Texture and Quad

                // Front Face
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, 2.0f, 0.0f); // Top Left Of The Texture and Quad
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 2.0f, 2.0f);  // Bottom Left Of The Texture and Quad
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(2.0f, 2.0f, 2.0f);   // Bottom Right Of The Texture and Quad
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 0.0f);  // Top Right Of The Texture and Quad
      
                // Back Face
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.0f, 0.0f, 0.0f);    // Top Right Of The Texture and Quad
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(2.0f, 0.0f, 0.0f); // Top Left Of The Texture and Quad
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(2.0f, 0.0f, 2.0f);  // Bottom Left Of The Texture and Quad
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 2.0f); // Bottom Right Of The Texture and Quad

                // Right face
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(2.0f, 0.0f, 0.0f); // Bottom Right Of The Texture and Quad
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 0.0f);  // Top Right Of The Texture and Quad
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 2.0f);   // Top Left Of The Texture and Quad
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(2.0f, 0.0f, 2.0f);  // Bottom Left Of The Texture and Quad

                // Left Face
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 0.0f);    // Bottom Left Of The Texture and Quad
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.0f, 0.0f, 2.0f); // Bottom Right Of The Texture and Quad
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.0f, 2.0f, 2.0f);  // Top Right Of The Texture and Quad
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, 2.0f, 0.0f); // Top Left Of The Texture and Quad


                gl.End();

            }
            else
                cube.Draw(gl);

            if(EnableTexturePyramid == true)
            {
                texture.Bind(gl);

                gl.Begin(OpenGL.GL_QUADS);

                // Front Face
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(2.0f, 2.0f, 0.0f);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(2.0f, 4.0f, 0.0f);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(1.0f, 3.0f, 2.0f);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 0.0f);
                //Right face
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.0f, 4.0f, 0.0f);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(2.0f, 4.0f, 0.0f);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(1.0f, 3.0f, 2.0f);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, 4.0f, 0.0f);

                //Back Face
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, 2.0f, 0.0f);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(0.0f, 4.0f, 0.0f);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(1.0f, 3.0f, 2.0f);
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 2.0f, 0.0f);

                // Left face
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 2.0f, 0.0f);
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(2.0f, 2.0f, 0.0f);
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(1.0f, 3.0f, 2.0f);
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(0.0f, 2.0f, 0.0f);


                // Bottom face
                gl.TexCoord(0.0f, 1.0f); gl.Vertex(0.0f, 4.0f, 0.0f);    // Bottom Right Of The Texture and Quad
                gl.TexCoord(0.0f, 0.0f); gl.Vertex(0.0f, 2.0f, 0.0f); // Top Right Of The Texture and Quad
                gl.TexCoord(1.0f, 0.0f); gl.Vertex(2.0f, 2.0f, 0.0f);  // Top Left Of The Texture and Quad
                gl.TexCoord(1.0f, 1.0f); gl.Vertex(2.0f, 4.0f, 0.0f); // Bottom Left Of The Texture and Quad
                


                gl.End();

            }
            else
    			pyramid.Draw(gl);

			prismatic.Draw(gl);

			//Tô đậm cạnh của khối đang được chọn
			if (choosingShape == Shape.ShapeType.CUBE)
				cube.DrawEdge(gl);
			else if (choosingShape == Shape.ShapeType.PYRAMID)
				pyramid.DrawEdge(gl);
			else if (choosingShape == Shape.ShapeType.PRISMATIC)
				prismatic.DrawEdge(gl);

           
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
			else if (e.KeyCode == Keys.A)
			{
				//Phím A, xoay camera sang trái (quanh điểm nhìn)
				camera.RotateLeft();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.D)
			{
				//Phím D, xoay camera sang phải (quanh điểm nhìn)
				camera.RotateRight();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.W)
			{
				//Phím W, xoay camera lên trên (quanh điểm nhìn)
				camera.RotateUp();
				drawBoard_Resized(sender, e);
			}
			else if (e.KeyCode == Keys.S)
			{
				//Phím S, xoay camera xuống dưới (quanh điểm nhìn)
				camera.RotateDown();
				drawBoard_Resized(sender, e);
			}
		}

		private void cbShape_SelectionChangeCommitted(object sender, EventArgs e)
		{
			//Sự kiện "chọn hình khối"
			if (cbShape.SelectedIndex == 0)
				choosingShape = Shape.ShapeType.CUBE;
			else if (cbShape.SelectedIndex == 1)
				choosingShape = Shape.ShapeType.PYRAMID;
			else if (cbShape.SelectedIndex == 2)
				choosingShape = Shape.ShapeType.PRISMATIC;
		}

		private void btnColor_Click(object sender, EventArgs e)
		{
			//Sự kiện "đổi màu của khối đang được chọn"
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				userColor = colorDialog.Color;
				if (choosingShape == Shape.ShapeType.CUBE)
					cube.color = userColor;
				else if (choosingShape == Shape.ShapeType.PYRAMID)
					pyramid.color = userColor;
				else if (choosingShape == Shape.ShapeType.PRISMATIC)
					prismatic.color = userColor;
			}
		}

        
        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            //  sự kiện dán ảnh lên khối được chọn
            openFileDialog1.ShowDialog();

            // Lấy đối tượng OpenGL
            OpenGL gl = drawBoard.OpenGL;

            // chấp nhận texture
            gl.Enable(OpenGL.GL_TEXTURE_2D);


            if (choosingShape == Shape.ShapeType.CUBE)
            {
                EnableTextureCube = true;
                EnableTexturePyramid = false;
            }
            else if (choosingShape == Shape.ShapeType.PYRAMID)
            {
                EnableTexturePyramid = true;
                EnableTextureCube = false;
            }
            //  Destroy the existing texture.
            texture.Destroy(drawBoard.OpenGL);

            //  Create a new texture.
            texture.Create(gl, openFileDialog1.FileName);
            

            //  Redraw.
            drawBoard.Invalidate();

            
       
        }
    }

    public class Shape
	{
		//Lớp "hình vẽ"

		public enum ShapeType { NONE, CUBE, PYRAMID, PRISMATIC };

		//Loại hình vẽ
		ShapeType type;
		//Màu hình vẽ
		public Color color;

		//Tâm đáy
		public Tuple<double, double, double> center;
		//Chiều cao
		public double h;
		//Chiều dài cạnh đáy
		public double a;

		//Tập đỉnh
		public List<Tuple<double, double, double>> vertex;
		//Tập thứ tự các đỉnh vẽ
		public List<int> index;

		public Shape(ShapeType userType, Color userColor)
		{
			//Khởi tạo
			a = h = 2;
			type = userType;
			color = userColor;

			if (type == ShapeType.CUBE)
			{
				//Khối lập phương, 8 đỉnh
				center = new Tuple<double, double, double>(1, 1, 0);

				vertex = new List<Tuple<double, double, double>>();
				vertex.Add(new Tuple<double, double, double>(0, 0, 0));
				vertex.Add(new Tuple<double, double, double>(0, 2, 0));
				vertex.Add(new Tuple<double, double, double>(2, 2, 0));
				vertex.Add(new Tuple<double, double, double>(2, 0, 0));
				vertex.Add(new Tuple<double, double, double>(0, 0, h));
				vertex.Add(new Tuple<double, double, double>(0, 2, h));
				vertex.Add(new Tuple<double, double, double>(2, 2, h));
				vertex.Add(new Tuple<double, double, double>(2, 0, h));

				//Thứ tự vẽ (đáy trên, đáy dưới, mặt trái, mặt phải, mặt trước, mặt sau)
				index = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 5, 4, 2, 3, 7, 6, 1, 2, 6, 5, 0, 3, 7, 4 };
			}
			else if (type == ShapeType.PYRAMID)
			{
				//Khối chóp, 5 đỉnh
				center = new Tuple<double, double, double>(1, 3, 0);

				vertex = new List<Tuple<double, double, double>>();
				vertex.Add(new Tuple<double, double, double>(1, 3, h));
				vertex.Add(new Tuple<double, double, double>(0, 2, 0));
				vertex.Add(new Tuple<double, double, double>(0, 4, 0));
				vertex.Add(new Tuple<double, double, double>(2, 4, 0));
				vertex.Add(new Tuple<double, double, double>(2, 2, 0));

				//Thứ tự vẽ (đáy dưới, mặt trái, mặt trái, mặt phải, mặt sau, mặt trước)
				index = new List<int>() { 1, 2, 3, 4, 0, 1, 2, 0, 3, 4, 0, 2, 3, 0, 4, 1 };
			}
			else if (type == ShapeType.PRISMATIC)
			{
				//Khối lăng trụ, 6 đỉnh
				center = new Tuple<double, double, double>(3, a * Math.Sqrt(3) / 6, 0);

				vertex = new List<Tuple<double, double, double>>();
				vertex.Add(new Tuple<double, double, double>(2, 0, 0));
				vertex.Add(new Tuple<double, double, double>(3, 2 * Math.Sqrt(3) / 2, 0));
				vertex.Add(new Tuple<double, double, double>(4, 0, 0));
				vertex.Add(new Tuple<double, double, double>(2, 0, h));
				vertex.Add(new Tuple<double, double, double>(3, 2 * Math.Sqrt(3) / 2, h));
				vertex.Add(new Tuple<double, double, double>(4, 0, h));

				//Thứ tự vẽ (đáy dưới, đáy trên, mặt trái, mặt phải, mặt trước)
				index = new List<int>() { 0, 1, 2, 3, 4, 5, 0, 1, 4, 3, 1, 2, 5, 4, 0, 2, 5, 3};
			}
		}

		public void Draw(OpenGL gl)
		{
			gl.Color(color.R, color.G, color.B, (byte)(50));

			if (type == ShapeType.CUBE)
			{
				//Vẽ khối lập phương (các mặt chữ nhật)
				gl.Begin(OpenGL.GL_QUADS);
					for (int i = 0; i < index.Count; i++)
						gl.Vertex(vertex[index[i]].Item1, vertex[index[i]].Item2, vertex[index[i]].Item3);
				gl.End();
			}
			else if (type == ShapeType.PYRAMID)
			{
				//Vẽ khối chóp (mặt đáy chữ nhật, các mặt bên tam giác)
				gl.Begin(OpenGL.GL_QUADS);
				for (int i = 0; i < 4; i++)
					gl.Vertex(vertex[index[i]].Item1, vertex[index[i]].Item2, vertex[index[i]].Item3);
				gl.End();

				gl.Begin(OpenGL.GL_TRIANGLES);
					for (int i = 4; i < index.Count; i++)
						gl.Vertex(vertex[index[i]].Item1, vertex[index[i]].Item2, vertex[index[i]].Item3);
				gl.End();
			}
			else if (type == ShapeType.PRISMATIC)
			{
				//Vẽ khối lăng trụ (mặt đáy tam giác, các mặt bên chữ nhật)
				gl.Begin(OpenGL.GL_TRIANGLES);
					for (int i = 0; i < 6; i++)
						gl.Vertex(vertex[index[i]].Item1, vertex[index[i]].Item2, vertex[index[i]].Item3);
				gl.End();

				gl.Begin(OpenGL.GL_QUADS);
					for (int i = 6; i < index.Count; i++)
						gl.Vertex(vertex[index[i]].Item1, vertex[index[i]].Item2, vertex[index[i]].Item3);
				gl.End();
			}
		}

		public void DrawEdge(OpenGL gl)
		{
			//Vẽ các cạnh
			gl.Color(Color.Orange.R, Color.Orange.G, Color.Orange.B);

			if (type == ShapeType.CUBE)
			{
				//Khối lập phương
				List<int> lineIndex = new List<int>() { 0, 1, 1, 2, 2, 3, 3, 0, 4, 5, 5, 6, 6, 7, 7, 4, 0, 4, 1, 5, 2, 6, 3, 7 };

				gl.Color(Color.Orange.R, Color.Orange.G, Color.Orange.B);
				gl.LineWidth(3.5f);

				gl.Begin(OpenGL.GL_LINES);
					for (int i = 0; i < lineIndex.Count; i++)
						gl.Vertex(vertex[lineIndex[i]].Item1, vertex[lineIndex[i]].Item2, vertex[lineIndex[i]].Item3);
				gl.End();
				gl.LineWidth(1.0f);
			}
			else if (type == ShapeType.PYRAMID)
			{
				//Khối chóp
				List<int> lineIndex = new List<int>() { 1, 2, 2, 3, 3, 4, 4, 1, 0, 1, 0, 2, 0, 3, 0, 4 };

				gl.Color(Color.Orange.R, Color.Orange.G, Color.Orange.B);
				gl.LineWidth(3.5f);

				gl.Begin(OpenGL.GL_LINES);
					for (int i = 0; i < lineIndex.Count; i++)
						gl.Vertex(vertex[lineIndex[i]].Item1, vertex[lineIndex[i]].Item2, vertex[lineIndex[i]].Item3);
				gl.End();
				gl.LineWidth(1.0f);
			}
			else if (type == ShapeType.PRISMATIC)
			{
				//Khối lăng trụ
				List<int> lineIndex = new List<int>() { 0, 1, 1, 2, 2, 0, 3, 4, 4, 5, 5, 3, 0, 3, 1, 4, 2, 5 };

				gl.Color(Color.Orange.R, Color.Orange.G, Color.Orange.B);
				gl.LineWidth(3.5f);

				gl.Begin(OpenGL.GL_LINES);
					for (int i = 0; i < lineIndex.Count; i++)
						gl.Vertex(vertex[lineIndex[i]].Item1, vertex[lineIndex[i]].Item2, vertex[lineIndex[i]].Item3);
				gl.End();
				gl.LineWidth(1.0f);
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

