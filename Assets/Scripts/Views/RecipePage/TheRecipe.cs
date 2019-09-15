using System;
using System.Collections;
using System.Collections.Generic;
using Fridge.Model;
using Fridge.Services;
using UnityEngine;

namespace Fridge.View
{
    public interface ITheRecipe
    {
        void Init(Recipe recipe);
    }

    [Prefab("View/RecipeView/TheRecipe")]
    public class TheRecipe : Element<TheRecipeComponent>, ITheRecipe
    {
        public TheRecipe(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
        }

        public void Init(Recipe recipe)
        {
            Services.HTTPService.GetSprite(SetSprite, recipe.imageLink);
            component.title.text = recipe.title;
            component.description.text = recipe.description;
            component.ingridients.text = GetIngridients(recipe);
            component.steps.text = GetSteps(recipe);
        }

        private string GetSteps(Recipe recipe)
        {
            string result = "";
            string[] steps = recipe.steps.Split('.');
            for(int i = 0; i< steps.Length; i++)
                result += "- " + steps[i];

            return result;
        }

        private string GetIngridients(Recipe recipe)
        {
            string result = "";
            foreach (var i in recipe.ingredients)
                result += i.ToString() + "\n";

            return result;
        }

        private void SetSprite(Sprite sprite)
        {
            component.image.sprite = sprite;
        }
    }
}
