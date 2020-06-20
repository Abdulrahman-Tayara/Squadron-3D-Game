using Assets.Code.ui.newgame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NewGamePresenterImpl : NewGamePresenter {

    private NewGameView view;
    private IAirplanesRepository airplanesRepository;
    private IEnvironmentRepository environmentRepository;
    private IGamePlayRepository gamePlayRepository;

    public NewGamePresenterImpl(NewGameView view, IAirplanesRepository airplanesRepository, IEnvironmentRepository environmentRepository, IGamePlayRepository gamePlayRepository) {
        this.view = view;
        this.airplanesRepository = airplanesRepository;
        this.environmentRepository = environmentRepository;
        this.gamePlayRepository = gamePlayRepository;
    }

    public void getEnvironments() {
        Task<List<Environment>> task = environmentRepository.getEnvironments();
        Task.WaitAll(task);
        view.setEnvironments(task.Result);
    }

    public void getUserAirplanes() {
        Task<List<Airplane>> task = airplanesRepository.getAirplanes();
        Task.WaitAll(task);
        view.setUserAirplanes(task.Result);
    }

    public void startNewGame(int airplaneId, int environemtId) {
        gamePlayRepository.startNewGame(airplaneId, environemtId);
    }
}

