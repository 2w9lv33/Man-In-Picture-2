using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastControl : MonoBehaviour
{
    public Transform enemy, player;
    public PlayerRun PlayerRun;
    public Vector3  temp,destination;
    private float time, num;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        num = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            num = Random.Range(1, 3);
        }
        time += Time.deltaTime*5;
        Cast(1,time);
    }

    public void Cast(int num,float time)
    {
        switch (num)
        {
            case 1:
                Translate(PlayerRun.maxP,time);
                break;
            case 2:
                Translate(PlayerRun.midP, time);
                break;
            case 3:
                Translate(PlayerRun.minP, time);
                break;
            default:
                break;
        }
    }

    public void Translate(Vector3 dst,float time)
    {
        if ((enemy.position.x - dst.x) / 2 > time)
        {
            temp = transform.position;
            temp.x -= Time.deltaTime*5;
            temp.y += Time.deltaTime*5;
            transform.position = temp;
        }
        else
        {
            temp = transform.position;
            temp.x -= Time.deltaTime*5;
            temp.y -= Time.deltaTime*5;
            transform.position = temp;
        }
        if (time > enemy.position.x - dst.x)
        {
            time = 0;
            Destroy(this);
        }
    }
}
