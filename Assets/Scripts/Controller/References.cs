using UnityEngine;

namespace Fridge.Controller
{
    public interface IReferences
    {
        IPrefabReferences PrefabReferences { get; }
    }

    public class References : MonoBehaviour, IReferences
    {
        public IPrefabReferences PrefabReferences { get; }
    }
}