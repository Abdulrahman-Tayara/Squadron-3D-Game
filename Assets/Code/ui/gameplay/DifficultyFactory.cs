using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DifficultyFactory {
    public static Difficulty getDifficulty(int score) {
        if (score >= 17) {
            return Difficulty.HIGH;
        } else if (score >= 10) {
            return Difficulty.MEDIUM;
        } else
            return Difficulty.LOW;
    }
}

