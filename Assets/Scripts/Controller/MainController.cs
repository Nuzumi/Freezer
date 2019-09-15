using UnityEngine;
using Fridge.Services;
using Fridge.View;

namespace Fridge.Controller
{
    public class MainController : MonoBehaviour 
    {
        public IReferences References => references;
        public References references;
        
        public IServices services;

        private IViews views;

        private void Start()
        {
            CreateServices();
            CreateViews();
        }

        private void CreateServices()
        {
            services = new Services.Services();
            services.Init(References, views);
        }

        private void CreateViews()
        {
            views = new Views(services, references);
            views.Init();
            
        }
    }
}