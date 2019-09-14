using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.Services
{
    public interface IJsonService
    {
        string Serialize(object toSerialize);
        T Deserialize<T>(string json);
    }

    public class JsonService : IJsonService
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize(object toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }
    }
}

