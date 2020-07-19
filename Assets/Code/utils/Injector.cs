using Assets.Code.ui.gameplay.mvp;
using Assets.Code.ui.home.mvp;
using Assets.Code.ui.loadGame.mvp;
using Assets.Code.ui.login.mvp;
using Assets.Code.ui.newgame;
using Assets.Code.ui.ranks.mvp;
using Assets.Code.ui.settings.mvp;
using Assets.Code.ui.store.mvp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.utils {
    public class Injector {

        public static StorePresenter injectStorePresenter(StoreView view) {
            return new StorePresenterImpl(view, injectAuthRepository(), injectStoreRepository());
        }

        public static RanksPresenter injectRanksPresenter(RanksView view) {
            return new RanksPresenterImpl(view, injectRanksRepositort(), injectAuthRepository());
        }
        public static HomePresenter injectHomePresenter(HomeView view) {
            return new HomePresenterImpl(view, injectAuthRepository());
        }

        public static LoginPresenter injectLoginPresenter(LoginView view) {
            return new LoginPresenterImpl(view, injectAuthRepository());
        }

        public static LoadGamePresenter injectLoadGamePresenter(LoadGameView view) {
            return new LoadGamePresenterImpl(view, injectSessionRepository());
        }

        public static SettingsPresenter injectSettingsPresenter(SettingsView view) {
            return new SettingsPresenterImpl(view, injectGamePlayRepository(), injectSessionRepository(), injectAuthRepository());
        }
        public static NewGamePresenter injectNewGamePresenter(NewGameView view) {
            return new NewGamePresenterImpl(view, injectAirplanesRepository(), injectEnvironmentRepository(), injectGamePlayRepository());
        }

        public static GameplayPresenter injectGameplayPresenter(GameplayView view) {
            return new GameplayPresenterImpl(view, injectGamePlayRepository(), injectAirplanesRepository(), injectSessionRepository());
        }

        public static IStoreRepository injectStoreRepository() {
            return StoreRepositoryImpl.getInstance(injectApiProvider(), injectCahceProvider(), injectLocalStorageProivder(), injectJsonMapper());
        }

        public static IRanksRepository injectRanksRepositort() {
            return RanksRepositoryImpl.getInstance(injectApiProvider());
        }

        public static IAuthRepository injectAuthRepository() {
            return AuthRepositoryImpl.getInstance(injectCahceProvider(), injectApiProvider());
        }

        public static IGamePlayRepository injectGamePlayRepository() {
            return GamePlayRepositoryImpl.getInstance(injectApiProvider(), injectCahceProvider());
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

        public static IApiProvider injectApiProvider() {
            return new ApiProviderImpl(ApiEndPoints.BASE_URL, injectJsonMapper());
        }

        public static ICacheProvider injectCahceProvider() {
            return CacheProviderImpl.getInstance(JsonMapper.getInstance());
        }

        public static ILocalStorageProvider injectLocalStorageProivder() {
            return LocalStorageProviderImpl.getInstance();
        }

        public static JsonMapper injectJsonMapper() {
            return JsonMapper.getInstance();
        }
    }
}
