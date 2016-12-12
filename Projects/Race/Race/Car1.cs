using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race {
    public class Car1 : Car {

        public override void Setup() {
            for ( int i = 20; i <= 24; i++ ) {
                Global.body.Add(new Point(i, 26, '*'));
            }
            Global.body.Add(new Point(21, 25, '*'));
            Global.body.Add(new Point(21, 24, '*'));
            Global.body.Add(new Point(23, 25, '*'));
            Global.body.Add(new Point(23, 24, '*'));
            Global.body.Add(new Point(22, 23, '*'));

        }

    }
}
