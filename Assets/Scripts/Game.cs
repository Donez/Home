using UnityEngine;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private static Game Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        public static bool WorkingOnPuzzle = false;

        public static bool IsPlayingCutscene
        {
            get => m_isPlayingCutscene;
            set
            {
                Physics.autoSimulation = !value;
                m_isPlayingCutscene = value;
            }
        }

        private static bool m_isPlayingCutscene = false;

        public static void PlayCutscene(Cutscene cutscene)
        {
            Game.IsPlayingCutscene = true;

            var newCutscene = GameObject.Instantiate(cutscene, Vector3.zero, Quaternion.identity);
            DontDestroyOnLoad(newCutscene.gameObject);

            newCutscene.OnCutsceneFinished += () =>
            {
                Game.IsPlayingCutscene = false;
            };
        }
    }
}