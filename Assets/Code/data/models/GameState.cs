using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class GameState {
    public int difficultyLevel;
    public int health;
    public int coins;
    public int score;

    public GameState(int difficultyLevel, int health, int coins, int score) {
        this.difficultyLevel = difficultyLevel;
        this.health = health;
        this.coins = coins;
        this.score = score;
    }
}

