using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class SessionsRepositoryImpl : ISessionsRepository {

    private static SessionsRepositoryImpl INSTNCE;

    private ILocalStorageProvider localStorage;
    private ICacheProvider cahce;
    private JsonMapper jsonMapper;

    private SessionsRepositoryImpl(ILocalStorageProvider localStorage, ICacheProvider cahce, JsonMapper jsonMapper) {
        this.localStorage = localStorage;
        this.cahce = cahce;
        this.jsonMapper = jsonMapper;
    }

    public static SessionsRepositoryImpl getInstance(ILocalStorageProvider localStorage, ICacheProvider cahce, JsonMapper jsonMapper) {
        if (INSTNCE == null)
            INSTNCE = new SessionsRepositoryImpl(localStorage, cahce, jsonMapper);
        return INSTNCE;
    }

    // Return saved session but if there is no session then return a new one
    public Task<Session> getSavedSession() {
        int sesstionId = cahce.getInt(CacheKeys.SAVED_SESSION_ID, -1);
        if (sesstionId > 0) {
            return getSessionById(sesstionId);
        } else {
            Session session = new Session(cahce.getInt(CacheKeys.AIRPLANE_ID, 1), cahce.getInt(CacheKeys.ENVIRONMENT_ID, 1), "new sesstion", new GameState(int.MaxValue, cahce.getInt(CacheKeys.DIFFICULTY, 1), 0, 0));
            return Task.Run(() => {
                return session;
            });
        }
    }

    public Task<Session> getSessionById(int id) {
        return Task.Run(() => {
            string data = localStorage.readFile(ResourcesPath.SESSIONS_FILE);
            List<Session> sessions = jsonMapper.fromJsonArray<Session>(data);
            return sessions.Find(session => session.id == id);
        });
    }

    public Task<bool> saveSession(Session session) {
        return Task.Run(() => {
            if (session == null)
                return false;
            string data = localStorage.readFile(ResourcesPath.SESSIONS_FILE);
            List<Session> sessions = jsonMapper.fromJsonArray<Session>(data);
            sessions.Add(session);
            localStorage.writeFile(ResourcesPath.SESSIONS_FILE, jsonMapper.toJson(sessions));
            return true;
        });
    }
}

