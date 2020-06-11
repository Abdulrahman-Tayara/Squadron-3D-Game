using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusProject.eventbus {
    public delegate void Observer<in T>(T value);
}
