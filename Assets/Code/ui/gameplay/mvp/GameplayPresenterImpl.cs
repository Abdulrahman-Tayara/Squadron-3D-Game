using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ui.gameplay.mvp {
    class GameplayPresenterImpl : GameplayPresenter {

        private GameplayView view;
        private IGameplayRepository repository;
        public GameplayPresenterImpl(GameplayView view, IGameplayRepository repository) {
            this.view = view;
            this.repository = repository;
        }

        public void getAirplane(int id) {
            Task<Airplane> task = repository.getAirplaneById(id);
            Task.WaitAll(task);
            view.setAirplane(task.Result);
        }

        public void getCurrentSession() {
            Session session = repository.getSavedSession();
            view.setCurrentSession(session);
        }
    }
}
