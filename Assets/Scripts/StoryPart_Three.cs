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
}