using UnityEngine;

namespace Assets.Scripts
{
    public class StoryPart_Three : MonoBehaviour
    {
        public Cutscene Cutscene;

        private void Start()
        {
            Game.PlayCutscene(Cutscene);
        }
    }
    
    public class StoryPart_Two : MonoBehaviour
    {
        void Start()
        {
            StoryTeller.DisplayText(
                new StoryText(
                    text: "What if I can't get back..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I should start building a new home",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "There should be some parts around here",
                    stopTime: true));
        }
    }
}