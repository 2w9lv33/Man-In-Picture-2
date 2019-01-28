using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject door_before,door_after,exit;

    public void Open()
    {
        exit.gameObject.SetActive(true);
    }

    public void Hide()
    {
        transform.gameObject.SetActive(false);
        door_after.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            AsynLoad.LoadScene("End");
        }
    }

}
