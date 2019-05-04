namespace BoardTest
{
    partial class Welcome
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
            this.label1 = new System.Windows.Forms.Label();
            this.Black = new System.Windows.Forms.RadioButton();
            this.White = new System.Windows.Forms.RadioButton();
            this.game = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(208, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "GoBang v0.0.1a";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Black
            // 
            this.Black.AutoSize = true;
            this.Black.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Black.Location = new System.Drawing.Point(218, 222);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(140, 24);
            this.Black.TabIndex = 1;
            this.Black.Text = "Black First";
            this.Black.UseVisualStyleBackColor = true;
            // 
            // White
            // 
            this.White.AutoSize = true;
            this.White.Checked = true;
            this.White.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.White.Location = new System.Drawing.Point(421, 222);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(140, 24);
            this.White.TabIndex = 2;
            this.White.TabStop = true;
            this.White.Text = "White First";
            this.White.UseVisualStyleBackColor = true;
            // 
            // game
            // 
            this.game.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.game.Location = new System.Drawing.Point(298, 303);
            this.game.Name = "game";
            this.game.Size = new System.Drawing.Size(171, 89);
            this.game.TabIndex = 3;
            this.game.Text = "Start!";
            this.game.UseVisualStyleBackColor = true;
            this.game.Click += new System.EventHandler(this.Game_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.game);
            this.Controls.Add(this.White);
            this.Controls.Add(this.Black);
            this.Controls.Add(this.label1);
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton Black;
        private System.Windows.Forms.RadioButton White;
        private System.Windows.Forms.Button game;
    }
}