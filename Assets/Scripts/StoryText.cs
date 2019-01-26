namespace Assets.Scripts
{
    public struct StoryText
    {
        public StoryText(string text, bool stopTime, float preDelaySeconds = 0.0f)
        {
            Text = text;
            StopTime = stopTime;
            PreDelaySecondsSeconds = preDelaySeconds;
        }

        public readonly float PreDelaySecondsSeconds;
        public readonly bool StopTime;
        public readonly string Text;
    }
}