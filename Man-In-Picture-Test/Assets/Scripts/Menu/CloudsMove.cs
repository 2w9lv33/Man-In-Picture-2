using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudsMove : MonoBehaviour
{
    public Vector3 speed;
    public Transform start;

    private void Update()
    {
        transform.position += speed;
        if(transform.position.x > 1200)
        {
            transform.position = start.position;
        }
    }

}
