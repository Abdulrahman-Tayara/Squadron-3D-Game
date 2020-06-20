using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[Serializable]
public class GameState {
    public float health;
    public int difficultyLevel;
    public int coins;
    public int score;

    public GameState(float health, int difficultyLevel, int coins, int score) {
        this.health = health;
        this.difficultyLevel = difficultyLevel;
        this.coins = coins;
        this.score = score;
    }
}

