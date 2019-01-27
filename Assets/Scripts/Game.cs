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

            InitScene();

            SceneManager.activeSceneChanged += (Scene old, Scene newScene) =>
            {
                InitScene();
            };
        }

        private void InitScene()
        {
            var scene = SceneManager.GetActiveScene();
            bool isMainMenu = scene.name == "MainMenu";
            bool isMainHub = scene.name == "MainHub";

            m_player.gameObject.SetActive(!isMainMenu);

            if (isMainHub)
            {
                Camera.main.transform.localPosition = new Vector3(0, 2.5f, -10.0f);
                Camera.main.orthographicSize = 4.7f;
            }
            else if (isMainMenu)
            {
                Camera.main.transform.localPosition = new Vector3(0, 0.0f, -10.0f);
                Camera.main.orthographicSize = 5.0f;
            }
            else
            {
                Camera.main.transform.localPosition = new Vector3(0, 0.0f, -10.0f);
                Camera.main.orthographicSize = 10.0f;
            }

            if(!isMainMenu)
                m_player.GetComponent<Player>().ResetPosition();
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