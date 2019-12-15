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
