using System.Collections.Generic;

namespace Fridge.View.Shelf
{
    public interface IShelfCreator
    {
        void CreateShelfs(string products);
    }

    public class ShelfCreator : IShelfCreator
    {
        private List<IShelf> Shelfs { get; set; }

        public void CreateShelfs(string products)
        {
            
        }

        private bool IsShelfCreated(string category)
        {
            return false;
        }

        private bool ShelfHasPlace()
        {
            return false;
        }
    }
}