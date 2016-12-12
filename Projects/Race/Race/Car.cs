using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race {
    public class Car:Observer {

        public void Clear() {
            foreach ( Point p in Global.body ) {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
        }
        public virtual void Draw() {
            Clear();
            foreach ( Point p in Global.body ) {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(p.S);
            }
        }

        public virtual void Setup() {

        }

        public virtual void Move(ConsoleKey e) {
            Clear();
            if ( e == ConsoleKey.UpArrow ) {
                if ( Global.Speed - 10 > 0 ) {
                    Global.Speed -= 10;
                }
            }

            else if ( e == ConsoleKey.DownArrow ) {
                if ( Global.Speed + 10 < Global.minSpeed ) {
                    Global.Speed += 10;
                }
            }

            else if ( e == ConsoleKey.LeftArrow ) {
                foreach ( Point p in Global.body ) {
                    if ( p.X - 12 > 0 ) {
                        p.X -= 12;
                    }
                }
            }

            else if ( e == ConsoleKey.RightArrow ) {
                foreach ( Point p in Global.body ) {
                    if ( p.X + 12 < 29 ) {
                        p.X += 12;
                    }
                }
            }
        }

        public override void Update() {
            foreach ( Point p in Global.body ) {
                //Console.SetCursorPosition(p.X, p.Y);
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}
