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

    public Collider2D door2;
    public Collider2D door3;

    //Start is called before the first frame update
    void Start()
    {
        door2.enabled = true;
        door3.enabled = true;

        SceneManager.activeSceneChanged += (Scene old, Scene newScene) =>
        {
            door2 = GameObject.Find("Wall0")?.GetComponent<Collider2D>();
            door3 = GameObject.Find("Wall1")?.GetComponent<Collider2D>();
        };
    }

    //Update is called once per frame
    void Update()
    {
        if(level1Progress > 0)
        {
            door2.enabled = false;
        }

        if(level2Progress > 0)
        {
            door3.enabled = false;
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
