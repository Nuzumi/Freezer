using Fridge.Services;
using Fridge.View.Page;
using System.Collections.Generic;

namespace Fridge.View
{
    public interface IMainView
    {
        IFridgePage FridgePage { get; }
        IPublicFridgesPage PublicFridgesPage { get; }
        IRecipePage RecepiesPage { get; }

        void ShowPage(PageType page);
    }

    [Prefab("View/MainView/MainView")]
    public class MainView : View<MainViewComponent>, IMainView
    {
        private IPage active;

        private Dictionary<PageType, IPage> Pages { get; set; }

        public IFridgePage FridgePage { get; private set; }
        public IPublicFridgesPage PublicFridgesPage { get; private set; }
        public IRecipePage RecepiesPage { get; private set; }

        public MainView(IServices services, IViews views) : base(services, views)
        {
            Pages = new Dictionary<PageType, IPage>();
            CreatePages();
            AddListeners();
        }

        private void CreatePages()
        {
            FridgePage = new FridgePage(Services, Views, component.PageContent);
            PublicFridgesPage = new PublicFridgesPage(Services, Views, component.PageContent);
            RecepiesPage = new RecipePage(Services, Views, component.PageContent);

            Pages.Add(FridgePage.Type, FridgePage);
            Pages.Add(PublicFridgesPage.Type, PublicFridgesPage);
            Pages.Add(RecepiesPage.Type, RecepiesPage);
        }

        private void AddListeners()
        {
            component.FridgeButton.onClick.AddListener(() => ShowPage(PageType.Fridge));
            component.PublicFridgeButton.onClick.AddListener(() => ShowPage(PageType.PublicFridge));
            component.RecepiesButton.onClick.AddListener(() => ShowPage(PageType.Recepies));
        }

        public void ShowPage(PageType page)
        {
            Show();
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