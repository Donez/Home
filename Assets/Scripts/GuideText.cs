using Assets.Scripts;
using UnityEngine;

public class GuideText : MonoBehaviour
{
    private GUIStyle guiStyle;

    private string text;

    void Awake()
    {
        guiStyle = new GUIStyle();
        guiStyle.fontSize = 36;
        guiStyle.normal.textColor = Color.white;

        text = "Interact: 'E'\n" +
               "Move: 'A' and 'D'\n" +
               "Jump: 'Space'\n" +
               "Charge Jump: Hold 'S'";
    }

    void OnGUI()
    {
        if (Physics.autoSimulation)
        {
            GUI.Label(new Rect(10, 10, 200, 400), text, guiStyle);
        }
    }
}