namespace TheHands3D
{
	partial class mainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.drawBoard = new SharpGL.OpenGLControl();
			this.cbShape = new System.Windows.Forms.ComboBox();
			this.lbChoosing = new System.Windows.Forms.Label();
			this.btnColor = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.lbChoosingTransform = new System.Windows.Forms.Label();
			this.cbTransformation = new System.Windows.Forms.ComboBox();
			this.tbX = new System.Windows.Forms.TextBox();
			this.lbX = new System.Windows.Forms.Label();
			this.lbY = new System.Windows.Forms.Label();
			this.lbZ = new System.Windows.Forms.Label();
			this.tbY = new System.Windows.Forms.TextBox();
			this.tbZ = new System.Windows.Forms.TextBox();
			this.btnTransformation = new System.Windows.Forms.Button();
			this.btnChooseImage = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.time = new System.Windows.Forms.Label();
			this.tbTime = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.drawBoard)).BeginInit();
			this.SuspendLayout();
			// 
			// drawBoard
			// 
			this.drawBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.drawBoard.DrawFPS = false;
			this.drawBoard.Location = new System.Drawing.Point(0, 46);
			this.drawBoard.Margin = new System.Windows.Forms.Padding(5);
			this.drawBoard.Name = "drawBoard";
			this.drawBoard.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
			this.drawBoard.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.drawBoard.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.drawBoard.Size = new System.Drawing.Size(1230, 601);
			this.drawBoard.TabIndex = 0;
			this.drawBoard.OpenGLInitialized += new System.EventHandler(this.drawBoard_OpenGLInitialized);
			this.drawBoard.OpenGLDraw += new SharpGL.RenderEventHandler(this.drawBoard_OpenGLDraw);
			this.drawBoard.Resized += new System.EventHandler(this.drawBoard_Resized);
			this.drawBoard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drawBoard_KeyDown);
			// 
			// cbShape
			// 
			this.cbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbShape.FormattingEnabled = true;
			this.cbShape.Items.AddRange(new object[] {
            "Cube",
            "Pyramid",
            "Prismatic",
            "None"});
			this.cbShape.Location = new System.Drawing.Point(137, 10);
			this.cbShape.Margin = new System.Windows.Forms.Padding(4);
			this.cbShape.Name = "cbShape";
			this.cbShape.Size = new System.Drawing.Size(160, 24);
			this.cbShape.TabIndex = 1;
			this.cbShape.SelectionChangeCommitted += new System.EventHandler(this.cbShape_SelectionChangeCommitted);
			// 
			// lbChoosing
			// 
			this.lbChoosing.AutoSize = true;
			this.lbChoosing.Location = new System.Drawing.Point(13, 14);
			this.lbChoosing.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbChoosing.Name = "lbChoosing";
			this.lbChoosing.Size = new System.Drawing.Size(115, 17);
			this.lbChoosing.TabIndex = 2;
			this.lbChoosing.Text = "Choose a shape:";
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(307, 9);
			this.btnColor.Margin = new System.Windows.Forms.Padding(4);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(100, 28);
			this.btnColor.TabIndex = 3;
			this.btnColor.Text = "Color";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// lbChoosingTransform
			// 
			this.lbChoosingTransform.AutoSize = true;
			this.lbChoosingTransform.Location = new System.Drawing.Point(415, 15);
			this.lbChoosingTransform.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbChoosingTransform.Name = "lbChoosingTransform";
			this.lbChoosingTransform.Size = new System.Drawing.Size(171, 17);
			this.lbChoosingTransform.TabIndex = 4;
			this.lbChoosingTransform.Text = "Choose a transformation: ";
			// 
			// cbTransformation
			// 
			this.cbTransformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTransformation.FormattingEnabled = true;
			this.cbTransformation.Items.AddRange(new object[] {
            "Move",
            "Rotate",
            "Scale"});
			this.cbTransformation.Location = new System.Drawing.Point(592, 10);
			this.cbTransformation.Margin = new System.Windows.Forms.Padding(4);
			this.cbTransformation.Name = "cbTransformation";
			this.cbTransformation.Size = new System.Drawing.Size(160, 24);
			this.cbTransformation.TabIndex = 5;
			// 
			// tbX
			// 
			this.tbX.Location = new System.Drawing.Point(815, 11);
			this.tbX.Margin = new System.Windows.Forms.Padding(4);
			this.tbX.Name = "tbX";
			this.tbX.Size = new System.Drawing.Size(39, 22);
			this.tbX.TabIndex = 6;
			// 
			// lbX
			// 
			this.lbX.AutoSize = true;
			this.lbX.Location = new System.Drawing.Point(788, 16);
			this.lbX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbX.Name = "lbX";
			this.lbX.Size = new System.Drawing.Size(17, 17);
			this.lbX.TabIndex = 7;
			this.lbX.Text = "X";
			// 
			// lbY
			// 
			this.lbY.AutoSize = true;
			this.lbY.Location = new System.Drawing.Point(863, 16);
			this.lbY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbY.Name = "lbY";
			this.lbY.Size = new System.Drawing.Size(17, 17);
			this.lbY.TabIndex = 8;
			this.lbY.Text = "Y";
			// 
			// lbZ
			// 
			this.lbZ.AutoSize = true;
			this.lbZ.Location = new System.Drawing.Point(937, 16);
			this.lbZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbZ.Name = "lbZ";
			this.lbZ.Size = new System.Drawing.Size(17, 17);
			this.lbZ.TabIndex = 9;
			this.lbZ.Text = "Z";
			// 
			// tbY
			// 
			this.tbY.Location = new System.Drawing.Point(889, 11);
			this.tbY.Margin = new System.Windows.Forms.Padding(4);
			this.tbY.Name = "tbY";
			this.tbY.Size = new System.Drawing.Size(39, 22);
			this.tbY.TabIndex = 10;
			// 
			// tbZ
			// 
			this.tbZ.Location = new System.Drawing.Point(964, 11);
			this.tbZ.Margin = new System.Windows.Forms.Padding(4);
			this.tbZ.Name = "tbZ";
			this.tbZ.Size = new System.Drawing.Size(39, 22);
			this.tbZ.TabIndex = 11;
			// 
			// btnTransformation
			// 
			this.btnTransformation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTransformation.Location = new System.Drawing.Point(1108, 8);
			this.btnTransformation.Margin = new System.Windows.Forms.Padding(4);
			this.btnTransformation.Name = "btnTransformation";
			this.btnTransformation.Size = new System.Drawing.Size(108, 28);
			this.btnTransformation.TabIndex = 12;
			this.btnTransformation.Text = "Transform";
			this.btnTransformation.UseVisualStyleBackColor = true;
			this.btnTransformation.Click += new System.EventHandler(this.btnTransformation_Click);
			// 
			// btnChooseImage
			// 
			this.btnChooseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChooseImage.Location = new System.Drawing.Point(1054, 653);
			this.btnChooseImage.Name = "btnChooseImage";
			this.btnChooseImage.Size = new System.Drawing.Size(168, 33);
			this.btnChooseImage.TabIndex = 13;
			this.btnChooseImage.Text = "Choose Image";
			this.btnChooseImage.UseVisualStyleBackColor = true;
			this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// time
			// 
			this.time.AutoSize = true;
			this.time.Location = new System.Drawing.Point(1006, 16);
			this.time.Name = "time";
			this.time.Size = new System.Drawing.Size(39, 17);
			this.time.TabIndex = 14;
			this.time.Text = "Time";
			// 
			// tbTime
			// 
			this.tbTime.Location = new System.Drawing.Point(1047, 11);
			this.tbTime.Name = "tbTime";
			this.tbTime.Size = new System.Drawing.Size(39, 22);
			this.tbTime.TabIndex = 15;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.Location = new System.Drawing.Point(964, 653);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(84, 33);
			this.btnReset.TabIndex = 16;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1230, 690);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.tbTime);
			this.Controls.Add(this.time);
			this.Controls.Add(this.btnChooseImage);
			this.Controls.Add(this.btnTransformation);
			this.Controls.Add(this.tbZ);
			this.Controls.Add(this.tbY);
			this.Controls.Add(this.lbZ);
			this.Controls.Add(this.lbY);
			this.Controls.Add(this.lbX);
			this.Controls.Add(this.tbX);
			this.Controls.Add(this.cbTransformation);
			this.Controls.Add(this.lbChoosingTransform);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.lbChoosing);
			this.Controls.Add(this.cbShape);
			this.Controls.Add(this.drawBoard);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(890, 686);
			this.Name = "mainForm";
			this.Text = "TheHands3D";
			((System.ComponentModel.ISupportInitialize)(this.drawBoard)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SharpGL.OpenGLControl drawBoard;
		private System.Windows.Forms.ComboBox cbShape;
		private System.Windows.Forms.Label lbChoosing;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lbChoosingTransform;
        private System.Windows.Forms.ComboBox cbTransformation;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbY;
        private System.Windows.Forms.Label lbZ;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.TextBox tbZ;
        private System.Windows.Forms.Button btnTransformation;
		private System.Windows.Forms.Button btnChooseImage;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label time;
		private System.Windows.Forms.TextBox tbTime;
		private System.Windows.Forms.Button btnReset;
	}
}

