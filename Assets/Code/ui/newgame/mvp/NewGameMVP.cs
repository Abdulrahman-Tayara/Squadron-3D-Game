using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.newgame {
    public interface NewGameView {
        void setUserAirplanes(List<Airplane> airplanes);

        void setEnvironments(List<Environment> environments);

    }

    public interface NewGamePresenter {
        void getUserAirplanes();

        void getEnvironments();

        void startNewGame(int airplaneId, int environemtId);
    }
}
