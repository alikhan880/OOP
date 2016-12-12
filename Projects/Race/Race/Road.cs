using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race {
    public class Road : Observer {
        List<Point> roads = new List<Point>();

        public void Setup() {
            for ( int i = 0; i < 30; i++ ) {
                roads.Add(new Point(0, i, '#'));
                roads.Add(new Point(30, i, '#'));
            }
        }


        public void Draw() {
            foreach( Point rr in roads ) {
                Console.SetCursorPosition(rr.X, rr.Y);
                Console.Write(rr.S);
            }
        }

        public override void Update() {
            foreach ( Point p in roads ) {
                Console.SetCursorPosition(p.X, p.Y);
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }

    }
}
