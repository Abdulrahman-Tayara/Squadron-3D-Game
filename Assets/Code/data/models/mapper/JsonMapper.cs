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
        return JsonUtility.ToJson(model);
    }
    
    public T fromJson<T>(string json) {
        T data = default(T);
        try {
            data = JsonUtility.FromJson<T>(json);
        } catch (Exception e) {
            Debug.Log(e.Message);
        }
        return data;
    }

    // Used when the root of json is an array. ex : [{"id": 1}, {"id": 2}, {"id": 3}]
    public List<T> fromJsonArray<T>(string json) {
        json = "{\"items\":" + json + "}";
        return fromJson<Wrapper<T>>(json).items;
    }

    private class Wrapper<T> {
        public List<T> items;
    }
}

