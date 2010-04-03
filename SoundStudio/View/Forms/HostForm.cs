using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.View.Forms
{
    public class HostForm : System.Windows.Forms.Form 
    {
        // Remember what was the last clicked button.
        protected View.PlayButton lastClickedButton;
        
        // Collection of all buttons
        protected System.Collections.ArrayList allButtons;

        // state controller
        protected Controller.StateController stateController;
        
        // mixer
        protected Controller.Mixer mixer;

        // stave controller
        protected Controller.StaveController staveController;


        public virtual void ClearStave()
        {
            throw new NotImplementedException();
        }

        public virtual void RefreshStave()
        {
            throw new NotImplementedException();
        }

        public virtual void MovePointer(int thisPosition)
        {
            throw new NotImplementedException();
        }
    }
}
