using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model.States
{
    public class StateInit : State 
    {
        protected StateReady stateReady;
        
        public StateInit(Controller.StateController controller) {
            this.stateController = controller;
            this.stateError = new StateError(controller);
            this.stateReady = new StateReady(controller, this.stateError);    
        }

        public override void ClearStaveClicked(Controller.StaveController staveController, Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {

        }

        public override void PanelClicked(int x, int y, SoundStudio.View.PlayButton playButton, Controller.StaveController staveController, Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {
            this.stateController.ChangeState(this.stateReady );
            this.stateReady.PanelClicked(x, y, playButton, staveController, mixer, hostForm);
        }

        public override void PlayClicked(Controller.Mixer mixer, View.Forms.HostForm hostForm)
        {
            this.stateController.ChangeState(this.stateReady);
            this.stateReady.PlayClicked(mixer, hostForm);

        }

        public override void MusicEnded()
        {
            this.stateController.ChangeState(this.stateReady);


        }
    }
}
