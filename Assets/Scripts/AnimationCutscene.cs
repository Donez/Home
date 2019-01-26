using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animation))]
    public class AnimationCutscene : Cutscene
    {
        void Awake()
        {
            var animation = GetComponent<Animation>();

            var lengthSeconds = animation.clip.length;

            Destroy(gameObject, lengthSeconds);
        }
    }
}