using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundStudio.View.Forms
{
    public partial class frmStudio : HostForm
    {

    #region " Properties, Init "
        public frmStudio()
        {
            InitializeComponent();
            InitButtons();
            InitControllers();
            InitPointer();
        }

        private void InitPointer() {
            this.pnlMelody.Controls.Add(this.pbMelodyPointer);
        }

        protected void InitButtons()
        {
            this.allButtons = new System.Collections.ArrayList();
            this.allButtons.Add( (new View.PlayButton(Model.Consts.Paths.Drum.Name,
                new Model.Sound(Model.Consts.Paths.Drum.Sound),9, 9, 100, 40 ).SetIcon(Model.Consts.Paths.Drum.Icon)));
            this.allButtons.Add( (new View.PlayButton(Model.Consts.Paths.Frog.Name,
                new Model.Sound(Model.Consts.Paths.Frog.Sound),119, 9, 100, 40).SetIcon(Model.Consts.Paths.Frog.Icon)));
            this.allButtons.Add( (new View.PlayButton(Model.Consts.Paths.Horn.Name,
                new Model.Sound(Model.Consts.Paths.Horn.Sound),229, 9, 100, 40).SetIcon(Model.Consts.Paths.Horn.Icon )));

            foreach(View.PlayButton p in this.allButtons) {
                p.Location = new Point(p.x, p.y);
                p.Width = p.width;
                p.Height = p.height;
                p.Image = p.Image;
                p.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                p.TextAlign = ContentAlignment.MiddleRight;
                p.MouseClick += new MouseEventHandler(MouseClick);
                this.container.Panel1.Controls.Add(p);
            }
            this.lastClickedButton = (View.PlayButton) this.allButtons[0];
        }

        protected void InitControllers() {
            this.mixer = new Controller.Mixer();
            this.stateController  = new Controller.StateController();
            this.staveController = new Controller.StaveController(this.stateController, this.mixer.melody);
            //mixer.stave.setPanel(this.pnlMelody);
        }

        public override void ClearStave() {
            this.pnlMelody.Controls.Clear();
            this.pnlMelody.Controls.Add(this.pbMelodyPointer);
        }

        public override void RefreshStave() {
            this.ClearStave();
            foreach (View.MovablePictureBox pict in staveController.stave) {
                this.pnlMelody.Controls.Add(pict);
            }
        }

    #endregion    

    #region " Events "

        public void ButtonClicked(View.PlayButton clickedButton) {
            this.lastClickedButton = clickedButton;
        }

        public void StaveClicked(int x, int y) {
            this.staveController.StaveClicked(x, y, this.lastClickedButton, this.mixer, this);            
        }

        public void PlayClicked()
        {
            // Start playing sounds
            this.stateController.PlayClicked(this.mixer, this);
        }

        public override void MovePointer(int newPosition) {
            if ((newPosition > 0) && (this.pbMelodyPointer.Visible == false)) {
                this.pbMelodyPointer.Visible = true;
            }
            if (Math.Abs(newPosition-this.pnlMelody.Width)<this.pbMelodyPointer.Width) {
                this.pbMelodyPointer.Visible = false;
            }
            this.pbMelodyPointer.Left = newPosition;
            this.pbMelodyPointer.Refresh();
            this.pnlMelody.Refresh();
        }
        
        private void ClearStaveClicked() {
            // Clears the data collection and after all refresh the view
            this.stateController.ClearStaveClicked(this.staveController, this.mixer, this);
        }


    #endregion

    #region " Formal Events "

        new void MouseClick(object sender, MouseEventArgs newPosition) {
            this.ButtonClicked((View.PlayButton)sender);
        }

        void Melody_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            this.StaveClicked(e.X, e.Y);
        }

        void btnStudioPlay_Click(object sender, EventArgs e) {
            this.PlayClicked();
        }

        private void btnClearStave_Click(object sender, EventArgs e)
        {
            this.ClearStaveClicked();
        }

    #endregion  
    }
}
