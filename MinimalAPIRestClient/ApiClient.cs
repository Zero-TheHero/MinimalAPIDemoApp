﻿using DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MinimalAPIRestClient;
public class ApiClient : IApiClient
{

    private readonly RestClient _client;

    public ApiClient(string baseUri)
    {
        _client = new RestClient(baseUri);
    }
    public UserModel? GetUser(int id)
    {
        var request = new RestRequest($"Api/GetTest/{id}", Method.Get)
        {
            RequestFormat = DataFormat.Json
        };
        var response = _client.Execute(request);
        if (response.IsSuccessful && (response.Content != null))
        {
            var user = JsonConvert.DeserializeObject<UserModel>(response.Content.ToString());
            return user;
        }
        return null;
    }

    public List<UserModel>? GetUsers()
    {
        var request = new RestRequest("Api/GetTests", Method.Get)
        {
            RequestFormat = DataFormat.Json
        };
        var response = _client.Execute(request);
        if (response.IsSuccessful && (response.Content != null))
        {
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ToString());
            return users;
        }
        return null;
    }

    public bool InsertUser(UserModel user)
    {
        var json = JsonConvert.SerializeObject(user);

        var request = new RestRequest("Api/InsertTest", Method.Post)
        {
            RequestFormat = DataFormat.Json
        };
        request.AddBody(json);
        var response = _client.Execute(request);
        if (response.IsSuccessful)
        {
            return true;
        }
        return false;
    }

    public bool UpdateUser(UserModel user)
    {
        var json = JsonConvert.SerializeObject(user);

        var request = new RestRequest("Api/UpdateTest", Method.Put)
        {
            RequestFormat = DataFormat.Json
        };
        request.AddBody(json);
        var response = _client.Execute(request);
        if (response.IsSuccessful)
        {
            return true;
        }
        return false;
    }

    public bool DeleteUser(int id)
    {
        var request = new RestRequest($"Api/DeleteTest/{id}", Method.Delete);
        var response = _client.Execute(request);
        if (response.IsSuccessful)
        {
            return true;
        }
        return false;
    }
}
