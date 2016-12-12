using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race {
    public class Point {
        char sign;
        int x;
        int y;
        public int X {get {return x;} set {x = value;}}
        public int Y {get {return y;} set {y = value;}}
        public char S {get {return sign;}}
        public Point( int x, int y, char sign ) {
            this.x = x;
            this.y = y;
            this.sign = sign;
        }
    }
}
