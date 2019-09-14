using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Fridge.Services
{
    public class ModelRequest<T> : HTTPRequest<T>
    {
        private readonly IJsonService jsonService;

        public ModelRequest(IJsonService jsonService, Action<T> onSuccess) : base(onSuccess)
        {
            this.jsonService = jsonService;
        }

        protected override T GetResult(UnityWebRequest request)
        {
            return jsonService.Deserialize<T>(request.downloadHandler.text);
        }
    }
}

