using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {

    }

    //Enable button on collision
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainDoor")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(2);
                Debug.Log("LoadMainButton enabled");
            }
        }
        else if (collision.gameObject.name == "Door1")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(3);
                Debug.Log("LoadLevel1Button enabled");
            }
        }
        else if (collision.gameObject.name == "Door2")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(4);
                Debug.Log("LoadLevel2Button enabled");
            }
        }
        else if (collision.gameObject.name == "Door3")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(5);
                Debug.Log("LoadLevel3Button enabled");
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
