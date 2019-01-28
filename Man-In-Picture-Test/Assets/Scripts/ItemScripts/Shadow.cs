using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public SpriteRenderer player;
    public bool underLight = false;
    private Vector3 dis;

    private void Start()
    {
        dis = player.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position - dis;
        transform.GetComponent<SpriteRenderer>().sprite = player.sprite;
        if (underLight)
        {
            transform.GetComponent<SpriteRenderer>().enabled = true;
            transform.GetComponent<Game.Color>().canBeGet = true;
        }
        else
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            transform.GetComponent<Game.Color>().canBeGet = false;
        }
    }
}
