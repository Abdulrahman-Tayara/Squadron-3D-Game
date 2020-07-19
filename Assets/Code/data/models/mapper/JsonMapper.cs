using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JsonMapper {

    private static JsonMapper INSTANCE = new JsonMapper();

    private JsonMapper() {

    }

    public static JsonMapper getInstance() {
        return INSTANCE;
    }

    public string toJson<T>(T model) {
        //return JsonUtility.ToJson(model);
        return JsonConvert.SerializeObject(model);
    }

    public string toJsonArray<T>(List<T> data) {
        string json = "[";
        for (int i = 0; i < data.Count; ++i) {
            json += toJson<T>(data[i]);
            if (i < data.Count - 1)
                json += ",";
        }
        json += "]";
        return json;
    }

    public T fromJson<T>(string json) {
        T data = default(T);
        try {
            //data = JsonUtility.FromJson<T>(json);
            data = JsonConvert.DeserializeObject<T>(json);
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
        return data;
    }

    // Used when the root of json is an array. ex : [{"id": 1}, {"id": 2}, {"id": 3}]
    public List<T> fromJsonArray<T>(string json) {
        //json = "{\"items\":" + json + "}";
        try {
            //return fromJson<Wrapper<T>>(json).items;
            return JsonConvert.DeserializeObject<List<T>>(json);
        } catch(Exception e) {
            Debug.Log(e.Message);
            return new List<T>();
        }
    }

    private class Wrapper<T> {
        public List<T> items;
    }
}

