using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public interface ICacheProvider {
    void putInt(String key, int value);

    void putFloat(string key, float value);

    void putString(string key, string value);

    void putBoolean(string key, bool value);

    void putObject<T>(string key, T value);

    int getInt(string key, int defaultValue = 0);

    float getFloat(string key, float defaultValue = 0.0f);

    string getString(string key, string defaultValue = "");

    bool getBoolean(string key, bool defaultValue = false);

    T getObject<T>(string key);

    void deleteKey(string key);
}

