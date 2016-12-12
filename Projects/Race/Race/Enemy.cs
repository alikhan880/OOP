using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race {
    public class Enemy:Observer {


        public void Clear()
        {
            foreach ( Point p in Global.enemy ) {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
        }

        private void Draw() {
           
            foreach ( Point p in Global.enemy ) {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(p.S);
            }
        }

        public void Setup() {
            for ( int i = 20; i <= 24; i++ ) {
                Global.enemy.Add(new Point(i - 12, 20, '+'));
            }
            Global.enemy.Add(new Point(9, 19, '+'));
            Global.enemy.Add(new Point(9, 18, '+'));
            Global.enemy.Add(new Point(11, 19, '+'));
            Global.enemy.Add(new Point(11, 18, '+'));
            Global.enemy.Add(new Point(10, 17, '+'));

            for ( int i = 20; i <= 24; i++ ) {
                Global.enemy.Add(new Point(i, 5, '+'));
            }
            Global.enemy.Add(new Point(21, 4, '+'));
            Global.enemy.Add(new Point(21, 3, '+'));
            Global.enemy.Add(new Point(23, 4, '+'));
            Global.enemy.Add(new Point(23, 3, '+'));
            Global.enemy.Add(new Point(22, 2, '+'));

        }

        public void Move() {

            Clear();

            foreach ( Point p in Global.enemy ) {
                if ( p.Y < 29 ) {
                    p.Y++;
                }
                else {
                    p.Y -= 28;
                    Global.count++;
                    Scene.CheckLevel();
                }
            }

            Draw();
        }

        public static bool Collision() {
            foreach ( Point p in Global.enemy ) {
                foreach ( Point k in Global.body ) {
                    if ( p.Y == k.Y && p.X == k.X ) {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Update() {
            foreach ( Point p in Global.enemy ) {
                //Console.SetCursorPosition(p.X, p.Y);
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}
