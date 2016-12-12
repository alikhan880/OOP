using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Race {
    public class Scene {


        private static List<Observer> o = new List<Observer>();
        public void Attach( Observer element ) {
            o.Add(element);
        }

        public static void Notify() {
            foreach ( Observer p in o ) {
                p.Update();
            }
        }


        static Road road;
        static Car car;

        static Enemy enemy;

        public void Setup() {
            Console.WriteLine("Choose car: 1 or 2");

            int choice = int.Parse(Console.ReadLine());
            if ( choice == 1 ) {
                car = new Car1();
            }
            else if ( choice == 2 ) {
                car = new Car2();
            }
            road = new Road();
            enemy = new Enemy();

            Attach(car);
            Attach(road);
            Attach(enemy);
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowWidth = 31;
            Console.WindowHeight = 30;

            road.Setup();
            car.Setup();
            enemy.Setup();
        }

        public void Run() {
            ThreadStart ts = new ThreadStart(tick);
            Thread t = new Thread(ts);
            t.Start();
            while ( true ) {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch ( pressedKey.Key ) {
                    case ConsoleKey.UpArrow:
                        car.Move(ConsoleKey.UpArrow);
                        break;
                    case ConsoleKey.DownArrow:
                        car.Move(ConsoleKey.DownArrow);
                        break;
                    case ConsoleKey.LeftArrow:
                        car.Move(ConsoleKey.LeftArrow);
                        break;
                    case ConsoleKey.RightArrow:
                        car.Move(ConsoleKey.RightArrow);
                        break;
                }
            }


        }

        private static void tick() {
            while ( true ) {

                Thread.Sleep(Global.Speed);
                Console.SetCursorPosition(20, 0);
                Console.Write("       ");
                Console.SetCursorPosition(20, 0);
                Console.Write("Level " + Global.level);
                if ( Enemy.Collision() ) {
                    Console.Clear();
                    Console.SetCursorPosition(12, 15);
                    Console.Write("Game Over");
                    break;
                }
                else if ( Global.level == 6 ) {
                    //Console.Clear();
                    Console.SetCursorPosition(12, 15);
                    Console.Write("You win");
                    break;
                }

                car.Draw();
                enemy.Move();
                road.Draw();
                
            }
        }

        public static void CheckLevel() {
            if ( Global.count >= 100 ) {
                Global.level++;
                Console.Clear();
                if ( Global.level == 3 ) {
                    Notify();
                }
                if ( Global.minSpeed - 15 > 0 ) {
                    Global.minSpeed -= 15;
                    Global.Speed = Global.minSpeed;
                    Global.count = 0;
                }
            }
        }
    }

    
}
