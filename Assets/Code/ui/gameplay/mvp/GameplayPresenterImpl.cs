using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.ui.gameplay.mvp {
    class GameplayPresenterImpl : GameplayPresenter {

        private GameplayView view;
        private IAirplanesRepository airplanesRepository;
        private ISessionsRepository sessionRepository;

        public GameplayPresenterImpl(GameplayView view, IAirplanesRepository airplanesRepository, ISessionsRepository sessionRepository) {
            this.view = view;
            this.airplanesRepository = airplanesRepository;
            this.sessionRepository = sessionRepository;
        }

        public void getAirplane(int id) {
            Task<Airplane> task = airplanesRepository.getAirplaneById(id);
            Task.WaitAll(task);
            view.setAirplane(task.Result);
        }

        public void getCurrentSession() {
            Task<Session> task = sessionRepository.getSavedSession();
            Task.WaitAll(task);
            view.setCurrentSession(task.Result);
        }

        public void saveSession(Session session) {
            Task<bool> task = sessionRepository.saveSession(session);
            Task.WaitAll(task);
            if (task.Result)
                view.sessoinSaved();
        }
    }
}
