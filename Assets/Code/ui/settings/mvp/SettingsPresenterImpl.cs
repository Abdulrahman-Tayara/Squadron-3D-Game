using Assets.Code.ui.settings.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SettingsPresenterImpl : SettingsPresenter {

    private SettingsView view;
    private IGamePlayRepository gamePlayRepository;
    public SettingsPresenterImpl(SettingsView view, IGamePlayRepository gamePlayRepository) {
        this.view = view;
        this.gamePlayRepository = gamePlayRepository;
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
}

