using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.ui.settings.mvp {
    
    public interface SettingsPresenter {
        void getDifficulties();

        void changeDifficulty(Difficulty difficulty);

        void logout();
    }

    public interface SettingsView {
        void setDifficulties(List<Difficulty> difficulties, Difficulty savedDifficulty);

        void setLoggedOut();
    }
}
