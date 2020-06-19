using Assets.Code.ui.gameplay.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.utils {
    public class Injector {
        public static GameplayPresenter injectGameplayPresenter(GameplayView view) {
            return new GameplayPresenterImpl(view, injectAirplanesRepository(), injectSessionRepository());
        }

        public static IAirplanesRepository injectAirplanesRepository() {
            return AirplanesRepositoryImpl.getInstance(injectLocalStorageProivder(), injectCahceProvider(), injectJsonMapper());
        }

        public static ISessionsRepository injectSessionRepository() {
            return SessionsRepositoryImpl.getInstance(injectLocalStorageProivder(), injectCahceProvider(), injectJsonMapper());
        }

        public static ICahceProvider injectCahceProvider() {
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
