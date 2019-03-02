namespace Tetris
{
    partial class TetrisForm
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
            this.game_image = new System.Windows.Forms.PictureBox();
            this.redraw_timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.game_image)).BeginInit();
            this.SuspendLayout();
            // 
            // game_image
            // 
            this.game_image.Location = new System.Drawing.Point(12, 12);
            this.game_image.Name = "game_image";
            this.game_image.Size = new System.Drawing.Size(200, 400);
            this.game_image.TabIndex = 0;
            this.game_image.TabStop = false;
            // 
            // redraw_timer
            // 
            this.redraw_timer.Enabled = true;
            this.redraw_timer.Interval = 250;
            this.redraw_timer.Tick += new System.EventHandler(this.redraw_timer_Tick);
            // 
            // TetrisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 450);
            this.Controls.Add(this.game_image);
            this.KeyPreview = true;
            this.Name = "TetrisForm";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetrisForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.game_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox game_image;
        private System.Windows.Forms.Timer redraw_timer;
    }
}

