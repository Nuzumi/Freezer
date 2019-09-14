using UnityEngine;

namespace Fridge.Controller
{
    public interface IReferences
    {
        Transform CanvasTransform { get; }
        Canvas Canvas { get; }
        IPrefabReferences PrefabReferences { get; }
    }

    public class References : MonoBehaviour, IReferences
    {
        public Transform CanvasTransform => canvasTransform;
        public Transform canvasTransform;

        public Canvas Canvas => canvas;
        public Canvas canvas;


        public IPrefabReferences PrefabReferences => prefabReferences;
        public PrefabReferences prefabReferences;
    }
}