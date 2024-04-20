namespace PacmanGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pbPlayerShip = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerShip)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "qisvspqn-removebg-preview.png");
            this.imageList1.Images.SetKeyName(1, "dark-blue-nebula-sparkle-purple-star-universe-in-outer-space-horizontal-galaxy-on" +
        "-space-free-photo.png");
            // 
            // pbPlayerShip
            // 
            this.pbPlayerShip.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbPlayerShip.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayerShip.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerShip.Image")));
            this.pbPlayerShip.Location = new System.Drawing.Point(376, 452);
            this.pbPlayerShip.Name = "pbPlayerShip";
            this.pbPlayerShip.Size = new System.Drawing.Size(63, 79);
            this.pbPlayerShip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayerShip.TabIndex = 0;
            this.pbPlayerShip.TabStop = false;
            this.pbPlayerShip.Click += new System.EventHandler(this.TimeGameLoop_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.TimeGameLoop_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(788, 560);
            this.Controls.Add(this.pbPlayerShip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerShip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pbPlayerShip;
        private System.Windows.Forms.Timer timer1;
    }
}

