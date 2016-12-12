using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race {
    public class Car2 : Car {

        public override void Setup() {
            Global.body.Add(new Point(21, 25, '*'));
            Global.body.Add(new Point(21, 24, '*'));
            Global.body.Add(new Point(21, 23, '*'));
            Global.body.Add(new Point(23, 25, '*'));
            Global.body.Add(new Point(23, 24, '*'));
            Global.body.Add(new Point(23, 23, '*'));
            Global.body.Add(new Point(22, 23, '*'));
            Global.body.Add(new Point(20, 26, '('));
            Global.body.Add(new Point(21, 26, '#'));
            Global.body.Add(new Point(22, 26, '#'));
            Global.body.Add(new Point(23, 26, '#'));
            Global.body.Add(new Point(24, 26, ')'));
        }

    }
}
