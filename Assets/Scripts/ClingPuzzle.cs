using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClingPuzzle : Puzzle
    {
        private List<Draggable> ClingyCreatures;

        void Awake()
        {
            ClingyCreatures = GameObject.FindGameObjectsWithTag("Clingy")
                .Select(g => g.GetComponent<Draggable>())
                .ToList();

            ClingyCreatures.ForEach(v => v.OnDragEnd += CheckPuzzle);
        }

        public void CheckPuzzle()
        {
            foreach(var vine in ClingyCreatures)
            {
                var collider = vine.GetComponent<Collider2D>();

                var collision = Physics2D.OverlapBox(
                    collider.transform.position,
                    collider.bounds.extents, 0,
                    1 << LayerMask.NameToLayer("DragAwayFrom"));

                if(collision)
                {
                    Debug.Log($"Clingy creature is still clinging to {collision.name}");
                    return;
                }
            }

            Debug.Log($"Clingy puzzle completed");
            OnPuzzleComplete();
        }
    }
}