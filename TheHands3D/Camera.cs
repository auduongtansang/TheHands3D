using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHands3D
{
	class Camera
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
