﻿using UnityEngine;

namespace Assets.Scripts
{
    public class Cutscene : MonoBehaviour
    {
        public delegate void CutsceneFinishedEvent();
        public event CutsceneFinishedEvent OnCutsceneFinished;

        void OnDestroy()
        {
            Game.IsPlayingCutscene = false;
            OnCutsceneFinished?.Invoke();
        }
    }
}