using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{

    public Sprite sprite1;
    public Sprite sprite2;
    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            spr.sprite = sprite2;
        }
    }

    public void OnTriggerExit2D(Collider2D colliosion)
    {
        if(colliosion.gameObject.name == "Player")
        {
            spr.sprite = sprite1;
        }
    }

}
