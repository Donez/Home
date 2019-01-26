using UnityEngine;

namespace Assets.Scripts
{
    public class ExampleStoryText : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StoryTeller.DisplayText(
                new StoryText(
                    text: "Hello..", 
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I am a robot..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I'm from a different world..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "Lost in this strange place..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I miss my home..",
                    stopTime: true,
                    preDelaySeconds: 1.0f));
        }
    }
}
