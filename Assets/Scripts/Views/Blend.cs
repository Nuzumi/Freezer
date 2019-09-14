using Fridge.Services;

namespace Fridge.View
{
    public interface IBlend : IView
    { }

    [Prefab("Popup/Blend/Blend")]
    public class Blend : View<ViewReferences>, IBlend
    {
        public Blend(IServices services, IViews views) : base(services, views) { }

        protected override void OnShow()
        {
            go.SetActive(true);
            component.SetTrigger(AnimationHashes.ShowIn);
        }

        protected override void OnHidden()
        {
            go.SetActive(false);
        }
    }
}