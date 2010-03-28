using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model.States
{
    public class StateReady : State 
    {
        protected StatePlay statePlay;

        public StateReady(Controller.StateController controller, StateError error) {
            this.stateController = controller;
            this.stateError = error;
            this.statePlay = new StatePlay(controller, error, this);
        }

        public override void ClearStaveClicked(SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {
            mixer.melody.Clear();
            mixer.stave.Clear();
            hostForm.ClearStave();
        }

        public override void PanelClicked(int x, int y, SoundStudio.View.PlayButton playButton, SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm)
        {
            mixer.PanelClicked(x, y, playButton.Icon, playButton.Sound);
            hostForm.RefreshStave();
        }

        public override void PlayClicked(Controller.Mixer mixer, View.Forms.HostForm hostForm)
        {
            this.stateController.ChangeState(this.statePlay);
            mixer.Play(this.stateController, hostForm);
        }

        public override void MusicEnded()
        {
            this.stateController.ChangeState(this.stateError);
        }
    }
}
