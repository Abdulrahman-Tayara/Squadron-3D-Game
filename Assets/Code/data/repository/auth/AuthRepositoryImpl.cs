using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AuthRepositoryImpl : IAuthRepository {

    private static AuthRepositoryImpl instance;

    private ICacheProvider cache;
    private IApiProvider apiProvider;

    private AuthRepositoryImpl(ICacheProvider cache, IApiProvider apiProvider) {
        this.cache = cache;
        this.apiProvider = apiProvider;
    }

    public static AuthRepositoryImpl getInstance(ICacheProvider cache, IApiProvider apiProvider) {
        if (instance == null)
            instance = new AuthRepositoryImpl(cache, apiProvider);
        return instance;
    }

    public User getUser() {
        bool loggedIn = getUserState() == UserState.LOGGED_IN;
        if (!loggedIn)
            return null;
        User user = cache.getObject<User>(CacheKeys.USER);
        return user;
    }

    public UserState getUserState() {
        return (UserState) cache.getInt(CacheKeys.USER_STATE, (int) UserState.GUEST);
    }

    public bool isLoggedIn() {
        return cache.getBoolean(CacheKeys.IS_LOGGED_IN, false);
    }

    public Task<LoginResponse> login(string email, string password) {
        Task<LoginResponse> task = apiProvider.post<LoginResponse>(ApiEndPoints.LOGIN, new LoginRequest(email, password));
        task.GetAwaiter().OnCompleted(() => {
            if (task != null && task.Result != null && task.Result.success) {
                try {
                    cache.putBoolean(CacheKeys.IS_LOGGED_IN, true);
                    cache.putInt(CacheKeys.USER_STATE, (int) UserState.LOGGED_IN);
                    cache.putObject(CacheKeys.USER, task.Result.data.user);
                    cache.putString(CacheKeys.TOKEN, task.Result.data.token);
                } catch (Exception e) {
                    Debug.Log(e.Message);
                }
            }
        });
        return task;
    }

    public bool loginAsGuest() {
        logout();
        cache.putBoolean(CacheKeys.IS_LOGGED_IN, true);
        return true;
    }

    public bool logout() {
        cache.putBoolean(CacheKeys.IS_LOGGED_IN, false);
        cache.putInt(CacheKeys.USER_STATE, (int) UserState.GUEST);
        cache.putObject(CacheKeys.USER, default(User));
        cache.putString(CacheKeys.TOKEN, "");
        return true;
    }
}

