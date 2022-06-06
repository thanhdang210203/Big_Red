using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class pickUp : MonoBehaviour
{
    Health_Sys currentHealth;
    int healthPickUp = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag == "Heart")
        {
            currentHealth += healthPickUp;
        }
    }
}
