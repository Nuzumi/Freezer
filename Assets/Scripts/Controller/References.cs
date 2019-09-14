using UnityEngine;

namespace Fridge.Controller
{
    public interface IReferences
    {
        Transform CanvasTransform { get; }
        Canvas Canvas { get; }
        Camera Camera { get; }

        IPrefabReferences PrefabReferences { get; }
    }

    public class References : MonoBehaviour, IReferences
    {
        public Transform CanvasTransform => canvasTransform;
        public Transform canvasTransform;

        public Canvas Canvas => canvas;
        public Canvas canvas;

        public Camera Camera => mainCamera;
        public Camera mainCamera;

        public IPrefabReferences PrefabReferences => prefabReferences;
        public PrefabReferences prefabReferences;
    }
}