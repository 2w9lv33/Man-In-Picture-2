﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public GameObject player;
    public AudioSource open;
    public Animator door;
    [SerializeField] private bool doorIsTriggered = false;

    void Update()
    {
        if (doorIsTriggered)
        {
            if (transform.name == "Door_m" && player.transform.GetComponent<PlayerController>().withKey)
            {
                player.SetActive(false);
                door.SetBool("Open", true);
                open.Play();
            }
            if (transform.name == "Door_m" && player.transform.GetComponent<PlayerController>().secondClear)
            {
                player.SetActive(false);
                door.SetBool("Open", true);
                open.Play();
            }
            if (transform.name == "Door_F")
            {
                player.SetActive(false);
                door.SetBool("Open", true);
                open.Play();
            }
        }
        if (transform.name == "Door_E" && player.transform.GetComponent<PlayerController>().awakeEnemy)
        {
            door.SetBool("Open", true);
            open.Play();
            player.transform.GetComponent<PlayerController>().awakeEnemy = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player" && transform.name == "Door_m")
        {
            doorIsTriggered = true;
            open.Play();
        }
        if (collision.gameObject.name == "Player" && transform.name == "Door_F")
        {
            doorIsTriggered = true;
            open.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player" && transform.name == "Door_T")
        {
            doorIsTriggered = true;
            open.Play();
        }
    }

    public void AwakeEnemy()
    {
        GameObject.FindGameObjectWithTag("Enemy").SetActive(true);
    }

    public void FinishOpen()
    {
        open.Play();
        door.SetBool("Open", false);
    }

    public void LoadComicSceneFirst()
    {
        AsynLoad.LoadSceneAsync("AfterTeach");
    }

    public void LoadComicSceneThird()
    {
        AsynLoad.LoadSceneAsync("AfterSecond");
    }

    public void LoadComicSceneSecond()
    {
        AsynLoad.LoadSceneAsync("AfterFirst");
    }
}
