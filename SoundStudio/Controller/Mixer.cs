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

        public SoundStudio.Model.Melody melody;

        public Mixer() {
            this.melody = new Model.Melody();
        }

    #endregion

    #region "Protected Methods"


        //Send info to the Controller about needed animation
        protected void Animate() {

        }

        protected void Display() { 
        
        }
    #endregion


    }


}
