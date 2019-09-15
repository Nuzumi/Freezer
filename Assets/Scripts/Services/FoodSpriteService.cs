using System.Collections;
using System.Collections.Generic;
using Fridge.Controller;
using UnityEngine;
using Fridge.Model;
using System;

namespace Fridge.Services
{
    public interface IFoodSpriteService
    {
        void GetSprite(Product product, Action<Sprite> onFound);
    }

    public class FoodSpriteService : Service, IFoodSpriteService
    {
        List<SpriteObject> sprites;

        public FoodSpriteService(IReferences references, IServices services) : base(references, services)
        {
            sprites = references.PrefabReferences.Sprites;
        }

        public void GetSprite(Product product, Action<Sprite> onFound)
        {
            FindInNames(product, onFound);
        }

        private void FindInNames(Product product, Action<Sprite> onFound)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                if(sprites[i].name.ToLower().Contains(product.name.ToLower()))
                {
                    onFound(sprites[i].sprite);
                    return;
                }
            }
            FindInCategory(product, onFound);
        }

        private void FindInCategory(Product product, Action<Sprite> onFound)
        {
            Debug.Log(product.name);
            for (int i = 0; i < sprites.Count; i++)
            {
                if(sprites[i].name == product.category)
                {
                    onFound(sprites[i].sprite);
                    return;
                }
            }

            FindError(onFound);
        }

        private void FindError(Action<Sprite> onFound)
        {
            for (int i = 0; i < sprites.Count; i++)
            {
                if (sprites[i].name == "error")
                {
                    onFound(sprites[i].sprite);
                    return;
                }
            }

            return;
        }
    }

}
