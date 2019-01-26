using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public UnityEngine.UI.Button loadMainButton;
    public Image loadMainImage;
    public Text loadMainText;

    public UnityEngine.UI.Button loadLevel1Button;
    public Image loadLevel1Image;
    public Text loadLevel1Text;

    public UnityEngine.UI.Button loadLevel2Button;
    public Image loadLevel2Image;
    public Text loadLevel2Text;

    public UnityEngine.UI.Button loadLevel3Button;
    public Image loadLevel3Image;
    public Text loadLevel3Text;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {

    }

    //Enable button on collision
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MainDoor")
        {
            //loadMainButton.enabled = true;
            //loadMainImage.enabled = true;
            loadMainText.enabled = true;

            if(Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(2);
            }

            Debug.Log("LoadMainButton enabled");
        }
        else if (collision.gameObject.name == "Door1")
        {
            loadLevel1Button.enabled = true;
            loadLevel1Image.enabled = true;
            loadLevel1Text.enabled = true;
            Debug.Log("LoadLevel1Button enabled");
        }
        else if (collision.gameObject.name == "Door2")
        {
            loadLevel2Button.enabled = true;
            loadLevel2Image.enabled = true;
            loadLevel2Text.enabled = true;
            Debug.Log("LoadLevel2Button enabled");
        }
        else if (collision.gameObject.name == "Door3")
        {
            loadLevel3Button.enabled = true;
            loadLevel3Image.enabled = true;
            loadLevel3Text.enabled = true;
            Debug.Log("LoadLevel3Button enabled");
        }
    }

    //Disable button on collision exit
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Door1")
        {
            loadLevel1Button.enabled = false;
            loadLevel1Image.enabled = false;
            loadLevel1Text.enabled = false;
            Debug.Log("LoadLevel1Button disabled");
        }
        else if (collision.gameObject.name == "Door2")
        {
            loadLevel2Button.enabled = false;
            loadLevel2Image.enabled = false;
            loadLevel2Text.enabled = false;
            Debug.Log("LoadLevel2Button disabled");
        }
        else if (collision.gameObject.name == "Door3")
        {
            loadLevel3Button.enabled = false;
            loadLevel3Image.enabled = false;
            loadLevel3Text.enabled = false;
            Debug.Log("LoadLevel3Button disabled");
        }
    }
}
