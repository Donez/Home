using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button loadMainButton;
    public Image loadMainImage;
    public Text loadMainText;

    public Button loadLevel1Button;
    public Image loadLevel1Image;
    public Text loadLevel1Text;

    public Button loadLevel2Button;
    public Image loadLevel2Image;
    public Text loadLevel2Text;

    //Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {

    }

    //Enable button on collision
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "MainDoor")
        {
            loadMainButton.enabled = true;
            loadMainImage.enabled = true;
            loadMainText.enabled = true;
            Debug.Log("LoadMainButton enabled");
        }
        else if(collision.gameObject.name == "Door1")
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
    }

    //Disable button on collision exit
    public void OnCollisionExit2D(Collision2D collision)
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
    }
}
