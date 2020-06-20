using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class GamePlayRepositoryImpl : IGamePlayRepository {

    private static GamePlayRepositoryImpl INSTANCE;

    private ICacheProvider cache;

    private GamePlayRepositoryImpl(ICacheProvider cache) {
        this.cache = cache;
    }

    public static GamePlayRepositoryImpl getInstance(ICacheProvider cache) {
        if (INSTANCE == null)
            INSTANCE = new GamePlayRepositoryImpl(cache);
        return INSTANCE;
    }

    public void startNewGame(int airplaneId, int environemtId) {
        cache.putInt(CacheKeys.AIRPLANE_ID, airplaneId);
        cache.putInt(CacheKeys.ENVIRONMENT_ID, environemtId);
        cache.deleteKey(CacheKeys.SAVED_SESSION_ID);
    }

    public Task<List<Difficulty>> getDifficulties() {
        return Task.Run(() => {
            return Enum.GetValues(typeof(Difficulty)).OfType<Difficulty>().ToList();
        });
    }

    public void changeDifficulty(Difficulty difficulty) {
        cache.putInt(CacheKeys.DIFFICULTY, (int) difficulty);
    }

    public Difficulty getSavedDifficulty() {
        int difficultyValue = cache.getInt(CacheKeys.DIFFICULTY, 1);
        return (Difficulty) difficultyValue;
    }
}

