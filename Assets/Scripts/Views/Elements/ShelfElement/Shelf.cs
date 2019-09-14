using Fridge.Model;
using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    [Prefab("")]
    public class Shelf : AbstractShelf
    {
        public Shelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
           
        }

        public override void Init(string category)
        {
            base.Init(category);
            SetText(category);
        }

        private void SetText(string category)
        {
            component.CategoryText.text = category;
        }
    }
}