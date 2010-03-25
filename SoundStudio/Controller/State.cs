using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Controller
{
    public class State
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
        protected States currentState;

        public State() {
            this.currentState = States.Undefined;
        }

    #endregion
    
    #region " Fields "
        
        public States CurrentState
        {
            get { 
                return currentState; 
            }
            set { 
                if (value.Equals(this.currentState)) return;

                if (this.currentState.Equals(States.Error)) {
                    return;
                } else {
                    this.currentState = value;
                }
            }
        }
    
    #endregion 

    }
}
