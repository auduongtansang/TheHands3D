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
			this.btnChooseImage = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
			this.drawBoard.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
			this.drawBoard.Name = "drawBoard";
			this.drawBoard.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
			this.drawBoard.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.drawBoard.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.drawBoard.Size = new System.Drawing.Size(891, 601);
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
			this.cbShape.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			this.btnColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(100, 28);
			this.btnColor.TabIndex = 3;
			this.btnColor.Text = "Color";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// btnChooseImage
			// 
			this.btnChooseImage.Location = new System.Drawing.Point(757, 10);
			this.btnChooseImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnChooseImage.Name = "btnChooseImage";
			this.btnChooseImage.Size = new System.Drawing.Size(117, 28);
			this.btnChooseImage.TabIndex = 4;
			this.btnChooseImage.Text = "Choose Image";
			this.btnChooseImage.UseVisualStyleBackColor = true;
			this.btnChooseImage.Click += new System.EventHandler(this.btnChooseImage_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(891, 690);
			this.Controls.Add(this.btnChooseImage);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.lbChoosing);
			this.Controls.Add(this.cbShape);
			this.Controls.Add(this.drawBoard);
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimumSize = new System.Drawing.Size(890, 688);
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
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

