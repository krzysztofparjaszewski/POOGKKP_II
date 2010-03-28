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
                p.Image = p.Icon.Image;
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
            //mixer.stave.setPanel(this.pnlMelody);
        }

        public override void ClearStave() {
            this.pnlMelody.Controls.Clear();
        }

        public override void RefreshStave() {
            foreach (System.Windows.Forms.PictureBox pict in mixer.Pictures) {
                PictureBox pb = new PictureBox();
                pb.Image = pict.Image;
                pb.Width = 32; pb.Height = 32;
                pb.Location = pict.Location;
                this.pnlMelody.Controls.Add(pb);
            }
        }

    #endregion    

    #region " Events "

        public void ButtonClicked(View.PlayButton clickedButton) {
            this.lastClickedButton = clickedButton;
        }

        public void PanelClicked(int x, int y) {
            this.stateController.PanelClicked(x, y, this.lastClickedButton,this.mixer, this);            
        }

        public void PlayClicked()
        {
            // Start playing sounds
            this.stateController.PlayClicked(this.mixer, this);
        }

        public override void MovePointer(double thisPosition) {
            System.Windows.Forms.PictureBox pb;
            System.Windows.Forms.Control[] controlsFound = this.pnlMelody.Controls.Find("pbPointer",true);
            if(controlsFound.Length.Equals(0)) {
                pb = new PictureBox();
                pb.Name = "pbPointer";
                pb.Width = 5;
                pb.Height = 130;
            } else {
                pb = (System.Windows.Forms.PictureBox)controlsFound[0];
            }
            pb.Location = new Point(Int32.Parse(Math.Floor(thisPosition).ToString()), 0);
            string localPath = Model.Consts.Paths.CombinePath(Model.Consts.Paths.Pointer.Path);
            pb.Image = System.Drawing.Image.FromFile(localPath);
            if (controlsFound.Length.Equals(0)) {
                this.pnlMelody.Controls.Add(pb);  
            }
            this.pnlMelody.Refresh();
        }
        
        private void ClearStaveClicked() {
            // Clears the data collection and after all refresh the view
            this.stateController.ClearStaveClicked(this.mixer, this);
        }


    #endregion

    #region " Formal Events "

        new void MouseClick(object sender, MouseEventArgs e) {
            this.ButtonClicked((View.PlayButton)sender);
        }

        void Melody_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            this.PanelClicked(e.X, e.Y);
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
