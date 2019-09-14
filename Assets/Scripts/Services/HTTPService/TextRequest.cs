using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Fridge.Services
{
    public class TextRequest : HTTPRequest<string>
    {
        public TextRequest(Action<string> onSuccess) : base(onSuccess)
        {
        }

        protected override string GetResult(UnityWebRequest request)
        {
            return request.downloadHandler.text;
        }
    }

    public class NumberRequest : HTTPRequest<int>
    {
        public NumberRequest(Action<int> onSuccess) : base(onSuccess)
        {
        }

        protected override int GetResult(UnityWebRequest request)
        {
            return int.Parse(request.downloadHandler.text);
        }
    }

}

