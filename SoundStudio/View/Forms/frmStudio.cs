using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundStudio
{
    public partial class frmStudio : Form
    {

    #region " Properties, Init "
        // Remember what was the las clicked button.
        protected View.PlayButton lastClickedButton;

        // Collection of all buttons
        public System.Collections.ArrayList allButtons;

        // Form of the Studio
        protected Model.Stave stave;


        public frmStudio()
        {
            // initialize the designer
            InitializeComponent();
            InitButtons();
            InitMelody();
        }

      
        protected void InitButtons() { 
            foreach(View.PlayButton p in this.allButtons) {
                p.Parent = this.container;
                p.Location = new Point(p.x, p.y);
                p.Width = p.width;
                p.Height = p.height;
                p.MouseClick += new MouseEventHandler(MouseClick);
            }
        }

        protected void InitMelody() {
            stave = new Model.Stave();
        }

       
    #endregion

    #region " Events "

        public void ButtonClicked(View.PlayButton clickedButton) {
            this.lastClickedButton = clickedButton;
        }

        public void PanelClicked(int x, int y) { 
            // Put an image onto the panel 
            //stave.Add(x)


            // Save the X information to the Melody

            // Refresh the view


        }

        public void StartClicked() { 
            
        }

    #endregion

    #region " Formal Events "

        void MouseClick(object sender, MouseEventArgs e)
        {
            this.ButtonClicked((View.PlayButton)sender);
        }


        void Melody_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.PanelClicked(e.X, e.Y);
        }

    #endregion
    }
}
