using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Fridge.View
{
    public class MainViewComponent : ViewReferences
    {
        public Transform PageContent;

        public Button AddProduct;

        public Button FridgeButton;
        public Button PublicFridgeButton;
        public Button RecepiesButton;

        public Animator FridgeButtonAnim;
        public Animator PublicFridgeButtonAnim;
        public Animator RecepiesButtonAnim;
    }
}