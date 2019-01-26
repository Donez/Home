using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class VinePuzzle : MonoBehaviour
    {
        private List<Draggable> Vines;

        void Awake()
        {
            Vines = GameObject.FindGameObjectsWithTag("Vine")
                .Select(g => g.GetComponent<Draggable>())
                .ToList();

            Vines.ForEach(v => v.OnDragEnd += CheckPuzzle);
        }

        public void CheckPuzzle()
        {
            foreach (var vine in Vines)
            {
                var collider = vine.GetComponent<Collider2D>();

                var collision = Physics2D.OverlapBox(
                    collider.transform.position, 
                    collider.bounds.extents, 0,
                    1 << LayerMask.NameToLayer("Branch"));

                if (collision)
                {
                    Debug.Log($"Vine is still colliding with {collision.name}");
                    return;
                } 
            }

            OnPuzzleCompleted();
        }

        private void OnPuzzleCompleted()
        {
            Debug.Log("Vine puzzle completed");
        }
    }
}