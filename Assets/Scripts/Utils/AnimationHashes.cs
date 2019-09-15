using UnityEngine;

namespace Fridge
{
    public static class AnimationHashes
    {
        public static readonly int ShowOut = Animator.StringToHash("showOut");
        public static readonly int ShowIn = Animator.StringToHash("showIn");
        public static readonly int Pressed = Animator.StringToHash("pressed");
        public static readonly int Clicked = Animator.StringToHash("clicked");
    }
}