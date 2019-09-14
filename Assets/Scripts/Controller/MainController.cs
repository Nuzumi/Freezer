using UnityEngine;
using Fridge.Services;

namespace Fridge.Controller
{
    public class MainController : MonoBehaviour 
    {
        public IReferences References => references;
        public References references;
        
        public IServices services;

        private void Start()
        {
            services = new Services.Services();
            services.Init(References);
        }
    }
}