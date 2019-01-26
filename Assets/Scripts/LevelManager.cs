using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int level1Progress = 0;
    public int level2Progress = 0;
    public int level3Progress = 0;

    public Collider2D wall0;
    public Collider2D wall1;

    public DoorController door1Controller;
    public DoorController door2Controller;
    public DoorController door3Controller;

    //Start is called before the first frame update
    void Start()
    {
        if(wall0)
        {
            wall0.enabled = true;
            wall1.enabled = true;
        }
        
        InitializeScene();

        SceneManager.activeSceneChanged += (Scene old, Scene newScene) =>
        {
            // this will be executed in future scene changes
            InitializeScene();
        };
    }

    public void InitializeScene()
    {
        wall0 = GameObject.Find("Wall0")?.GetComponent<Collider2D>();
        wall1 = GameObject.Find("Wall1")?.GetComponent<Collider2D>();

        door1Controller = GameObject.Find("Door1")?.GetComponent<DoorController>();
        door2Controller = GameObject.Find("Door2")?.GetComponent<DoorController>();
        door3Controller = GameObject.Find("Door3")?.GetComponent<DoorController>();

        door1Controller?.SetDoorState(level1Progress > 0 ? DoorState.GreenClosed : DoorState.RedClosed);
        door2Controller?.SetDoorState(level2Progress > 0 ? DoorState.GreenClosed : DoorState.RedClosed);
        door3Controller?.SetDoorState(level3Progress > 0 ? DoorState.GreenClosed : DoorState.RedClosed);

        if (level1Progress > 0)
        {
            wall0.enabled = false;
        }

        if (level2Progress > 0)
        {
            wall1.enabled = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Door1")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(3);
            }
        }
        else if (collision.gameObject.name == "Door2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(4);
            }
        }
        else if (collision.gameObject.name == "Door3")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(5);
            }
        }

        if (collision.gameObject.name == "VictoryPoint1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                level1Progress++;
                SceneManager.LoadScene(2);
                Debug.Log("Level 1 compleated");
            }
        }

        if (collision.gameObject.name == "VictoryPoint2")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                level2Progress++;
                SceneManager.LoadScene(2);
                Debug.Log("Level 2 compleated");
            }
        }

        if(collision.gameObject.name == "VictoryPoint3")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                level3Progress++;
                SceneManager.LoadScene(2);
                Debug.Log("Level 3 compleated");
            }
        }
    }

    //Disable button on collision exit
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Door1")
        {
            Debug.Log("LoadLevel1Button disabled");
        }
        else if (collision.gameObject.name == "Door2")
        {
            Debug.Log("LoadLevel2Button disabled");
        }
        else if (collision.gameObject.name == "Door3")
        {
            Debug.Log("LoadLevel3Button disabled");
        }
    }
}
