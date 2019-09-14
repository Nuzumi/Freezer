using Fridge.Model;
using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    public interface IShelf
    {
        void Init(string category);
        void AddProduct(Product product);

        bool HasFreeSlot();
        string GetCategory();
    }

    public abstract class AbstractShelf : DestroyableElement<ShelfComponent>, IShelf
    {
        private List<string> Products { get; set; }
        private const int MAX_COUNT = 5;

        private string category;

        public AbstractShelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            Products = new List<string>();
        }

        public virtual void Init(string category)
        {
            this.category = category;
        }

         public string GetCategory()
        {
            return category;
        }

        public void AddProduct(Product product)
        {

        }

        public bool HasFreeSlot()
        {
            return Products.Count < MAX_COUNT;
        }

        protected override void OnDestroy()
        {

        }
    }
}