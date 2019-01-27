using UnityEngine;

namespace Assets.Scripts
{
    public class StoryPart_LevelTwo : MonoBehaviour
    {
        void Start()
        {
            StoryTeller.DisplayText(
                new StoryText(
                    text: "I need just a few more pieces..",
                    stopTime: true));
        }
    }
}