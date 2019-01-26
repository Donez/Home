using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class StoryPart_Three_Cutscene : Cutscene
    {
        private float m_targetCameraSize;
        private bool m_cameraFullZoom;

        private void Start()
        {
            m_targetCameraSize = Camera.main.orthographicSize * 2;

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I found everything",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "To repair my friend, because..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "Home is where my loved ones are",
                    stopTime: true,
                    preDelaySeconds: 1.0f));
        }

        private void Update()
        {
            if (Math.Abs(Camera.main.orthographicSize - m_targetCameraSize) < 0.1f)
            {
                return;
            }

            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, m_targetCameraSize, Time.deltaTime);
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