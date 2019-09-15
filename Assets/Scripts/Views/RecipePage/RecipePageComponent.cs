using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fridge.View
{
    public class RecipePageComponent : MonoBehaviour
    {
        public Transform theRecipeParent;
        public Button chooseButton;

        [Header("TYPE BUTTONS")]
        public Button vege;
        public Button meat;
        public Button noGluten;

        [Header("MEAL")]
        public Button breakfast;
        public Button dinner;
        public Button lunch;
        public Button Supper;

        public List<ChooseButton> buttonGroup1;
        public List<ChooseButton> buttonGroup2;
    }
}
