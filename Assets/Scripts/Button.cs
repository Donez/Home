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

    public List<Rigidbody2D> weights = new List<Rigidbody2D>();

    public bool holdButton = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        var newWeight = other.GetComponent<Rigidbody2D>();
        weights.Add(newWeight);

        if (GetWeightsTotalMass() >= requiredMass)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = activatedButton;
            OpenDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        var removedWeight = col.GetComponent<Rigidbody2D>();
        weights.Remove(removedWeight);

        if (GetWeightsTotalMass() < requiredMass)
        {
            if (holdButton == true)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = deactivatedButton;

                CloseDoor();
            }
        }
    }

    private float GetWeightsTotalMass()
    {
        float totalMass = 0.0f;
        foreach (var weight in weights)
        {
            totalMass += weight.mass;
        }

        return totalMass;
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

