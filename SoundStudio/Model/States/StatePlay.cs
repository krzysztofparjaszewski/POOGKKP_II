using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model.States
{
    public class StatePlay : State 
    {
        protected StateReady stateReady;

        public StatePlay(Controller.StateController controller, StateError error, StateReady ready) {
            this.stateController = controller;
            this.stateError = error;
            this.stateReady = ready;
        }

        public override void ClearStaveClicked(SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {
            // do nothing
        }

        public override void PanelClicked(int x, int y, SoundStudio.View.PlayButton playButton, SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {
            // do nothing
        }

        public override void PlayClicked(Controller.Mixer mixer,  View.Forms.HostForm hostForm)
        { 
            // do nothing
        }

        public override void MusicEnded()
        {
            this.stateController.ChangeState(this.stateReady);
        }

    }
}
