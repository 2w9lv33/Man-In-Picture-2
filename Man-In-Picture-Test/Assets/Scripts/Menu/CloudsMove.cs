using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudsMove : MonoBehaviour
{
    public Vector3 speed;
    private Vector3 startPos = new Vector3(-800, 234, 0);

    private void Update()
    {
        transform.position += speed;
        if(transform.position.x > 1200)
        {
            transform.position = startPos;
        }
    }

}
