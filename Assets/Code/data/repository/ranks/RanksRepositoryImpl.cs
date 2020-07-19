using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RanksRepositoryImpl : IRanksRepository {

    private static RanksRepositoryImpl instance;

    private IApiProvider apiProvider;

    private RanksRepositoryImpl(IApiProvider apiProvider) {
        this.apiProvider = apiProvider;
    }

    public static RanksRepositoryImpl getInstance(IApiProvider apiProvider) {
        if (instance == null)
            instance = new RanksRepositoryImpl(apiProvider);
        return instance;
    }

    public Task<List<Rank>> getRanks() {
        Task<GetRanksResponse> task = apiProvider.get<GetRanksResponse>(ApiEndPoints.GET_RANKS);
        return task.ContinueWith(responseTask => {
            if (responseTask != null && responseTask.Result != null && responseTask.Result.success) {
                List<Rank> ranks = responseTask.Result.data.ranks;
                for (int i = 0; i < ranks.Count; ++i) {
                    ranks[i].order = i + 1;
                }
                return ranks;
            }
            return null;
        });
    }
}

