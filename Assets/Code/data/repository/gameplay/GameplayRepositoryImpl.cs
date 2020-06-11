

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

class GameplayRepositoryImpl : IGameplayRepository {

    private static GameplayRepositoryImpl INSTANCE;

    private ICahceProvider cahce;
    private ILocalStorageProvider localStorageProvider;

    public static GameplayRepositoryImpl getInstance(ICahceProvider cahce, ILocalStorageProvider localStorageProvider) {
        if (INSTANCE == null)
            INSTANCE = new GameplayRepositoryImpl(cahce, localStorageProvider);
        return INSTANCE;
    }

    private GameplayRepositoryImpl(ICahceProvider cahce, ILocalStorageProvider localStorageProvider) {
        this.cahce = cahce;
        this.localStorageProvider = localStorageProvider;
    }

    // Return saved session but if there is no session then return a new one
    public Session getSavedSession() {
        Session session = cahce.getObject<Session>(CacheKeys.SAVED_SESSION);
        return session != null ? session : new Session(cahce.getInt(CacheKeys.AIRPLANE_ID, 1), cahce.getInt(CacheKeys.ENVIRONMENT_ID, 1), "new sesstion", new GameState(int.MaxValue, cahce.getInt(CacheKeys.DIFFICULTY), 0, 0));
    }

    public Task<Airplane> getAirplaneById(int id) {
        return Task.Run<Airplane>(() => {
            String data = localStorageProvider.readFile(ResourcesPath.AIRPLANES_FILE);
            List<Airplane> airplanes = JsonMapper.getInstance().fromJsonArray<Airplane>(data);
            foreach (Airplane airplane in airplanes) {
                if (airplane.id == id) {
                    return airplane;
                }
            }
            return null;
        });
    }
}

