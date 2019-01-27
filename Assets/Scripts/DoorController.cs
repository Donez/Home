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

[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour
{
    public Sprite redClosed;
    public Sprite redOpen;
    public Sprite greenClosed;
    public Sprite greenOpen;

    public SpriteRenderer spr;

    private AudioSource m_audioSource;

    private AudioClip m_doorOpen;

    // Start is called before the first frame update
    void Awake()
    {
        m_audioSource = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();

        m_doorOpen = Resources.Load<AudioClip>("door_open");
        m_audioSource.loop = false;
        m_audioSource.volume = 0.7f;
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
                m_audioSource.clip = m_doorOpen;
                m_audioSource.Play();
                break;
            case DoorState.GreenClosed:
                spr.sprite = greenClosed;
                break;
            case DoorState.GreenOpen:
                spr.sprite = greenOpen;
                m_audioSource.clip = m_doorOpen;
                m_audioSource.Play();
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
                SetDoorState(DoorState.GreenOpen);
            }

            if(spr.sprite == redClosed)
            {
                SetDoorState(DoorState.RedOpen);

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
