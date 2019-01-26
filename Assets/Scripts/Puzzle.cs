using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Puzzle : MonoBehaviour
    {
        public delegate void PuzzleCompletedEvent();

        protected void OnPuzzleComplete()
        {
            Game.WorkingOnPuzzle = false;
            OnPuzzleCompleted?.Invoke();
        }

        public event PuzzleCompletedEvent OnPuzzleCompleted;
    }
}