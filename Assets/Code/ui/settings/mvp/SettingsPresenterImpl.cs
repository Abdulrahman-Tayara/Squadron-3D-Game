using Assets.Code.ui.settings.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SettingsPresenterImpl : SettingsPresenter {

    private SettingsView view;
    private IGamePlayRepository gamePlayRepository;
    private ISessionsRepository sessionsRepository;
    private IAuthRepository authRepository;

    public SettingsPresenterImpl(SettingsView view, IGamePlayRepository gamePlayRepository, ISessionsRepository sessionsRepository, IAuthRepository authRepository) {
        this.view = view;
        this.gamePlayRepository = gamePlayRepository;
        this.sessionsRepository = sessionsRepository;
        this.authRepository = authRepository;
    }

    public void changeDifficulty(Difficulty difficulty) {
        gamePlayRepository.changeDifficulty(difficulty);
    }

    public void getDifficulties() {
        Task<List<Difficulty>> task = gamePlayRepository.getDifficulties();
        Difficulty savedDifficulty = gamePlayRepository.getSavedDifficulty();
        Task.WaitAll(task);
        view.setDifficulties(task.Result, savedDifficulty);
    }

    public void logout() {
        Task<bool> clearSessionsTask = sessionsRepository.clearAllSesstions();
        clearSessionsTask.Wait();
        if (authRepository.logout())
            view.setLoggedOut();
    }
}

