using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface IGamePlayRepository {

    void startNewGame(int airplaneId, int environemtId);

    Task<List<Difficulty>> getDifficulties();

    void changeDifficulty(Difficulty difficulty);

    Difficulty getSavedDifficulty();

    Task<bool> update(int newScore, int newCoins);

}

