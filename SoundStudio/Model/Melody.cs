using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    // Collection of sounds
    public class Melody : SortedDictionary <SoundPosition, Sound>
    {

    #region "Init & Protected"
        public void Init() { 
        
        }
    #endregion

    #region "Public Methods"
        
        // Add a sound to melody
        public new void Add(SoundPosition soundPosition, Sound sound) {
            base.Add(soundPosition, sound);
        }

        // Errase the whole melody
        public void ClearAll() {
            base.Clear();        
        }

    #endregion

    }
}
