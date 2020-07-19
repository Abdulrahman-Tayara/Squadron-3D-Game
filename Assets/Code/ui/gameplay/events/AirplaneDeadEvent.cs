using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AirplaneDeadEvent : GameEvent {
    public Airplane airplane;

    public AirplaneDeadEvent(Airplane airplane) {
        this.airplane = airplane;
    }
}

