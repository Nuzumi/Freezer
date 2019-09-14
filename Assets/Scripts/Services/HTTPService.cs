using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Fridge.Services
{
    public interface IHTTPService
    {

    }

    public class HTTPService
    {
        private const string apiUri = "https://wastedappservice.azurewebsites.net/";

        private void Get<T>(Action<T> onSuccess, params string[] parameters)
        {
            var request = UnityWebRequest.Get(GetParameters(parameters));
            request.SendWebRequest().AsObservable().Subscribe(o => OnGetFinished(request, onSuccess));
        }

        private string GetParameters(string[] parameters)
        {
            string result = apiUri;
            for (int i = 0; i < parameters.Length; i++)
                result += "/" + parameters[i];
            return result;
        }

        private void OnGetFinished<T>(UnityWebRequest request, Action<T> onSuccess)
        {
            if (!ValidateRequest(request))
                return;

            //onSuccess(GetResult<T>(request));
        }

        //private T GetResult<T>(UnityWebRequest request)
        //{
        //    return request.downloadHandler.text;
        //}

        private bool ValidateRequest(UnityWebRequest request)
        {
            if (!request.isNetworkError && !request.isHttpError)
                return true;

            Debug.Log($"HTTP Request failed: {request.uri} {request.responseCode}: {request.error}");

            return false;
        }
    }
}

