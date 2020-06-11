using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.gameplay.mvp {
    public interface GameplayView {

        void setCurrentSession(Session session);

        void setAirplane(Airplane airplane);
    }

    public interface GameplayPresenter {
        void getCurrentSession();


        void getAirplane(int id);
    }
}
