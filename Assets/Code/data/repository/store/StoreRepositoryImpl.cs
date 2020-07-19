using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class StoreRepositoryImpl : IStoreRepository {

    private static StoreRepositoryImpl instance;

    private IApiProvider apiProvider;
    private ICacheProvider cache;
    private ILocalStorageProvider localStorage;
    private JsonMapper jsonMapper;

    private StoreRepositoryImpl(IApiProvider apiProvider, ICacheProvider cache, ILocalStorageProvider localStorage, JsonMapper jsonMapper) {
        this.apiProvider = apiProvider;
        this.cache = cache;
        this.localStorage = localStorage;
        this.jsonMapper = jsonMapper;
    }

    public static StoreRepositoryImpl getInstance(IApiProvider apiProvider, ICacheProvider cache, ILocalStorageProvider localStorage, JsonMapper jsonMapper) {
        if (instance == null)
            instance = new StoreRepositoryImpl(apiProvider, cache, localStorage, jsonMapper);
        return instance;
    }


    public Task<List<Airplane>> getStoreAirplanes() {
        User user = cache.getObject<User>(CacheKeys.USER);
        return Task.Run(() => {
            string jsonData = localStorage.readFile(ResourcesPath.AIRPLANES_FILE);
            List<Airplane> airplanes = jsonMapper.fromJsonArray<Airplane>(jsonData);
            if (user != null)
                airplanes.ForEach(airplane => {
                    airplane.userHasIt = user.airplanesId.Contains(airplane.id);
                });
            return airplanes;
        });
    }


    public Task<bool> buyAirplane(Airplane airplane) {
        User user = cache.getObject<User>(CacheKeys.USER);
        if (user == null)
            return Task.Run(() => false);
        Task<BuyAirplaneResponse> buyTask = apiProvider.post<BuyAirplaneResponse>(
            ApiEndPoints.BUY_AIRPLANE,
            new BuyAirplaneRequest(user.id, airplane.id, airplane.price)
        );
        buyTask.GetAwaiter().OnCompleted(() => {
            if (buyTask != null && buyTask.Result != null && buyTask.Result.success) {
                cache.putObject(CacheKeys.USER, buyTask.Result.data.user);
            }
        });
        return buyTask.ContinueWith<bool>(task => task != null && task.Result != null && task.Result.success);
    }
}

