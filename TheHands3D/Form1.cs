using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SharpGL.SceneGraph.Assets;
using System.Threading;

namespace TheHands3D
{
    public partial class mainForm : Form
    {
        Camera camera = new Camera();
        Shape cube = new Shape(Shape.ShapeType.CUBE, Color.White);
        Shape pyramid = new Shape(Shape.ShapeType.PYRAMID, Color.Red);
        Shape prismatic = new Shape(Shape.ShapeType.PRISMATIC, Color.Aqua);

		Texture texture = new Texture();
		bool EnableTextureCube = false;
		bool EnableTexturePyramid = false;

		AffineTransform3D affine = new AffineTransform3D();
		double affX, affY, affZ, _time; //Biến lưu thông số biến đổi, thời gian thực hiện
		double frames, count = 0; //Biến lưu số frame và biến đếm cho biết khi nào biến đổi xong
		bool isTransform = false;
        
        Color userColor = Color.White;
        Shape.ShapeType choosingShape = Shape.ShapeType.NONE;

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

				//Mặt phẳng đáy
				for (int i = 0; i <= 14; i++)
				{
					if (i == 0 || i == 7 || i == 14) gl.Color(1.0f, 1.0f, 1.0f, 1.0f);
					else gl.Color(0.5f, 0.5f, 0.5f, 1.0f);

					gl.Vertex(-14.0f + 2 * i, -14.0f, 0.0f);
					gl.Vertex(-14.0f + 2 * i, 14.0f, 0.0f);
					gl.Vertex(-14.0f, -14.0f + 2 * i, 0.0f);
					gl.Vertex(14.0f, -14.0f + 2 * i, 0.0f);
				}
			gl.End();
			gl.LineWidth(1.0f);

			//Biến đổi affine
			if(isTransform)
			{ 
				if (choosingShape == Shape.ShapeType.CUBE)
				{
					for (int i = 0; i < cube.vertex.Count; i++)
						cube.vertex[i] = affine.Transform(cube.vertex[i]);
				}
				else if (choosingShape == Shape.ShapeType.PYRAMID)
				{
					for (int i = 0; i < pyramid.vertex.Count; i++)
						pyramid.vertex[i] = affine.Transform(pyramid.vertex[i]);
				}
				else if (choosingShape == Shape.ShapeType.PRISMATIC)
				{
					for (int i = 0; i < prismatic.vertex.Count; i++)
						prismatic.vertex[i] = affine.Transform(prismatic.vertex[i]);
				}
				count++; //Tính toán xem khi nào dừng biến đổi
				if (count == frames) //Khi cộng các độ chia lại lớn hơn tham số đầu tiên
				{
					count = 0;
					isTransform = false;
				}
			}


			//Vẽ các khối có texture
			if (EnableTextureCube == true)
			{
				Texturing texturing = new Texturing();
				texturing.blindTexture(cube, texture, gl);
			}
			else
				cube.Draw(gl);

			if (EnableTexturePyramid == true)
			{
				Texturing texturing = new Texturing();
				texturing.blindTexture(pyramid, texture, gl);
			}
			else
				pyramid.Draw(gl);

			prismatic.Draw(gl);

			//Tô đậm cạnh của khối đang được chọn
			if (choosingShape == Shape.ShapeType.CUBE)
			{
				cube.DrawEdge(gl);
				pyramid.DrawEdge2(gl);
				prismatic.DrawEdge2(gl);
			}
			else if (choosingShape == Shape.ShapeType.PYRAMID)
			{
				pyramid.DrawEdge(gl);
				cube.DrawEdge2(gl);
				prismatic.DrawEdge2(gl);
			}
			else if (choosingShape == Shape.ShapeType.PRISMATIC)
			{
				prismatic.DrawEdge(gl);
				cube.DrawEdge2(gl);
				pyramid.DrawEdge2(gl);
			}
			else
			{
				prismatic.DrawEdge2(gl);
				cube.DrawEdge2(gl);
				pyramid.DrawEdge2(gl);
			}

            gl.Flush();
			Thread.Sleep((int)(_time * 1000 / 30));
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
			else
				choosingShape = Shape.ShapeType.NONE;
		}

        private void btnColor_Click(object sender, EventArgs e)
        {
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				userColor = colorDialog.Color;
				if (choosingShape == Shape.ShapeType.CUBE)
				{
					cube.color = userColor;
					EnableTextureCube = false;
				}
				else if (choosingShape == Shape.ShapeType.PYRAMID)
				{
					pyramid.color = userColor;
					EnableTexturePyramid = false;
				}
				else if (choosingShape == Shape.ShapeType.PRISMATIC)
					prismatic.color = userColor;
			}
		}

        private void btnTransformation_Click(object sender, EventArgs e)
        {
            // Thực hiện phép biến đổi affine lên hình được chọn
            affine.LoadIdentity();
			affX = Convert.ToDouble(tbX.Text);
			affY = Convert.ToDouble(tbY.Text);
			affZ = Convert.ToDouble(tbZ.Text);
			_time = Convert.ToDouble(tbTime.Text);
			isTransform = true;
			//30 frame/1s tức là lấy thông số biến đổi chia cho tổng số frame để ra độ tăng theo thời gian
			frames = 30 * _time; //Tổng số frames
			double divAffX = affX / frames, 
				divAffY = affY / frames, 
				divAffZ = affZ / frames;
			

			if (cbTransformation.SelectedIndex == 0) // Move
            {
                affine.Translate(divAffX, divAffY, divAffZ);
            }
            else if (cbTransformation.SelectedIndex == 1) //Rotate
            {
                affine.RotateX(divAffX);
                affine.RotateY(divAffY);
                affine.RotateZ(divAffZ);
            }
            else if (cbTransformation.SelectedIndex == 2) // Zoom
            {
                affine.Scale(divAffX, divAffY, divAffZ);
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
			//Destroy the existing texture.
			texture.Destroy(drawBoard.OpenGL);

			//Create a new texture.
			texture.Create(gl, openFileDialog1.FileName);

			//Redraw.
			drawBoard.Invalidate();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			cube = new Shape(Shape.ShapeType.CUBE, Color.White);
			pyramid = new Shape(Shape.ShapeType.PYRAMID, Color.Red);
			prismatic = new Shape(Shape.ShapeType.PRISMATIC, Color.Aqua);
		}
	}
}