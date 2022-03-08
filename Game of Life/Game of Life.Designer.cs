namespace Game_of_Life
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button btnPause;
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbBoard = new System.Windows.Forms.PictureBox();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nudDensity = new System.Windows.Forms.NumericUpDown();
            this.lblSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.lblDelay = new System.Windows.Forms.Label();
            this.nudDelay = new System.Windows.Forms.NumericUpDown();
            this.btnTick = new System.Windows.Forms.Button();
            this.lblGeneration = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSimGens = new System.Windows.Forms.NumericUpDown();
            this.btnSimGens = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.drawingControls = new System.Windows.Forms.Panel();
            this.cbHorLine = new System.Windows.Forms.CheckBox();
            this.cbLine = new System.Windows.Forms.CheckBox();
            this.lblDrawingToolsTitle = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimGens)).BeginInit();
            this.drawingControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPause
            // 
            btnPause.AccessibleName = "btnPause";
            btnPause.Anchor = System.Windows.Forms.AnchorStyles.Right;
            btnPause.Location = new System.Drawing.Point(691, 39);
            btnPause.Name = "btnPause";
            btnPause.Size = new System.Drawing.Size(75, 23);
            btnPause.TabIndex = 5;
            btnPause.Tag = "btnPause";
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(106, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(579, 307);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pbBoard
            // 
            this.pbBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbBoard.Location = new System.Drawing.Point(106, 39);
            this.pbBoard.Name = "pbBoard";
            this.pbBoard.Size = new System.Drawing.Size(580, 310);
            this.pbBoard.TabIndex = 0;
            this.pbBoard.TabStop = false;
            this.pbBoard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbBoard_MouseDown);
            this.pbBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbBoard_MouseMove);
            this.pbBoard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbBoard_MouseUp);
            // 
            // nudSize
            // 
            this.nudSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudSize.Location = new System.Drawing.Point(181, 13);
            this.nudSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(50, 20);
            this.nudSize.TabIndex = 1;
            this.nudSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nudDensity
            // 
            this.nudDensity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudDensity.Location = new System.Drawing.Point(329, 13);
            this.nudDensity.Name = "nudDensity";
            this.nudDensity.Size = new System.Drawing.Size(56, 20);
            this.nudDensity.TabIndex = 2;
            this.nudDensity.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // lblSize
            // 
            this.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(107, 15);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(68, 13);
            this.lblSize.TabIndex = 3;
            this.lblSize.Text = "Cell size (px):";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pop. density (%)";
            // 
            // btnApply
            // 
            this.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnApply.Location = new System.Drawing.Point(521, 13);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "New Game";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.Color = System.Drawing.Color.Cyan;
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(15, 39);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 23);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "Color";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(397, 15);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(59, 13);
            this.lblDelay.TabIndex = 8;
            this.lblDelay.Text = "Delay (ms):";
            // 
            // nudDelay
            // 
            this.nudDelay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nudDelay.Location = new System.Drawing.Point(462, 13);
            this.nudDelay.Name = "nudDelay";
            this.nudDelay.Size = new System.Drawing.Size(53, 20);
            this.nudDelay.TabIndex = 9;
            this.nudDelay.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudDelay.ValueChanged += new System.EventHandler(this.nudDelay_ValueChanged);
            // 
            // btnTick
            // 
            this.btnTick.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnTick.Location = new System.Drawing.Point(691, 68);
            this.btnTick.Name = "btnTick";
            this.btnTick.Size = new System.Drawing.Size(75, 23);
            this.btnTick.TabIndex = 10;
            this.btnTick.Text = "Tick";
            this.btnTick.UseVisualStyleBackColor = true;
            this.btnTick.Click += new System.EventHandler(this.btnTick_Click);
            // 
            // lblGeneration
            // 
            this.lblGeneration.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblGeneration.AutoSize = true;
            this.lblGeneration.Location = new System.Drawing.Point(107, 356);
            this.lblGeneration.Name = "lblGeneration";
            this.lblGeneration.Size = new System.Drawing.Size(13, 13);
            this.lblGeneration.TabIndex = 11;
            this.lblGeneration.Text = "1";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Simulate # of generations:";
            // 
            // nudSimGens
            // 
            this.nudSimGens.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nudSimGens.Location = new System.Drawing.Point(243, 377);
            this.nudSimGens.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudSimGens.Name = "nudSimGens";
            this.nudSimGens.Size = new System.Drawing.Size(80, 20);
            this.nudSimGens.TabIndex = 13;
            // 
            // btnSimGens
            // 
            this.btnSimGens.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSimGens.Location = new System.Drawing.Point(329, 374);
            this.btnSimGens.Name = "btnSimGens";
            this.btnSimGens.Size = new System.Drawing.Size(75, 23);
            this.btnSimGens.TabIndex = 14;
            this.btnSimGens.Text = "Simulate";
            this.btnSimGens.UseVisualStyleBackColor = true;
            this.btnSimGens.Click += new System.EventHandler(this.btnSimGens_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnReset.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnReset.Location = new System.Drawing.Point(691, 326);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // drawingControls
            // 
            this.drawingControls.BackColor = System.Drawing.SystemColors.Menu;
            this.drawingControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawingControls.Controls.Add(this.cbHorLine);
            this.drawingControls.Controls.Add(this.cbLine);
            this.drawingControls.Controls.Add(this.lblDrawingToolsTitle);
            this.drawingControls.Location = new System.Drawing.Point(8, 68);
            this.drawingControls.Name = "drawingControls";
            this.drawingControls.Size = new System.Drawing.Size(92, 167);
            this.drawingControls.TabIndex = 16;
            // 
            // cbHorLine
            // 
            this.cbHorLine.AutoSize = true;
            this.cbHorLine.Location = new System.Drawing.Point(3, 44);
            this.cbHorLine.Name = "cbHorLine";
            this.cbHorLine.Size = new System.Drawing.Size(73, 17);
            this.cbHorLine.TabIndex = 2;
            this.cbHorLine.Text = "Horizontal";
            this.cbHorLine.UseVisualStyleBackColor = true;
            this.cbHorLine.CheckedChanged += new System.EventHandler(this.cbHorLine_CheckedChanged);
            // 
            // cbLine
            // 
            this.cbLine.AutoSize = true;
            this.cbLine.Location = new System.Drawing.Point(3, 20);
            this.cbLine.Name = "cbLine";
            this.cbLine.Size = new System.Drawing.Size(61, 17);
            this.cbLine.TabIndex = 1;
            this.cbLine.Text = "Vertical";
            this.cbLine.UseVisualStyleBackColor = true;
            this.cbLine.CheckedChanged += new System.EventHandler(this.cbLine_CheckedChanged);
            // 
            // lblDrawingToolsTitle
            // 
            this.lblDrawingToolsTitle.AutoSize = true;
            this.lblDrawingToolsTitle.Location = new System.Drawing.Point(3, 4);
            this.lblDrawingToolsTitle.Name = "lblDrawingToolsTitle";
            this.lblDrawingToolsTitle.Size = new System.Drawing.Size(75, 13);
            this.lblDrawingToolsTitle.TabIndex = 0;
            this.lblDrawingToolsTitle.Text = "Drawing Tools";
            this.lblDrawingToolsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDrawingToolsTitle.Click += new System.EventHandler(this.label3_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(786, 411);
            this.Controls.Add(this.drawingControls);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSimGens);
            this.Controls.Add(this.nudSimGens);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGeneration);
            this.Controls.Add(this.btnTick);
            this.Controls.Add(this.nudDelay);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(btnPause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.nudDensity);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.pbBoard);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Continue";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSimGens)).EndInit();
            this.drawingControls.ResumeLayout(false);
            this.drawingControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbBoard;
        private System.Windows.Forms.NumericUpDown nudSize;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown nudDensity;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.NumericUpDown nudDelay;
        private System.Windows.Forms.Button btnTick;
        private System.Windows.Forms.Label lblGeneration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSimGens;
        private System.Windows.Forms.Button btnSimGens;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel drawingControls;
        private System.Windows.Forms.Label lblDrawingToolsTitle;
        private System.Windows.Forms.CheckBox cbLine;
        private System.Windows.Forms.CheckBox cbHorLine;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

