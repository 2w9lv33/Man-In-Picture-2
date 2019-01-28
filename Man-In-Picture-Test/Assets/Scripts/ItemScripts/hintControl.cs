using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintControl : MonoBehaviour
{
    public bool flag = false;
    private void Update()
    {
            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player" && !flag)
        {
            transform.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player" && !flag)
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
