using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public int currentLevel;

    public UnityEngine.UI.Button ContinueButton;
    public Image ContinueImage;
    public Text ContinueText;
    
    public UnityEngine.UI.Button ReturnMenuButton;
    public Image ReturnMenuImage;
    public Text ReturnMenuText;

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
    //Disable all UI at start
    void Start()
    {
        ContinueButton.enabled = false;
        ContinueImage.enabled = false;
        ContinueText.enabled = false;

        ReturnMenuButton.enabled = false;
        ReturnMenuImage.enabled = false;
        ReturnMenuText.enabled = false;
        Debug.Log("In game menu disabled");

        loadMainButton.enabled = false;
        loadMainImage.enabled = false;
        loadMainText.enabled = false;
        Debug.Log("LoadMainButton disabled");

        loadLevel1Button.enabled = false;
        loadLevel1Image.enabled = false;
        loadLevel1Text.enabled = false;
        Debug.Log("LoadLevel1Button disabled");

        loadLevel2Button.enabled = false;
        loadLevel2Image.enabled = false;
        loadLevel2Text.enabled = false;
        Debug.Log("LoadLevel2Button disabled");

        loadLevel3Button.enabled = false;
        loadLevel3Image.enabled = false;
        loadLevel3Text.enabled = false;
        Debug.Log("LoadLevel3Button disabled");
    }

    //Update is called once per frame
    //Toggle the in game menu
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            ContinueButton.enabled = true;
            ContinueImage.enabled = true;
            ContinueText.enabled = true;

            ReturnMenuButton.enabled = true;
            ReturnMenuImage.enabled = true;
            ReturnMenuText.enabled = true;
        }
    }

    //Continue the game
    public void ContinuegameButton()
    {
        ContinueButton.enabled = false;
        ContinueImage.enabled = false;
        ContinueText.enabled = false;

        ReturnMenuButton.enabled = false;
        ReturnMenuImage.enabled = false;
        ReturnMenuText.enabled = false;
    }

    //Change level on button press
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Load main menu");
    }

    public void LoadMainLevel()
    {
        SceneManager.LoadScene(2);
        Debug.Log("Load main level");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(3);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Load level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(4);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("Load level 2");
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene(5);
        Debug.Log("load level 3");
    }
}
