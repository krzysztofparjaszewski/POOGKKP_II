using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SoundStudio;

namespace SoundStudio.Controller
{
    
    public class Mixer
    {

    #region " Properties, Init "
        
        public System.Media.SoundPlayer soundPlayer;

        public Model.Melody melody;

        public Mixer() {
            this.melody = new Model.Melody();
        }

    #endregion

    #region " Public Methods "
        public void Play(StateController stateController, View.Forms.HostForm hostForm)
        {
            int noSounds = this.melody.Count,
                    skip = 0,
                maxPixel = 566,
                // we are sleeping a 10 seconds daily :)
               sleepTime = 4000 / maxPixel;

            for (int pixel = 0; pixel < maxPixel; pixel++) {    
                // this is the position of next pair
                while (skip < noSounds) {
                    KeyValuePair<Model.SoundPosition, Model.Sound> pair = this.melody.Skip(skip).First();
                    if (pair.Key.Position.Equals(pixel)) {
                        pair.Value.SoundPlayer.Play();
                        skip++;
                    } else {
                        break;
                    }
                }
                hostForm.MovePointer(pixel);
                System.Threading.Thread.Sleep(sleepTime);
            }
            stateController.MusicEnded();
        }
    #endregion

    #region " Protected Methods "
        //Send info to the Controller about needed animation
        protected void Animate() {

        }
    #endregion


   
   }

}
