using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private static Game Instance;
        private GameObject m_player;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;

            m_player = GameObject.FindGameObjectWithTag("Player");

            SceneManager.activeSceneChanged += (Scene old, Scene newScene) =>
            {
                bool isMainMenu = newScene.name == "MainMenu";

                m_player.gameObject.SetActive(!isMainMenu);

                if (isMainMenu)
                {
                    Camera.main.orthographicSize = 4.7f;
                }
                else
                {
                    Camera.main.orthographicSize = 10.0f;
                    m_player.GetComponent<Player>().ResetPosition();
                }
            };
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