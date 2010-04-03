using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Controller {
    public class StaveController {
        // main state controller
        protected StateController stateController;

        // local model
        public Model.Stave stave;  
        public Model.Melody melody;

        protected List<View.MovablePictureBox> selectedMovablePictureBox;
        #region " Constructor "
        public StaveController(StateController sController, Model.Melody melody) {
            this.stateController = sController;
            this.melody = melody;
            this.stave = new Model.Stave(this.melody);
        }
        #endregion

        #region " Public Methods "
        public void MoveLeft(int diffLeft, View.MovablePictureBox sender) {
            foreach(View.MovablePictureBox movablePictureBox in this.stave) {
                if ((movablePictureBox.IsSelected) && (!movablePictureBox.Equals(sender))) {
                    int newLeft = movablePictureBox.Left - diffLeft;
                    movablePictureBox.SetPositionLeft(false, newLeft);
                }
            }
        }

        public void MoveTop(int diffTop, View.MovablePictureBox sender) {
            foreach (View.MovablePictureBox movablePictureBox in this.stave) {
                if ((movablePictureBox.IsSelected) && (!movablePictureBox.Equals(sender))) {
                    int newTop = movablePictureBox.Top - diffTop;
                    movablePictureBox.SetPositionTop(false, newTop);
                }
            }
            
        }
        public void SetDown(View.MovablePictureBox sender) {
            foreach (View.MovablePictureBox movablePictureBox in this.stave) {
                if (!movablePictureBox.Equals(sender)) {
                    movablePictureBox.IsSelected = false;
                }
            }
        }
        #endregion

        #region " Events "
        public void StaveClicked(int x, int y, SoundStudio.View.PlayButton playButton, Mixer mixer,SoundStudio.View.Forms.HostForm hostForm) {
                // check what have been clicked
                bool isPanelClicked = true;
                System.Collections.Generic.Stack<View.MovablePictureBox> clickedBoxes = new Stack<SoundStudio.View.MovablePictureBox>();
                foreach (View.MovablePictureBox mpBox in this.stave) { 
                    int diffX = mpBox.Location.X - x;
                    int diffY = mpBox.Location.Y - y;
                    if ((diffX > -1) && (diffY > -1) && (diffX < mpBox.Width) && (diffY < mpBox.Height)) {        
                        clickedBoxes.Push(mpBox);
                    }
                }

                isPanelClicked = (clickedBoxes.Count == 0);

                if (isPanelClicked) {
                    // if panel has been clicked - add a new sound to mixer
                    this.stateController.PanelClicked(x, y, playButton, this, mixer, hostForm);
                }
            }
         
            public void PanelClicked(int x, int y, System.Drawing.Image image, Model.Sound sound, Controller.StaveController staveController) {
                // Save the X information to the Melody
                Model.SoundPosition soundPosition = new SoundStudio.Model.SoundPosition(x);

                // Pub the melody onto list
                this.melody.Add(soundPosition, sound);

                // Create the image to show on stave
                View.MovablePictureBox mpBox = new View.MovablePictureBox(x, y, image, soundPosition,this);
                
                // Put an image onto the panel
                this.stave.Add(mpBox);
            }
        #endregion




        
    }
}
