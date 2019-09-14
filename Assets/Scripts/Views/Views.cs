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
    }

    public class Views : IViews
    {
        readonly IServices Services;

        public Transform CanvasTransform { get; }
        public Canvas Canvas { get; }
        public Camera Camera { get; }

        public ITouchInterceptor TouchInterceptor { get; set; }
        public IBlend Blend { get; set; }


    }
}