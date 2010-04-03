using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Controller
{
    public class StateController
    {

    #region " State Definitions "
        public enum States {
            // only created
            Undefined,

            // ready for user interaction
            Ready,

            // Currently a melody is being played - stop all interactions
            Playing, 

            // An error occured, sorry :)
            Error, 
        }
    #endregion

    #region " Properties, Init "

        // current state
        protected Model.States.State currentState;

        public StateController() {
            this.currentState = new Model.States.StateInit(this);
        }

    #endregion

    #region " Public Methods "
        public void Start() { 
        
        }
        public void ChangeState(Model.States.State changeToThisState) {
            this.currentState = changeToThisState;
        }
        public void ClearStaveClicked(StaveController staveController, Mixer mixer, View.Forms.HostForm hostForm)
        {
            this.currentState.ClearStaveClicked(staveController, mixer, hostForm);
        }
        public void PanelClicked(int x, int y, SoundStudio.View.PlayButton playButton, StaveController staveController, Mixer mixer,SoundStudio.View.Forms.HostForm hostForm)
        {
            this.currentState.PanelClicked(x, y, playButton,staveController, mixer, hostForm);
        }
        public void PlayClicked(Controller.Mixer mixer, View.Forms.HostForm hostForm)
        {
            this.currentState.PlayClicked(mixer, hostForm);
        }
        public void MusicEnded()
        {
            this.currentState.MusicEnded();
        }
        

    #endregion

    #region " Fields "

        public Model.States.State CurrentState
        {
            get { 
                return currentState; 
            }
            set {
                if (value.GetType().Equals(typeof(Model.States.StateError))) {
                    return;
                } else {
                    this.currentState = value;
                }
            }
        }
    
    #endregion     
        
    }
}
