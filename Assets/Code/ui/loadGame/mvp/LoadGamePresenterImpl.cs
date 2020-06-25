using Assets.Code.ui.loadGame.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class LoadGamePresenterImpl : LoadGamePresenter {

    private LoadGameView view;
    private ISessionsRepository sessionsRepository;

    public LoadGamePresenterImpl(LoadGameView view, ISessionsRepository sessionsRepository) {
        this.view = view;
        this.sessionsRepository = sessionsRepository;
    }

    public void getSessions() {
        Task<List<Session>> task = sessionsRepository.getSessions();
        Task.WaitAll(task);
        view.setSessions(task.Result);
    }

    public void selectSession(Session session) {
        Task<bool> task = sessionsRepository.selectSession(session);
        Task.WaitAll(task);
        view.sessionSelected(session);
    }
}

