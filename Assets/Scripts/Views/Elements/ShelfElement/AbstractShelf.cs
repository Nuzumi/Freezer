using Fridge.Model;
using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    public interface IShelf : IDestroyableElement
    {
        void Init(string category);
        void AddProduct(Product product);

        bool HasFreeSlot();
        string GetCategory();
    }

    public abstract class AbstractShelf : DestroyableElement<ShelfComponent>, IShelf
    {
        private List<ProductObject> Products { get; set; }
        private const int MAX_COUNT = 5;

        private string category;

        public AbstractShelf(IServices services, IViews views, Transform parent) : base(services, views, parent)
        {
            Products = new List<ProductObject>();
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
            var prod = new ProductObject(Services, Views, component.Products, product);

            Products.Add(prod);
            
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