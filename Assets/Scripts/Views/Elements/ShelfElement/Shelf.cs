using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    public interface IShelf
    {
        void Init(string category);
        void AddProduct(string name);

        bool HasFreeSlot();
    }

    public class Shelf : HideableElement<ShelfComponent>, IShelf
    {
        private List<string> Products { get; set; }
        private const int MAX_COUNT = 5;

        public Shelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            Products = new List<string>();
        }

        public void Init(string category)
        {
            SetText(category);
        }

        private void SetText(string category)
        {
            component.CategoryText.text = category;
        }

        protected override void OnShow()
        {
        }

        protected override void OnHidden()
        {
        }

        public void AddProduct(string name)
        {
            if(!HasFreeSlot())
                return;

            AddProduct(name);
        }

        public bool HasFreeSlot()
        {
            return Products.Count < MAX_COUNT;
        }
    }
}