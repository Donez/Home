using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum DoorState
{
    RedClosed,
    RedOpen,
    GreenClosed,
    GreenOpen
}

public class DoorController : MonoBehaviour
{

    public Sprite redClosed;
    public Sprite redOpen;
    public Sprite greenClosed;
    public Sprite greenOpen;

    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDoorState(DoorState state)
    {
        switch (state)
        {
            case DoorState.RedClosed:
                spr.sprite = redClosed;
                break;
            case DoorState.RedOpen:
                spr.sprite = redOpen;
                break;
            case DoorState.GreenClosed:
                spr.sprite = greenClosed;
                break;
            case DoorState.GreenOpen:
                spr.sprite = greenOpen;
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if(spr.sprite == greenClosed)
            {
                spr.sprite = greenOpen;
            }

            if(spr.sprite == redClosed)
            {
                spr.sprite = redOpen;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D colliosion)
    {
        if(colliosion.gameObject.name == "Player")
        {
            if (spr.sprite == greenOpen)
            {
                spr.sprite = greenClosed;
            }

            if (spr.sprite == redOpen)
            {
                spr.sprite = redClosed;
            }
        }
    }

}
