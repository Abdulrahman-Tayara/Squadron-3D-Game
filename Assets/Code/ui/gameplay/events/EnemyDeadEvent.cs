using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class EnemyDeadEvent : GameEvent {
    public Enemy enemy { private set; get; }

    public EnemyDeadEvent(Enemy enemy) {
        this.enemy = enemy;
    }
}

