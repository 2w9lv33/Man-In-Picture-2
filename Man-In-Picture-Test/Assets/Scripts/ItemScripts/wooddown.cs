using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wooddown : MonoBehaviour
{
    public Animator door;
    
    public void Wooddown()
    {
        door.SetBool("open", true);
    }
}
