using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fridge
{
    public interface IPrefabReferences
    {
        List<GameObject> Prefabs { get; }
        string[] Paths { get; }
        List<Sprite> Sprites { get; }
        string[] SpritePaths { get; }
    }

    [CreateAssetMenu(fileName = "PrefabReferences", menuName = "Fridge/PrefabReferences")]
    public class PrefabReferences : ScriptableObject, IPrefabReferences
    {
        public List<GameObject> Prefabs => prefabs;
        public string[] Paths => paths;
        public List<Sprite> Sprites => sprites;
        public string[] SpritePaths => spritePaths;

        [SerializeField]
        [Header("PREFABS")]
        public List<GameObject> prefabs;

        [SerializeField]
        [Header("Sprites")]
        public List<Sprite> sprites;

        [HideInInspector]
        public string[] paths;
        [HideInInspector]
        public string[] spritePaths;

#if UNITY_EDITOR

        public void Refresh()
        {
            paths = RefreshAndCreatePaths(prefabs);
            spritePaths = RefreshAndCreatePaths(sprites);
        }

        string[] RefreshAndCreatePaths<T>(List<T> list) where T : Object
        {
            RemoveNulls(list);
            SortByName(list);
            string[] newPaths = CreatePaths(list);

            if(list.Count != newPaths.Length)
                Debug.LogException(new UnityException("List: " + list.Count + "   Paths: " + paths.Length));
            else
                Debug.Log("Validation succesed");
            return newPaths;
        }

        void RemoveNulls<T>(List<T> list) where T : Object
        {
            list.RemoveAll(c => c == null);
        }

        void SortByName<T>(List<T> list) where T : Object
        {
            list.Sort((go1, go2) => string.Compare(go1.name, go2.name));
        }

        string[] CreatePaths<T>(List<T> list) where T : Object
        {
            string[] newPaths = new string[list.Count];
            for(int i = 0; i < list.Count; i++)
            {
                string path = AssetDatabase.GetAssetPath(list[i].GetInstanceID());
                path = path.Replace("Assets/GFX/Game/", "").Replace(".prefab", "");
                newPaths[i] = path;
            }
            return newPaths;
        }
#endif
    }
}