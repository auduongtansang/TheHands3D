using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHands3D
{
	class Shape
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
				index = new List<int>() { 0, 1, 2, 3, 4, 5, 0, 1, 4, 3, 1, 2, 5, 4, 0, 2, 5, 3 };
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
}
