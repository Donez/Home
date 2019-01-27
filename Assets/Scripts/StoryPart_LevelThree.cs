using UnityEngine;

namespace Assets.Scripts
{
    public class StoryPart_LevelThree : MonoBehaviour
    {
        void Start()
        {
            StoryTeller.DisplayText(
                new StoryText(
                    text: "Hmm..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "One more should do..",
                    stopTime: true));
        }
    }
}