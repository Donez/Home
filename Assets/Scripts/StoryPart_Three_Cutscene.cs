using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class StoryPart_Three_Cutscene : Cutscene
    {
        private float m_targetCameraSize;
        private bool m_cameraFullZoom;
        private float m_runtime;

        private void Start()
        {
            m_targetCameraSize = Camera.main.orthographicSize * 2;

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I've found everything",
                    stopTime: true,
                    preDelaySeconds: 0.5f));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "To repair my friend",
                    stopTime: true,
                    preDelaySeconds: 0.5f));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "Home is friends and loved ones",
                    stopTime: true,
                    preDelaySeconds: 1.0f));
        }

        private void Update()
        {
            if (Math.Abs(Camera.main.orthographicSize - m_targetCameraSize) < 0.1f)
            {
                return;
            }

            Camera.main.orthographicSize = Mathf.LerpUnclamped(Camera.main.orthographicSize, m_targetCameraSize, Time.deltaTime * 0.1f);
        }

        private void OnFullZoom()
        {
            if (!m_cameraFullZoom)
            {
                m_cameraFullZoom = true;
            }
        }
    }
}