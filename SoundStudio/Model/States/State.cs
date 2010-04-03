using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model.States
{
    // Must be implemented
    public abstract class State
    {
        protected Controller.StateController stateController;
        protected StateError stateError;

        public abstract void ClearStaveClicked(Controller.StaveController staveController, Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm);

        public abstract void PanelClicked(int x, int y, SoundStudio.View.PlayButton playButton, Controller.StaveController staveController, SoundStudio.Controller.Mixer mixer, SoundStudio.View.Forms.HostForm hostForm);

        public abstract void PlayClicked(Controller.Mixer mixer, View.Forms.HostForm hostForm);

        public abstract void MusicEnded();

        
        
    }
}
