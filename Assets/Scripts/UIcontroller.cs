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

    public UnityEngine.UI.Button ResetButton;
    public Image ResetImage;
    public Text ResetText;
    
    public UnityEngine.UI.Button ReturnMenuButton;
    public Image ReturnMenuImage;
    public Text ReturnMenuText;

    //Start is called before the first frame update
    //Disable all UI at start
    void Start()
    {
        ContinueButton.enabled = false;
        ContinueImage.enabled = false;
        ContinueText.enabled = false;

        ResetButton.enabled = false;
        ResetImage.enabled = false;
        ResetText.enabled = false;

        ReturnMenuButton.enabled = false;
        ReturnMenuImage.enabled = false;
        ReturnMenuText.enabled = false;
        Debug.Log("In game menu disabled");

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

            ResetButton.enabled = true;
            ResetImage.enabled = true;
            ResetText.enabled = true;

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

        ResetButton.enabled = false;
        ResetImage.enabled = false;
        ResetText.enabled = false;

        ReturnMenuButton.enabled = false;
        ReturnMenuImage.enabled = false;
        ReturnMenuText.enabled = false;
    }

    //Change level on button press
    public void ResetlevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Debug.Log("Level reset");
    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Load main menu");
    }
}
