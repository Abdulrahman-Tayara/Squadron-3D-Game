using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using UnityEngine;
using Newtonsoft.Json;

public class ApiProviderImpl : IApiProvider {
    private JsonMapper jsonMapper;
    private string baseUrl;


    public ApiProviderImpl(string baseUrl, JsonMapper jsonMapper) {
        this.baseUrl = baseUrl;
        this.jsonMapper = jsonMapper;
    }

    private string fixUrl(string endPoint) => baseUrl + endPoint;

    private Task<T> makeRequest<T>(RestRequest request) {
        return Task.Run(() => {
            RestClient client = new RestClient(baseUrl);
            IRestResponse<T> response = client.Execute<T>(request);
            string json = response.Content;
            Debug.Log("Response Json: " + json);
            try {
                T data = jsonMapper.fromJson<T>(json);
                return data;
            } catch (Exception e) {
                Debug.Log("Exception: " + e.Message);
                return default;
            }
        });
    }

    public Task<T> post<T>(string endPoint, object data) {
        RestRequest request = new RestRequest(endPoint, Method.POST);
        string jsonData = jsonMapper.toJson(data);
        Debug.Log("Request : " + jsonData);
        request.AddJsonBody(jsonData, "application/json");
        request.AddJsonBody(data);
        return makeRequest<T>(request);
    }

    public Task<T> get<T>(string endPoint) {
        Debug.Log("Get Request");
        RestRequest request = new RestRequest(endPoint, Method.GET);
        return makeRequest<T>(request);
    }
}

