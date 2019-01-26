using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public Sprite deactivatedButton;
    public Sprite activatedButton;
    public float requiredMass;

    public Sprite closedDoor;
    public Sprite openedDoor;

    public GameObject door;

    private float triggerMass;
    private Rigidbody2D triggerRb;

    public bool holdButton = false;

    private GameObject triggerObj;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(triggerObj);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        triggerRb = other.gameObject.GetComponent<Rigidbody2D>();

        triggerMass = triggerRb.mass;

        if (triggerMass >= requiredMass)
        {
            triggerObj = other.gameObject;
            gameObject.GetComponent<SpriteRenderer>().sprite = activatedButton;
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == triggerObj)
        {
            if (holdButton == true)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = deactivatedButton;

                CloseDoor();
            }
        }


    }

    public void OpenDoor()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = openedDoor;
        gameObject.transform.GetChild(0).GetComponent<Collider2D>().enabled = false;
    }

    public void CloseDoor()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = closedDoor;
    }
   

}

