using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Sprite deactivatedButton;
    public Sprite activatedButton;
    public float requiredMass;

    public GameObject door;

    private float triggerMass;
    private Rigidbody2D triggerRb;

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        triggerRb = other.gameObject.GetComponent<Rigidbody2D>();

        triggerMass = triggerRb.mass;

        if (triggerMass >= requiredMass)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - 0.17f);
            OnPressed();
        }
    }

    public void OnPressed()
    {
        Debug.Log("Button Pressed");
    }
}

