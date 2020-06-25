using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class EnemyFactory {

    public static Enemy createEnemyByDifficulty(Difficulty difficulty) {
        switch (difficulty) {
            case Difficulty.HIGH:
                return new Enemy(200f, 40f, 30f, 300f);
            case Difficulty.MEDIUM:
                return new Enemy(150f, 30f, 20f, 150f);
            case Difficulty.LOW:
            default:
                return new Enemy(100f, 20f, 10f, 75f);
        }
    }
}

