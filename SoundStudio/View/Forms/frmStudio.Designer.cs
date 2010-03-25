﻿namespace SoundStudio
{
    partial class frmStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudio));
            this.container = new System.Windows.Forms.SplitContainer();
            this.pnlMelody = new System.Windows.Forms.Panel();
            this.btnStudioPlay = new System.Windows.Forms.Button();
            this.container.Panel2.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // container.Panel2
            // 
            this.container.Panel2.Controls.Add(this.pnlMelody);
            this.container.Panel2.Controls.Add(this.btnStudioPlay);
            this.container.Size = new System.Drawing.Size(588, 371);
            this.container.SplitterDistance = 180;
            this.container.TabIndex = 0;
            // 
            // pnlMelody
            // 
            this.pnlMelody.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMelody.BackgroundImage")));
            this.pnlMelody.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pnlMelody.Location = new System.Drawing.Point(9, 9);
            this.pnlMelody.Name = "pnlMelody";
            this.pnlMelody.Size = new System.Drawing.Size(566, 130);
            this.pnlMelody.TabIndex = 1;
            this.pnlMelody.MouseClick += new System.Windows.Forms.MouseEventHandler(Melody_MouseClick);
            // 
            // btnStudioPlay
            // 
            this.btnStudioPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnStudioPlay.Image")));
            this.btnStudioPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStudioPlay.Location = new System.Drawing.Point(447, 151);
            this.btnStudioPlay.Name = "btnStudioPlay";
            this.btnStudioPlay.Size = new System.Drawing.Size(129, 24);
            this.btnStudioPlay.TabIndex = 0;
            this.btnStudioPlay.Text = "Play...";
            this.btnStudioPlay.UseVisualStyleBackColor = true;
            // 
            // frmStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 371);
            this.Controls.Add(this.container);
            this.Name = "frmStudio";
            this.Text = "Sound Studio by GK&KP POO 2010 | II@UWr";
            this.container.Panel2.ResumeLayout(false);
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.SplitContainer container;
        private System.Windows.Forms.Button btnStudioPlay;
        private System.Windows.Forms.Panel pnlMelody;
    }
}

