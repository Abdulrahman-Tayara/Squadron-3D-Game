using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AirplanesRepositoryImpl : IAirplanesRepository {

    private static AirplanesRepositoryImpl INSTANCE;

    private ILocalStorageProvider localStorage;
    private ICacheProvider cache;
    private JsonMapper jsonMapper;

    private AirplanesRepositoryImpl(ILocalStorageProvider localStorage, ICacheProvider cache, JsonMapper jsonMapper) {
        this.localStorage = localStorage;
        this.cache = cache;
        this.jsonMapper = jsonMapper;
    }

    public static AirplanesRepositoryImpl getInstance(ILocalStorageProvider localStorage, ICacheProvider cache, JsonMapper jsonMapper) {
        if (INSTANCE == null)
            INSTANCE = new AirplanesRepositoryImpl(localStorage, cache, jsonMapper);
        return INSTANCE;
    }
    public Task<Airplane> getAirplaneById(int id) {
        return Task.Run(() => {
            string data = localStorage.readFile(ResourcesPath.AIRPLANES_FILE);
            List<Airplane> airplanes = jsonMapper.fromJsonArray<Airplane>(data);
            return airplanes.Find(airplane => airplane.id == id);
        });
    }

    public Task<List<Airplane>> getAirplanes() {
        return Task.Run(() => {
            string data = localStorage.readFile(ResourcesPath.AIRPLANES_FILE);
            List<Airplane> airplanes = jsonMapper.fromJsonArray<Airplane>(data);
            return airplanes;
        });
    }

    public Task<List<Airplane>> getAirplanesByIds(params int[] ids) {
        return getAirplanes().ContinueWith(task => {
            if (task != null && task.Result != null) {
                List<Airplane> airplanes = new List<Airplane>();
                airplanes.AddRange(
                    task.Result.FindAll(
                        airplane => ids.Contains(airplane.id)
                    )
                );
                return airplanes;
            }
            return null;
        });
    }

    public Task<List<Airplane>> getUserAirplanes() {
        User user = cache.getObject<User>(CacheKeys.USER);
        if (user == null)
            return getAirplanesByIds(1);
        return getAirplanesByIds(user.airplanesId.ToArray());
    }
}

