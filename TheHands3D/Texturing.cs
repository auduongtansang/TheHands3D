using SharpGL;
using SharpGL.SceneGraph.Assets;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheHands3D
{ 
	class Texturing
	{
		//Các đỉnh của hình
		List<Point> textCoord = new List<Point>();
		//Danh sách thứ tự các đỉnh
		List<int> index;
		public Texturing()
		{
			textCoord.Add(new Point(0, 0));
			textCoord.Add(new Point(1, 0));
			textCoord.Add(new Point(1, 1));
			textCoord.Add(new Point(0, 1));
		}

		void initIndexList(Shape shape)
		{
			if (shape.type == Shape.ShapeType.CUBE)
				index = new List<int>() { 1, 2, 3, 0, 0, 1, 2, 3, 0, 1, 2, 3, 1, 2, 3, 0, 3, 0, 1, 2, 2, 3, 0, 1 };
			else if (shape.type == Shape.ShapeType.PYRAMID)
				index = new List<int>() { 3, 0, 1, 2, 0, 3, 2, 1, 2, 1, 0, 3, 3, 2, 1, 0, 1, 0, 3, 2 };
		}

		public void blindTexture(Shape shape, Texture texture, OpenGL gl)
		{
			initIndexList(shape);
			texture.Bind(gl);
			if (shape.type == Shape.ShapeType.CUBE)
			{
				gl.Begin(OpenGL.GL_QUADS);
				for (int i = 0; i <  index.Count; i++)
				{
					gl.TexCoord(textCoord[index[i]].X, textCoord[index[i]].Y);
					gl.Vertex(shape.vertex[shape.index[i]].Item1, shape.vertex[shape.index[i]].Item2, shape.vertex[shape.index[i]].Item3);
				}
				gl.End();

			}
			else if (shape.type == Shape.ShapeType.PYRAMID)
			{
				//dánh sách vẽ các mặt tam giác của hình chóp thành hình vuông
				List<int> index2 = new List<int>() { 1, 2, 3, 4, 0, 1, 2, 0, 0, 3, 4, 0, 0, 2, 3, 0, 0, 4, 1, 0 };
				gl.Begin(OpenGL.GL_QUADS);
				for (int i = 0; i < index.Count; i++)
				{
					gl.TexCoord(textCoord[index[i]].X, textCoord[index[i]].Y);
					gl.Vertex(shape.vertex[index2[i]].Item1, shape.vertex[index2[i]].Item2, shape.vertex[index2[i]].Item3);
				}
				gl.End();
			}
		}
	}
}
