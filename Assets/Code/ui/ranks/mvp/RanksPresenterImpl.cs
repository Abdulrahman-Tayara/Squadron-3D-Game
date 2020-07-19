using Assets.Code.ui.ranks.mvp;
using System;
using System.Collections.Generic;

using System.Threading.Tasks;

public class RanksPresenterImpl : RanksPresenter {

    private RanksView view;
    private IRanksRepository ranksRepository;
    private IAuthRepository authRepository;

    public RanksPresenterImpl(RanksView view, IRanksRepository ranksRepository, IAuthRepository authRepository) {
        this.view = view;
        this.ranksRepository = ranksRepository;
        this.authRepository = authRepository;
    }

    public void getRanks() {
        Task<List<Rank>> ranksTask = ranksRepository.getRanks();
        ranksTask.GetAwaiter().OnCompleted(() => {
            if (ranksTask != null && ranksTask.Result != null) {
                int userId = authRepository.getUser().id;
                Rank userRank = ranksTask.Result.Find(rank => rank.userId == userId);
                view.setRanks(ranksTask.Result, userRank);
            }
        });
    }
}

