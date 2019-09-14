using Fridge.Model;
using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    public interface IShelfCreator
    {
        void FillShelves(List<Product> products);
        void DestroyShelves();
    }

    public class ShelfCreator : IShelfCreator
    {
        readonly IServices services;
        readonly IViews views;

        private Dictionary<string, List<IShelf>> Shelves { get; set; }
        private Transform shelvesTransform;

        private IShelfFactory factory;

        public ShelfCreator(IServices services, IViews views, Transform transform)
        {
            this.services = services;
            this.views = views;

            this.shelvesTransform = transform;

            Shelves = new Dictionary<string, List<IShelf>>();
            factory = new ShelfFactory(services, views);
        }

        public void FillShelves(List<Product> products)
        {
            for(int i = 0; i < products.Count; i++)
                TryAddProduct(products[i]);
        }

        public void DestroyShelves()
        {
            foreach(var key in Shelves?.Keys)
                DestroyShelf(Shelves[key]);

            Shelves.Clear();
        }

        private void DestroyShelf(List<IShelf> Shelf)
        {
            for(int i = 0; i < Shelf.Count; i++)
                Shelf[i]?.Destroy();
        }

        private void TryAddProduct(Product product)
        {
            List<IShelf> shelves = null;
            if(!Shelves.TryGetValue(product.category, out shelves))
            {
                CreateShelf(product);
                return;
            }

            TryAddProduct(shelves, product);
        }

        private void TryAddProduct(List<IShelf> shelves, Product product)
        {
           for(int i = 0; i < shelves.Count; i++)
           {
                if(ShelfHasPlace(shelves[i]))
                {
                    shelves[i].AddProduct(product);
                    return;
                }
           }

            CreateNextShelf(shelves, product);
        }

        private void CreateShelf(Product product)
        {
            IShelf shelf = factory.CreateShelf(shelvesTransform, product.category, true);
            shelf.Init(product.category);

            Shelves.Add(product.category, new List<IShelf>() { shelf });

            AddProduct(shelf, product);
        }

        private void CreateNextShelf(List<IShelf> shelves, Product product)
        {
            IShelf shelf = factory.CreateShelf(shelvesTransform, product.category);
            shelf.Init(product.category);

            shelves.Add(shelf);

            AddProduct(shelf, product);
        }

        private void AddProduct(IShelf shelf, Product product)
        {
            shelf.AddProduct(product);
        }

        private bool ShelfHasPlace(IShelf shelf)
        {
            return shelf.HasFreeSlot();
        }
    }
}