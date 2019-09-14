using System;
using UnityEngine;

namespace Fridge.View
{
    public class ViewReferences : MonoBehaviour
    {
        public Animator Animator;
        public event Action OnHidden;

        public void SetTrigger(int trigger)
        {
            if(Animator != null)
                Animator.SetTrigger(trigger);
        }

        public void OnShownOut()
        {
            OnHidden?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
