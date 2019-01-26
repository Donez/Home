using System;

namespace Assets.Scripts
{
    [Serializable]
    public struct StoryText
    {
        public StoryText(string text, bool stopTime, float preDelaySeconds = 0.0f)
        {
            Text = text;
            StopTime = stopTime;
            PreDelaySecondsSeconds = preDelaySeconds;
        }

        public float PreDelaySecondsSeconds;
        public bool StopTime;
        public string Text;
    }
}