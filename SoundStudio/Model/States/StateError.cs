using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model.States
{
    public class StateError : State
    {
        public StateError(Controller.StateController controller)
        {
            this.stateController = controller;
        }
        public override void ClearStaveClicked(Controller.StaveController staveController, SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm) { 
        
        }

        public override void PanelClicked(int x, int y, SoundStudio.View.PlayButton playButton, Controller.StaveController staveController, SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {
            // do nothing
        }

        public override void PlayClicked(Controller.Mixer mixer, View.Forms.HostForm hostForm)
        {
            // do nothing
        }

        public override void MusicEnded()
        {
            // do nothing
        }
    }
}
