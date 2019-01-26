using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StoryPart_One : MonoBehaviour
    {
        void Start()
        {
            StoryTeller.DisplayText(
                new StoryText(
                    text: "Hello..",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I'm from a different world",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "Lost in this strange place",
                    stopTime: true));

            StoryTeller.DisplayText(
                new StoryText(
                    text: "I miss my home",
                    stopTime: true,
                    preDelaySeconds: 1.0f));
        }
    }
}