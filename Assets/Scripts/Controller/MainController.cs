using UnityEngine;

namespace Fridge.Controller
{
    public class MainController : MonoBehaviour 
    {
        public IReferences References => references;
        public IReferences references;
    }
}