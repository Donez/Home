using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animation), typeof(Text))]
    public class StoryTeller : MonoBehaviour
    {
        public static StoryTeller Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            m_queuedTexts = new Queue<StoryText>();
            m_text = GetComponent<Text>();
            m_animation = GetComponent<Animation>();
        }

        public static void DisplayText(StoryText text)
        {
            Instance.Display(text);
        }

        private void Display(StoryText text)
        {
            m_queuedTexts.Enqueue(text);

            if (m_update == null)
            {
                m_update = StartCoroutine(DisplayTexts());
            }
        }

        private IEnumerator DisplayTexts()
        {
            while (m_queuedTexts.Count > 0)
            {
                var nextText = m_queuedTexts.Dequeue();

                if (!Game.IsPlayingCutscene)
                {
                    Physics.autoSimulation = !nextText.StopTime;
                }

                if (nextText.PreDelaySecondsSeconds > 0)
                {
                    yield return new WaitForSeconds(nextText.PreDelaySecondsSeconds);
                }

                m_text.text = nextText.Text;

                m_animation.Play();

                while (m_animation.isPlaying)
                    yield return null;

                if(!Game.IsPlayingCutscene && nextText.StopTime)
                {
                    Physics.autoSimulation = true;
                }
            }

            m_update = null;
        }

        private Queue<StoryText> m_queuedTexts;

        private WaitForSeconds m_cachedWait;
        private Text m_text;
        private Animation m_animation;

        private Coroutine m_update;
    }
}