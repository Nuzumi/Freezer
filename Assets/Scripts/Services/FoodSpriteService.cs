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
        Sprite GetSprite(Product product);
    }

    public class FoodSpriteService : Service, IFoodSpriteService
    {
        IPrefabReferences sprites;

        public FoodSpriteService(IReferences references, IServices services) : base(references, services)
        {
            sprites = references.PrefabReferences;
        }

        public Sprite GetSprite(Product product)
        {
            
        }

        private void FindInNames(string name, Action<Sprite> onFound)
        {

        }
    }

}
