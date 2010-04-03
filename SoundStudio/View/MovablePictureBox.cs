using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundStudio.View {
    public partial class MovablePictureBox : System.Windows.Forms.PictureBox {
        protected int tempX, tempY;
        protected bool isDown;
        protected bool isSelected;
        protected bool threadRunning;
        protected Model.SoundPosition soundPosition;
        protected Controller.StaveController staveController;
        
        #region " Contructor "
        
        public MovablePictureBox(int x, int y, System.Drawing.Image image, Model.SoundPosition soundPosition, Controller.StaveController staveController) {
            this.threadRunning = true;
            this.Location = new Point(x, y);
            this.Width = 32;
            this.Height = 32;
            this.staveController = staveController;
            
            this.Image = (System.Drawing.Image) image.Clone();
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.soundPosition = soundPosition;
            
            InitializeComponent();
            this.IsSelected = false;
            this.threadRunning = false;
        }

        #endregion

        #region " Properties "
        public bool IsSelected {
            get {
                return this.isSelected;
            }
            set {
                if(this.threadRunning == true) return;
                this.threadRunning = true;
                this.isSelected = value;
                if (value == true) {
                    this.BorderStyle = BorderStyle.Fixed3D;
                } else {
                    this.BorderStyle = BorderStyle.None;
                    this.staveController.SetDown(this);
                }
                this.threadRunning = false;
            }
        }
      
        public int PositionLeft {
            get {
                return this.Left;
            }
        }
      
        public int PositionTop {
            get {
                return this.Top;
            }
        }
        #endregion

        #region " Public Methods "

        public void SetPositionLeft(bool first, int value) {
            int diffLeft = this.Left - value;
            this.Left = Math.Min(this.Parent.Width - 10, value);

            if (first) {
                // for first time - update other selected icons
                staveController.MoveLeft(diffLeft, this);
            }

            // update sound position in melody (only the X-axis)
            this.soundPosition.Position = this.Left;
        }

        public void SetPositionTop(bool first, int value) {
            int diffTop = (this.Top - value);
            this.Top = Math.Min(this.Parent.Height - 10, value);
            if (first) {
                // for first time - update other selected icons
                staveController.MoveTop(diffTop, this);
            }
        }
        
        #endregion


        
     

        #region " Events "
        public void MovablePictureBox_Click(object sender, System.EventArgs e) {
            this.IsSelected = !this.IsSelected;
        }

        protected void MovablePictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (this.IsSelected == false) return;
            tempX = e.X;
            tempY = e.Y;
            isDown = true;
        }

        protected void MovablePictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
            if ((this.isDown == false) || (this.IsSelected == false)) return;
            MovablePictureBox b = (MovablePictureBox)sender;
            int newLeft = b.Left + (e.X - tempX);
            int newTop = b.Top + (e.Y - tempY);
            b.SetPositionLeft(true, newLeft);
            b.SetPositionTop(true,newTop);
        }

        protected void MovablePictureBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) {
            if (this.IsSelected == false) return;
            isDown = false;
        }
        #endregion

    }
}
