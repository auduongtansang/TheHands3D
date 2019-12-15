﻿namespace TheHands3D
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
            this.drawBoard.Margin = new System.Windows.Forms.Padding(4);
            this.drawBoard.Name = "drawBoard";
            this.drawBoard.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.drawBoard.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.drawBoard.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.drawBoard.Size = new System.Drawing.Size(858, 488);
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
            // lbChoosingTransform
            // 
            this.lbChoosingTransform.AutoSize = true;
            this.lbChoosingTransform.Location = new System.Drawing.Point(311, 12);
            this.lbChoosingTransform.Name = "lbChoosingTransform";
            this.lbChoosingTransform.Size = new System.Drawing.Size(127, 13);
            this.lbChoosingTransform.TabIndex = 4;
            this.lbChoosingTransform.Text = "Choose a transformation: ";
            // 
            // cbTransformation
            // 
            this.cbTransformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransformation.FormattingEnabled = true;
            this.cbTransformation.Items.AddRange(new object[] {
            "Position",
            "Rotate",
            "Scale"});
            this.cbTransformation.Location = new System.Drawing.Point(444, 8);
            this.cbTransformation.Name = "cbTransformation";
            this.cbTransformation.Size = new System.Drawing.Size(121, 21);
            this.cbTransformation.TabIndex = 5;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(611, 9);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(30, 20);
            this.tbX.TabIndex = 6;
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(591, 13);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(14, 13);
            this.lbX.TabIndex = 7;
            this.lbX.Text = "X";
            // 
            // lbY
            // 
            this.lbY.AutoSize = true;
            this.lbY.Location = new System.Drawing.Point(647, 13);
            this.lbY.Name = "lbY";
            this.lbY.Size = new System.Drawing.Size(14, 13);
            this.lbY.TabIndex = 8;
            this.lbY.Text = "Y";
            // 
            // lbZ
            // 
            this.lbZ.AutoSize = true;
            this.lbZ.Location = new System.Drawing.Point(703, 13);
            this.lbZ.Name = "lbZ";
            this.lbZ.Size = new System.Drawing.Size(14, 13);
            this.lbZ.TabIndex = 9;
            this.lbZ.Text = "Z";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(667, 9);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(30, 20);
            this.tbY.TabIndex = 10;
            // 
            // tbZ
            // 
            this.tbZ.Location = new System.Drawing.Point(723, 9);
            this.tbZ.Name = "tbZ";
            this.tbZ.Size = new System.Drawing.Size(30, 20);
            this.tbZ.TabIndex = 11;
            // 
            // btnTransformation
            // 
            this.btnTransformation.Location = new System.Drawing.Point(759, 7);
            this.btnTransformation.Name = "btnTransformation";
            this.btnTransformation.Size = new System.Drawing.Size(75, 23);
            this.btnTransformation.TabIndex = 12;
            this.btnTransformation.Text = "Transform";
            this.btnTransformation.UseVisualStyleBackColor = true;
            this.btnTransformation.Click += new System.EventHandler(this.btnTransformation_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 561);
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
            this.MinimumSize = new System.Drawing.Size(672, 566);
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
    }
}

