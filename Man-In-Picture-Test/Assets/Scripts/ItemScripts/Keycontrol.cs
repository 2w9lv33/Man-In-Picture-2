using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycontrol : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Unshowkey()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

    }

    public void Showkey()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Invoke("Unshowkey", 3);
    }
}
