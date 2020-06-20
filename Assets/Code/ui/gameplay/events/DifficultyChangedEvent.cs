using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class DifficultyChangedEvent : GameEvent {
    public Difficulty difficulty;

    public DifficultyChangedEvent(Difficulty difficulty) {
        this.difficulty = difficulty;
    }
}

