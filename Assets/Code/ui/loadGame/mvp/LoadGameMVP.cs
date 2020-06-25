using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.loadGame.mvp {
    public interface LoadGameView {
        void setSessions(List<Session> sessions);

        void sessionSelected(Session session);
    }

    public interface LoadGamePresenter {
        void getSessions();

        void selectSession(Session session);
    }

}
