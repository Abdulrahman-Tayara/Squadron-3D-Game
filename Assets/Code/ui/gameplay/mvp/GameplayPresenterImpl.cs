using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ui.gameplay.mvp {
    class GameplayPresenterImpl : GameplayPresenter {

        private GameplayView view;
        private IGamePlayRepository gamePlayRepository;
        private IAirplanesRepository airplanesRepository;
        private ISessionsRepository sessionRepository;

        private bool isLoading = false;

        public GameplayPresenterImpl(GameplayView view, IGamePlayRepository gamePlayRepository, IAirplanesRepository airplanesRepository, ISessionsRepository sessionRepository) {
            this.view = view;
            this.gamePlayRepository = gamePlayRepository;
            this.airplanesRepository = airplanesRepository;
            this.sessionRepository = sessionRepository;
        }

        public void getAirplane(int id) {
            Task<Airplane> task = airplanesRepository.getAirplaneById(id);
            task.Wait();
            view.setAirplane(task.Result);
        }

        public void getCurrentSession() {
            Task<Session> task = sessionRepository.getSavedSession();
            task.Wait();
            view.setCurrentSession(task.Result);
        }

        public void saveSession(Session session) {
            Task<bool> task = sessionRepository.saveSession(session);
            task.Wait();
            if (task.Result)
                view.sessoinSaved();
        }

        public void update(int score, int coins) {
            if (isLoading)
                return;
            isLoading = true;
            Task<bool> task = gamePlayRepository.update(score, coins);
            task.GetAwaiter().OnCompleted(() => {
                isLoading = false;
                if (task != null && task.Result) {
                    view.setUpdated(score, coins);
                } else {
                    view.setErrorConnection();
                }
            });
        }
    }
}
