using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    // Describes position of a sound in Melody
    public class SoundPosition : System.Collections.Generic.Comparer<SoundPosition>
    {

    #region " Properties "

        // position in the melody
        private double position;

    #endregion
   
    #region " Overrides "
    
        public override int Compare(SoundPosition x, SoundPosition y)
        {
            if (x.Position > y.Position) return 1;
            else if (x.Position.Equals(y.Position)) return 0;
            else return -1;
        }
    
    #endregion

    #region " Fields "


        protected double Position
        {
            get { 
                return position; 
            }
            set { 
                position = value; 
            }

        }

    #endregion

    }
}
