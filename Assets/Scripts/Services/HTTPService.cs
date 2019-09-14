using System;
using System.Collections;
using System.Collections.Generic;
using Fridge.Controller;
using Fridge.Model;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Fridge.Services
{
    public interface IHTTPService
    {
        void Reset();
        void UseProduct(Product product);
        void WaistProduct(string id);
        void AddProduct(Product product);
        void GetPoints(Action<int> onSuccess);
        void GetProducts(Action<Product[]> onSuccess);
        void GetProduct(Action<ProductDetail> onSuccess, string id);
    }

    public class HTTPService: Service, IHTTPService
    {
        private const string apiUri = "https://wastedappservice.azurewebsites.net/api";

        public HTTPService(IReferences references, IServices services) : base(references, services)
        {
            Reset();
        }

        public void Reset()
        {
            Post("", "reset");
        }

        public void UseProduct(Product product)
        {
            Post(services.JsonService.Serialize(product), GetParameters(new string[] { "products",product.id.ToString(),"use" }));
        }

        public void WaistProduct(string id)
        {
            var request = UnityWebRequest.Delete(GetParameters("products", id));
            request.SendWebRequest();
        }

        public void AddProduct(Product product)
        {
            Post(services.JsonService.Serialize(product), "products");
        }

        private void Post(string data, params string[] parameters)
        {
            var request = UnityWebRequest.Post(GetParameters(parameters),data);
            request.SendWebRequest();
        }

        public void AddPoints(int points)
        {
            Post(points.ToString(), "userPoints");
        }

        public void GetPoints(Action<int> onSuccess)
        {
            GetNumber(onSuccess, "userPoints");
        }

        public void GetProducts(Action<Product[]> onSuccess)
        {
            Get<Product[]>(onSuccess, "products");
        }

        public void GetProduct(Action<ProductDetail> onSuccess, string id)
        {
            Get<ProductDetail>(onSuccess, "products", id);
        }

        private void Get<T>(Action<T> onSuccess, params string[] parameters)
        {
            var request = UnityWebRequest.Get(GetParameters(parameters));
            new ModelRequest<T>(services.JsonService, onSuccess).Send(request);
        }

        private void Get(Action<string> onSuccess, params string[] parameters)
        {
            var request = UnityWebRequest.Get(GetParameters(parameters));
            new TextRequest(onSuccess).Send(request);
        }

        private void GetNumber(Action<int> onSuccess, params string[] parameters)
        {
            var request = UnityWebRequest.Get(GetParameters(parameters));
            new NumberRequest(onSuccess).Send(request);
        }

        private string GetParameters(string param1, string param2)
        {
            return apiUri + "/" + param1 + "/" + param1;
        }

        private string GetParameters(string[] parameters)
        {
            string result = apiUri;
            for (int i = 0; i < parameters.Length; i++)
                result += "/" + parameters[i];
            return result;
        }
    }
}

