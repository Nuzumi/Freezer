using Fridge.Services;
using System;

namespace Fridge.View
{
    public abstract class Popup<T> : View<T> where T : ViewReferences
    {
        protected abstract void OnPopupShown();
        protected abstract void OnPopupHidden();
        
        protected Popup(IServices services, IViews views) : base(services, views)
        {
        }

        protected override void OnShow()
        {
                Views.TouchInterceptor.Setup(10, "UI", 0.4f);
                Views.TouchInterceptor.Show();
                Views.TouchInterceptor.OnTouchIntercepted += Hide;
            Views.Blend.Show();
            OnPopupShown();
        }

        public override void Hide()
        {
            Views.TouchInterceptor.OnTouchIntercepted -= Hide;
            Views.Blend.Hide();
            base.Hide();
        }

        protected override void OnHidden()
        {
            Views.TouchInterceptor.Hide();
            OnPopupHidden();
        }
    }
}
