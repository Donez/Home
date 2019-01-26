using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayAnimationPuzzleReward : PuzzleReward
{
    public Animation Animation;

    public override void GrantReward()
    {
        Animation?.Play();
    }
}
