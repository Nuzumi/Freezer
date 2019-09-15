using System;
using System.Collections;
using System.Collections.Generic;
using Fridge.Model;
using Fridge.Services;
using UniRx;
using UnityEngine;

namespace Fridge.View
{
    public interface IAddPage : IPage
    {

    }

    [Prefab("View/AddPage/AddPage")]
    public class AddPage : PageElement<AddPageComponent>, IAddPage
    {
        private WebCamTexture camTexture;
        private IDisposable disposable;

        public AddPage(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            AddListeners();
        }

        private void AddListeners()
        {
            component.takePicrure.onClick.AddListener(SendPicture);
        }

        private void SendPicture()
        {
            Texture2D photo = new Texture2D(camTexture.width, camTexture.height);
            photo.SetPixels(camTexture.GetPixels());
            photo.Apply();
            byte[] bytes = photo.EncodeToPNG();
            string encodedPhoto = Convert.ToBase64String(bytes);
            Services.HTTPService.GetProductFromPhoto(AddProduct, encodedPhoto);
        }

        private void AddProduct(Product product)
        {
            Debug.Log(product.name);
        }

        public PageType Type
        {
            get
            {
                return PageType.AddProduct;
            }
        }

        protected override void OnHidden()
        {
            camTexture.Stop();
            disposable.Dispose();
        }

        protected override void OnShow()
        {
            camTexture = new WebCamTexture();
            camTexture.Play();
            disposable = Observable.EveryUpdate().Subscribe(o => UpdateCamera());
        }

        private void UpdateCamera()
        {
            component.cameraView.texture = camTexture;
        }
    }
}
