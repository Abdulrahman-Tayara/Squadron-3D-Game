using Assets.Code.ui.store.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class StorePresenterImpl : StorePresenter {
    
    private StoreView view;
    private IAuthRepository authRepository;
    private IStoreRepository storeRepository;

    private bool isLoading = false;

    public StorePresenterImpl(StoreView view, IAuthRepository authRepository, IStoreRepository storeRepository) {
        this.view = view;
        this.authRepository = authRepository;
        this.storeRepository = storeRepository;
    }

    public void buyAirplane(Airplane airplane) {
        if (airplane == null)
            return;
        isLoading = true;
        Task<bool> task = storeRepository.buyAirplane(airplane);
        task.GetAwaiter().OnCompleted(() => {
            isLoading = false;
            if (task != null && task.Result) {
                getUserCoins();
                getAirplanes();
            }
        });
    }

    public void getAirplanes() {
        Task<List<Airplane>> task = storeRepository.getStoreAirplanes();
        task.GetAwaiter().OnCompleted(() => {
            if (task != null && task.Result != null) {
                view.setAirplanes(task.Result);
            }
        });
    }

    public void getUserCoins() {
        User user = authRepository.getUser();
        if (user != null) {
            view.setCoins(user.coins);
        }
    }
}

