using UnityEngine;

namespace Assets.Scripts
{
    public class ItemPuzzleReward : PuzzleReward
    {
        public override void GrantReward()
        {
            Debug.Log("Item collected!");
        }
    }
}