using UnityEngine;

namespace Assets.Scripts
{
    public class SampleReward : PuzzleReward
    {
        public override void GrantReward()
        {
            Debug.Log("Grant sample reward!");
        }
    }
}