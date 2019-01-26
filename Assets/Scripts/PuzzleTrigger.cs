using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D), typeof(PuzzleReward))]
    public class PuzzleTrigger : MonoBehaviour
    {
        public Puzzle PuzzlePrefab;
        private Puzzle m_puzzleInstance;
        private PuzzleReward m_reward;

        private void Awake()
        {
            m_reward = GetComponent<PuzzleReward>();
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (!m_puzzleInstance)
            {
                var position =  Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f));
                position.z = 0;

                m_puzzleInstance = GameObject.Instantiate(PuzzlePrefab, position, PuzzlePrefab.transform.rotation);
                m_puzzleInstance.OnPuzzleCompleted += OnPuzzleCompleted;

                Game.WorkingOnPuzzle = true;
                gameObject.SetActive(false);
            }
        }

        void OnPuzzleCompleted()
        {
            m_reward.GrantReward();
            DestroyPuzzle();
        }

        void DestroyPuzzle()
        {
            if(m_puzzleInstance)
            {
                m_puzzleInstance.OnPuzzleCompleted -= OnPuzzleCompleted;
                GameObject.Destroy(m_puzzleInstance.gameObject);
            }
        }
    }
}