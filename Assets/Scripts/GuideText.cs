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
            var originalWidth = 1980.0f; 
            var originalHeight = 820.0f;

            var scale = Vector3.zero;
            scale.x = Screen.width / originalWidth;
            scale.y = Screen.height / originalHeight;
            scale.z = 1;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

            GUI.Label(new Rect(10, 10, 200, 400), text, guiStyle);
        }
    }
}