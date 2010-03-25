using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    // Collection of sounds
    public class Melody : System.Collections.Generic.SortedList<SoundPosition, Sound>
    {
    #region "Init & Protected"

        // Describes melody duration
        protected double duration;


        public void Init() { 
        
        }
    #endregion

    #region "Public Methods"
        

        // Add a sound to melody
        public virtual void Add(SoundPosition position, Sound sound ) {
            base.Add(position, sound);
        }


        // Errase the whole melody
        public void ClearAll() {
            base.Clear();
        
        }

        
    #endregion

    }
}
