using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Game : MonoBehaviour
    {
        private static Game Instance;
        private GameObject m_player;

        public GameObject StoryPartOne;
        public GameObject StoryPartTwo;
        public GameObject StoryPartThree;
        public GameObject StoryPartLevelTwo;
        public GameObject StoryPartLevelThree;

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
                InitScene();
            };
        }

        private void InitScene()
        {
            var scene = SceneManager.GetActiveScene();
            bool isMainMenu = scene.name == "MainMenu";
            bool isMainHub = scene.name == "MainHub";
            bool isLevel1 = scene.name == "Level1";
            bool isLevel2 = scene.name == "Level2";
            bool isLevel3 = scene.name == "Level3";
            bool isLastScene = scene.name == "LastScene";

            m_player.gameObject.SetActive(!isMainMenu || isLastScene);

            if (isMainHub || isLastScene)
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

            GameObject spawnOverride = null;

            if (isMainHub)
            {
                var spawns = GameObject.FindGameObjectsWithTag("PlayerSpawn").OrderBy(s => s.name).ToArray();
                if (LevelManager.previousLevel < spawns.Length)
                {
                    spawnOverride = spawns[LevelManager.previousLevel];
                }

                if (LevelManager.level1Progress == 0)
                {
                    // play story part 1
                    GameObject.Instantiate(StoryPartOne, Vector3.zero, Quaternion.identity);
                }
            }

            if (isLevel1 && LevelManager.level1Progress == 0)
            {
                // play story part 2
                GameObject.Instantiate(StoryPartTwo, Vector3.zero, Quaternion.identity);
            }

            if(isLevel2 && LevelManager.level2Progress == 0)
            {
                // play story part level 2
                GameObject.Instantiate(StoryPartLevelTwo, Vector3.zero, Quaternion.identity);
            }

            if (isLevel3 && LevelManager.level3Progress == 0)
            {
                GameObject.Instantiate(StoryPartLevelThree, Vector3.zero, Quaternion.identity);
            }

            if (isLastScene)
            {
                GameObject.Instantiate(StoryPartThree, Vector3.zero, Quaternion.identity);
            }

            if(!isMainMenu && !isLastScene)
                m_player.GetComponent<Player>().ResetPosition(spawnOverride);
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