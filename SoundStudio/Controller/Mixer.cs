using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Controller
{
    
    public class Mixer
    {

    #region " Properties, Init "
        
        public System.Media.SoundPlayer soundPlayer;

        public Model.Melody melody;
        public Model.Stave stave;

        public Mixer() {
            this.melody = new Model.Melody();
            this.stave = new Model.Stave();
        }

    #endregion

    #region " Public Methods "
        public void Play(StateController stateController, View.Forms.HostForm hostForm)
        {
            // This works only for thick icons :)
            double currentPosition = 0.0;
            hostForm.MovePointer(currentPosition);
            double lenghtProportion = 40.0 / 5.66;
            foreach(System.Collections.Generic.KeyValuePair<Model.SoundPosition,Model.Sound> pair in this.melody) {
                double thisPosition = ((Model.SoundPosition)pair.Key).Position;
                double sleep = (thisPosition - currentPosition) * lenghtProportion;
                int sleepInt = Int32.Parse(Math.Floor(sleep).ToString());
                System.Threading.Thread.Sleep(sleepInt);
                ((Model.Sound)pair.Value).SoundPlayer.Play();
                currentPosition = thisPosition;
                hostForm.MovePointer(currentPosition);
            }
            hostForm.MovePointer(561.0);
            stateController.MusicEnded();
        }
    #endregion

    #region " Protected Methods "
        //Send info to the Controller about needed animation
        protected void Animate() {

        }
    #endregion

    #region " Properties "
        public System.Collections.Generic.List<System.Windows.Forms.PictureBox > Pictures {
            get {
                System.Collections.Generic.List<System.Windows.Forms.PictureBox> pictures = new System.Collections.Generic.List<System.Windows.Forms.PictureBox>();
                foreach (Model.Stave.StaveObject sto in this.stave) {
                    System.Windows.Forms.PictureBox pbox = sto.Icon.Control;
                    pbox.Location = sto.Point;
                    pictures.Add(pbox);
                }
                return pictures;
            }
        }
    #endregion

    #region " Events "
        public void PanelClicked(int x, int y, Model.Icon ico, Model.Sound snd) {
            Model.Stave.StaveObject so = new Model.Stave.StaveObject(ico, x, y);
            // Put an image onto the panel
            this.stave.Add(so);
            
            
            // Save the X information to the Melody
            Model.SoundPosition sp = new SoundStudio.Model.SoundPosition(x);

            // Pub the melody onto list
            this.melody.Add(sp, snd);
        }
    #endregion
   }

}
