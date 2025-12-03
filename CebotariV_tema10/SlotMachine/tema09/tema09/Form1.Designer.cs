namespace tema09
{
    partial class Form1
    {
   
        private System.ComponentModel.IContainer components = null;

    
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainViewport = new OpenTK.GLControl();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.AnimationTimer = new System.Windows.Forms.Timer(this.components);
            this.FrameTimer = new System.Windows.Forms.Timer(this.components);
            this.cyclesInput = new System.Windows.Forms.NumericUpDown();
            this.labelYouWin = new System.Windows.Forms.Label();
            this.labelYouLose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cyclesInput)).BeginInit();
            this.SuspendLayout();

            // MainViewport 
            this.MainViewport.BackColor = System.Drawing.Color.DimGray;
            this.MainViewport.Location = new System.Drawing.Point(24, 12);
            this.MainViewport.Name = "MainViewport";
            this.MainViewport.Size = new System.Drawing.Size(741, 240);
            this.MainViewport.TabIndex = 0;
            this.MainViewport.VSync = false;
            this.MainViewport.Load += new System.EventHandler(this.MainViewport_Load);
            this.MainViewport.Paint += new System.Windows.Forms.PaintEventHandler(this.MainViewport_Paint);
        
            this.MainTimer.Interval = 500;
            this.MainTimer.Tick += new System.EventHandler(this.timer1_Tick);
            



            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Location = new System.Drawing.Point(652, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 53);
            this.button1.TabIndex = 1;
            this.button1.Text = "SPIN!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.SpinButton_Click);
         
 
            this.AnimationTimer.Interval = 500;
            this.AnimationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            
            // FrameTimer 
            this.FrameTimer.Interval = 5;
            this.FrameTimer.Tick += new System.EventHandler(this.FrameTimer_Tick);
            // 
            // cyclesInput
            // 
            this.cyclesInput.Location = new System.Drawing.Point(24, 393);
            this.cyclesInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cyclesInput.Name = "cyclesInput";
            this.cyclesInput.Size = new System.Drawing.Size(120, 20);
            this.cyclesInput.TabIndex = 2;
            this.cyclesInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelYouWin
            // 
            this.labelYouWin.AutoSize = true;
            this.labelYouWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.labelYouWin.ForeColor = System.Drawing.Color.Green;
            this.labelYouWin.Location = new System.Drawing.Point(325, 255);
            this.labelYouWin.Name = "labelYouWin";
            this.labelYouWin.Size = new System.Drawing.Size(171, 46);
            this.labelYouWin.TabIndex = 3;
            this.labelYouWin.Text = "You Win";
            this.labelYouWin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelYouLose
            // 
            this.labelYouLose.AutoSize = true;
            this.labelYouLose.BackColor = System.Drawing.Color.DarkRed;
            this.labelYouLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.labelYouLose.ForeColor = System.Drawing.Color.Crimson;
            this.labelYouLose.Location = new System.Drawing.Point(325, 255);
            this.labelYouLose.Name = "labelYouLose";
            this.labelYouLose.Size = new System.Drawing.Size(189, 46);
            this.labelYouLose.TabIndex = 4;
            this.labelYouLose.Text = "You Lose";
            this.labelYouLose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(21, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of Cycles:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelYouLose);
            this.Controls.Add(this.labelYouWin);
            this.Controls.Add(this.cyclesInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainViewport);
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cyclesInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl MainViewport;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer AnimationTimer;
        private System.Windows.Forms.Timer FrameTimer;
        private System.Windows.Forms.NumericUpDown cyclesInput;
        private System.Windows.Forms.Label labelYouWin;
        private System.Windows.Forms.Label labelYouLose;
        private System.Windows.Forms.Label label1;
    }
}

