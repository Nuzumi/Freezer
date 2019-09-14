using Fridge.Model;
using Fridge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Fridge.View.Shelf
{
    public interface IShelfFactory
    {
        IShelf CreateShelf(Transform parent, string category, bool isFirst = false);
    }

    public class ShelfFactory : IShelfFactory
    {
        readonly IServices services;
        readonly IViews views;

        public ShelfFactory(IServices Services, IViews Views) {
            this.services = Services;
            this.views = Views;
        }

        public IShelf CreateShelf(Transform parent, string category, bool isFirst = false)
        {
            if(isFirst)
                return new MainShelf(services, views, parent);

            return new Shelf(services, views, parent);
        }
    }
}