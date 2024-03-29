﻿using Fridge.Controller;
using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public interface IViews
    {
        Transform CanvasTransform { get; }
        Canvas Canvas { get; }
        Camera Camera { get; }

        ITouchInterceptor TouchInterceptor { get; }
        IBlend Blend { get; }

        IMainView MainView { get; }
        IPopups Popups
        {
            get;
        }


        void Init();
    }

    public class Views : IViews
    {
        private readonly IServices Services;
        private readonly IReferences References;

        public Transform CanvasTransform => References.CanvasTransform;
        public Canvas Canvas => References.Canvas;
        public Camera Camera => References.Camera;

        public ITouchInterceptor TouchInterceptor { get; set; }
        public IBlend Blend { get; set; }

        public IMainView MainView { get; set; }

        public IPopups Popups { get; set; }

        public Views(IServices services, IReferences references)
        {
            Services = services;
            References = references;
        }

        public void Init()
        {
            CreateViews();

            Popups = new Popups(Services, this);
            TouchInterceptor = new TouchInterceptor(Services, this, CanvasTransform);
            Blend = new Blend(Services, this);
        }

        private void CreateViews()
        {
            CameraUtils.SetCameraSize(Camera);
            MainView = new MainView(Services, this);
            
            MainView.ShowPage(PageType.Fridge);
        }
    }
}