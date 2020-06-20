using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CahceProviderImpl : ICacheProvider {

    private static CahceProviderImpl INSTANCE;

    private JsonMapper jsonMapper;

    private CahceProviderImpl(JsonMapper jsonMapper) {
        this.jsonMapper = jsonMapper;
    }

    public static CahceProviderImpl getInstance(JsonMapper jsonMapper) {
        if (INSTANCE == null)
            INSTANCE = new CahceProviderImpl(jsonMapper);
        return INSTANCE;
    }

    public void deleteKey(string key) {
        PlayerPrefs.DeleteKey(key);
    }

    public bool getBoolean(string key, bool defaultValue = false) {
        return PlayerPrefs.GetInt(key, 0) == 1;
    }

    public float getFloat(string key, float defaultValue = 0) {
        return PlayerPrefs.GetFloat(key, defaultValue);
    }

    public int getInt(string key, int defaultValue = 0) {
        return PlayerPrefs.GetInt(key, defaultValue);
    }

    public T getObject<T>(string key) {
        return jsonMapper.fromJson<T>(PlayerPrefs.GetString(key));
    }

    public string getString(string key, string defaultValue = "") {
        return PlayerPrefs.GetString(key, defaultValue);
    }

    public void putBoolean(string key, bool value) {
        PlayerPrefs.SetInt(key, value ? 1 : 0);
    }

    public void putFloat(string key, float value) {
        PlayerPrefs.SetFloat(key, value);
    }

    public void putInt(string key, int value) {
        PlayerPrefs.SetInt(key, value);
    }

    // Convert the model to string then save it in PlayerPrefs
    public void putObject<T>(string key, T value) {
        PlayerPrefs.SetString(key, jsonMapper.toJson(value));
    }

    public void putString(string key, string value) {
        PlayerPrefs.SetString(key, value);
    }
}

