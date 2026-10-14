using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public LampController lamp;

    public Sprite onSprite;
    public Sprite offSprite;

    private SpriteRenderer sr;

    private bool playerInRange= false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = offSprite;
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
         {
            
            lamp.ToggleLamp();

            sr.sprite = lamp.IsOn ? onSprite : offSprite;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("Player"))
        {
            
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 

        

        playerInRange = false;

    }
    }
}
