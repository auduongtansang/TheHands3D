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
			((System.ComponentModel.ISupportInitialize)(this.drawBoard)).BeginInit();
			this.SuspendLayout();
			// 
			// drawBoard
			// 
			this.drawBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.drawBoard.DrawFPS = false;
			this.drawBoard.Location = new System.Drawing.Point(0, 37);
			this.drawBoard.Name = "drawBoard";
			this.drawBoard.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
			this.drawBoard.RenderContextType = SharpGL.RenderContextType.DIBSection;
			this.drawBoard.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
			this.drawBoard.Size = new System.Drawing.Size(668, 488);
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
            "Prismatic"});
			this.cbShape.Location = new System.Drawing.Point(103, 8);
			this.cbShape.Name = "cbShape";
			this.cbShape.Size = new System.Drawing.Size(121, 21);
			this.cbShape.TabIndex = 1;
			this.cbShape.SelectionChangeCommitted += new System.EventHandler(this.cbShape_SelectionChangeCommitted);
			// 
			// lbChoosing
			// 
			this.lbChoosing.AutoSize = true;
			this.lbChoosing.Location = new System.Drawing.Point(10, 11);
			this.lbChoosing.Name = "lbChoosing";
			this.lbChoosing.Size = new System.Drawing.Size(87, 13);
			this.lbChoosing.TabIndex = 2;
			this.lbChoosing.Text = "Choose a shape:";
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(230, 7);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(75, 23);
			this.btnColor.TabIndex = 3;
			this.btnColor.Text = "Color";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(668, 561);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.lbChoosing);
			this.Controls.Add(this.cbShape);
			this.Controls.Add(this.drawBoard);
			this.MinimumSize = new System.Drawing.Size(672, 568);
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
	}
}

