using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fridge.View
{
    public class ChooseButton : MonoBehaviour
    {
        public Image image;
        public Button button;
        public Color choosenColor;

        private Color normalColor;

        private void Start()
        {
            normalColor = image.color;
            button.onClick.AddListener(SetChoosenColor);
        }

        public void Reset()
        {
            SetNormalColor();
        }

        private void SetNormalColor()
        {
            image.color = normalColor;
        }

        private void SetChoosenColor()
        {
            image.color = choosenColor;
        }
    }
}
