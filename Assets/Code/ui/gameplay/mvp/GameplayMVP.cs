﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.gameplay.mvp {
    public interface GameplayView {

        void sessoinSaved();

        void setCurrentSession(Session session);

        void setAirplane(Airplane airplane);

        void setUpdated(int score, int coins);

        void setErrorConnection();
    }

    public interface GameplayPresenter {
        void getCurrentSession();

        void getAirplane(int id);

        void saveSession(Session session);

        void update(int score, int coins);
    }
}
