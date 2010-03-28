using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoundStudio.Model
{
    public class Stave : System.Collections.Generic.List<Stave.StaveObject>
    {
        public struct StaveObject {
            Model.Icon icon;
            int x, y;
            public StaveObject(Model.Icon _icon, int _x, int _y) {
                this.icon = _icon;
                this.x = _x;
                this.y = _y;
            }
            public Model.Icon Icon {
                get {
                    return this.icon;
                }
            }

            public System.Drawing.Point Point {
                get {
                    System.Drawing.Point point = new System.Drawing.Point(this.x, this.y);
                    return point;
                }
            }
        }
    
    }
}
