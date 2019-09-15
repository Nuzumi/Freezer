using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Fridge.View
{
    public class TheRecipeComponent : MonoBehaviour
    {
        public TextMeshProUGUI title;
        public TextMeshProUGUI description;
        public TextMeshProUGUI ingridients;
        public TextMeshProUGUI steps;

        public Image image;
    }
}
