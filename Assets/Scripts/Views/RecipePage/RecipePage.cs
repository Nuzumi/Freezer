using System;
using System.Collections;
using System.Collections.Generic;
using Fridge.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Fridge.View
{
    public interface IRecipePage : IPage
    {

    }

    [Prefab("View/RecipeView/RecipeView")]
    public class RecipePage : PageElement<RecipePageComponent>, IRecipePage
    {
        private string mealType;
        private string mealTimeType;

        public Page Type
        {
            get
            {
                return Page.Recepies;
            }
        }

        public RecipePage(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
        }

        protected override void OnHidden()
        {
            
        }

        protected override void OnShow()
        {
            component.chooseButton.onClick.AddListener(SearchForRecipe);
            SetUpTimeTypeButtons();
            SetUpTypeButtons();
        }

        private void SearchForRecipe()
        {
            Debug.Log(mealType + " " + mealTimeType);
        }

        private void SetUpTimeTypeButtons()
        {
            component.dinner.onClick.AddListener(() => ButtonClicked(() => mealTimeType = "dinner", component.dinner));
            component.breakfast.onClick.AddListener(() => ButtonClicked(() => mealTimeType = "breakfast", component.breakfast));
            component.lunch.onClick.AddListener(() => ButtonClicked(() => mealTimeType = "lunch", component.lunch));
            component.Supper.onClick.AddListener(() => ButtonClicked(() => mealTimeType = "supper", component.Supper));
        }

        private void SetUpTypeButtons()
        {
            component.vege.onClick.AddListener(() => ButtonClicked(() => mealType = "vege", component.vege));
            component.noGluten.onClick.AddListener(() => ButtonClicked(() => mealType = "noGluten", component.noGluten));
            component.meat.onClick.AddListener(() => ButtonClicked(() => mealType = "meat", component.meat));
        }

        private void ButtonClicked(Action setValue, Button button)
        {
            if (IsInGroup(component.buttonGroup1,button))
            {
                ResetGroup(component.buttonGroup1, button);
                return; 
            }

            ResetGroup(component.buttonGroup2, button);
        }

        private bool IsInGroup(List<ChooseButton> list, Button button)
        {
            foreach (var cb in list)
                if (cb.button == button)
                    return true;

            return true;
        }

        private void ResetGroup(List<ChooseButton> list, Button button)
        {
            foreach (var cb in list)
                if (cb.button != button)
                    cb.Reset();
        }
    }
}

