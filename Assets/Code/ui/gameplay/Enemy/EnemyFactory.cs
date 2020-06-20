using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class EnemyFactory {

    public static Enemy createEnemyByDifficulty(Difficulty difficulty) {
        switch (difficulty) {
            case Difficulty.HIGH:
                return new Enemy(200f, 75f, 75f, 100f);
            case Difficulty.MEDIUM:
                return new Enemy(150f, 50f, 40f, 75f);
            case Difficulty.LOW:
            default:
                return new Enemy(100f, 30f, 25f, 50f);
        }
    }
}

