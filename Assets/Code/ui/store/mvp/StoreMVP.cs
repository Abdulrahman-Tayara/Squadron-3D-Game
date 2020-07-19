using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.store.mvp {
    public interface StoreView {
        void setCoins(int coins);
        void setAirplanes(List<Airplane> airplanes);
    }

    public interface StorePresenter {
        // Returns the airplanes that the user didn't buy it
        void getAirplanes();

        void getUserCoins();

        void buyAirplane(Airplane airplane);
    }
}
