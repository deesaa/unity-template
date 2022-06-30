using UnityEngine;

namespace Ecs.Views.Linkable.Impl
{
    public static class AnimatorExt
    {
        public static void Play(this Animator animator, int stateHash, float playtime)
        {
            animator.Play(stateHash);
            animator.speed = playtime / animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        }
        
        public static void CrossFadeInFixedTime(this Animator animator, int stateHash, float playtime)
        {
            animator.CrossFadeInFixedTime(stateHash, playtime);
        }
    }
}