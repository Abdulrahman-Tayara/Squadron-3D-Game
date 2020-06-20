using Assets.Code.ui.gameplay.mvp;
using Assets.Code.ui.newgame;
using Assets.Code.ui.settings.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.utils {
    public class Injector {
        public static SettingsPresenter injectSettingsPresenter(SettingsView view) {
            return new SettingsPresenterImpl(view, injectGamePlayRepository());
        }
        public static NewGamePresenter injectNewGamePresenter(NewGameView view) {
            return new NewGamePresenterImpl(view, injectAirplanesRepository(), injectEnvironmentRepository(), injectGamePlayRepository());
        }

        public static GameplayPresenter injectGameplayPresenter(GameplayView view) {
            return new GameplayPresenterImpl(view, injectAirplanesRepository(), injectSessionRepository());
        }

        public static IGamePlayRepository injectGamePlayRepository() {
            return GamePlayRepositoryImpl.getInstance(injectCahceProvider());
        }

        public static IEnvironmentRepository injectEnvironmentRepository() {
            return EnvironemtRepositoryImpl.getInstance(injectLocalStorageProivder(), injectJsonMapper());
        }

        public static IAirplanesRepository injectAirplanesRepository() {
            return AirplanesRepositoryImpl.getInstance(injectLocalStorageProivder(), injectCahceProvider(), injectJsonMapper());
        }

        public static ISessionsRepository injectSessionRepository() {
            return SessionsRepositoryImpl.getInstance(injectLocalStorageProivder(), injectCahceProvider(), injectJsonMapper());
        }

        public static ICacheProvider injectCahceProvider() {
            return CahceProviderImpl.getInstance(JsonMapper.getInstance());
        }

        public static ILocalStorageProvider injectLocalStorageProivder() {
            return LocalStorageProviderImpl.getInstance();
        }

        public static JsonMapper injectJsonMapper() {
            return JsonMapper.getInstance();
        }
    }
}
