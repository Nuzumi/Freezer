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
        void GetProducts(Action<List<Product>> onSuccess);
        void GetProduct(Action<ProductDetail> onSuccess, string id);
        void GetRecipe(Action<List<Recipe>> onSuccess);
        void GetSprite(Action<Sprite> onSuccess, string url);
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

        public void GetProducts(Action<List<Product>> onSuccess)
        {
            Get<List<Product>>(onSuccess, "products");
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

        public void GetRecipe(Action<List<Recipe>> onSuccess)
        {
            Get<List<Recipe>>(onSuccess, "recipes");
        }

        public void GetSprite(Action<Sprite> onSuccess, string url)
        {
            var request = UnityWebRequestTexture.GetTexture(url);
            request.SendWebRequest().AsObservable().Subscribe(o => OnGetTexture(request, onSuccess));
        }

        private void OnGetTexture(UnityWebRequest request, Action<Sprite> onSuccess)
        {
            if (request.isNetworkError || request.isHttpError)
                return;

            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
            onSuccess(sprite);
        }
    }
}

