using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Fridge.Services
{

    public abstract class HTTPRequest<T>
    {
        private readonly Action<T> onSuccess;

        public HTTPRequest(Action<T> onSuccess)
        {
            this.onSuccess = onSuccess;
        }

        public void Send(UnityWebRequest request)
        {
            request.SendWebRequest().AsObservable().Subscribe(o => OnGetFinished(request, onSuccess));
        }

        private void OnGetFinished(UnityWebRequest request, Action<T> onSuccess)
        {
            if (!ValidateRequest(request))
                return;

            onSuccess(GetResult(request));
        }

        private bool ValidateRequest(UnityWebRequest request)
        {
            if (!request.isNetworkError && !request.isHttpError)
                return true;

            Debug.Log($"HTTP Request failed: {request.uri} {request.responseCode}: {request.error}");

            return false;
        }

        protected abstract T GetResult(UnityWebRequest request);
    }
}

