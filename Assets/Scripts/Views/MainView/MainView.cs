using Fridge.Services;
using Fridge.View.FridgeView;
using System.Collections.Generic;

namespace Fridge.View
{
    public interface IMainView
    {
        IFridgePage FridgePage { get; }

        void ShowPage(Page page);
    }

    [Prefab("View/MainView/MainView")]
    public class MainView : View<MainViewComponent>, IMainView
    {
        private IPage active;

        private Dictionary<Page, IPage> Pages { get; set; }

        public IFridgePage FridgePage { get; private set; }

        public MainView(IServices services, IViews views) : base(services, views)
        {
            CreatePages();
        }

        private void CreatePages()
        {
            FridgePage = new FridgePage(Services, Views, component.PageContent);

            Pages.Add(Page.Fridge, FridgePage);
        }

        public void ShowPage(Page page)
        {
            active?.Hide();

            active = Pages[page];
            active.Show();
        }

        protected override void OnShow()
        {
        }
        
        protected override void OnHidden()
        {
            go.SetActive(false);
            active?.Hide();
            active = null;
        }
    }
}