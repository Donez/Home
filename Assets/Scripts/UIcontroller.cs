using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    public int currentLevel;
    
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
    //Disable all button at start
    void Start()
    {
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
    }

    //Update is called once per frame
    void Update()
    {
        
    }

    //Change level on button press
    public void LoadMainLevel()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Load main level");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Load level 1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(3);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("Load level 2");
    }
}
