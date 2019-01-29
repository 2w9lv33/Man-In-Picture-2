using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public void ReLoad()
    {
        AsynLoad.LoadScene(transform.name);
    }
}
