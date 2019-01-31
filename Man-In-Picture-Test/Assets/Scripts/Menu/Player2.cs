using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public Transform start, end;
    public Animator palette;
    public bool flag = false;
    public AudioSource eraser;
    public Text text;

    private void Update()
    {
        if (flag)
        {
            if (transform.position.x > end.position.x)
            {
                transform.position += new Vector3(-3, 0, 0);
            }
            else
            {
                text.gameObject.SetActive(true);
                transform.GetComponent<Animator>().SetBool("draw", true);
                palette.SetBool("draw", true);
                if (!eraser.isPlaying)
                {
                    eraser.Play();
                }
                transform.localScale = new Vector3(1.6f, 1.4f, 1);
            }
        }
    }

    public void Walk()
    {
        transform.GetComponent<Animator>().SetBool("walk", true);
        transform.localScale = new Vector3(-0.4f, 1, 1);
        flag = true;
    }

    public void Art()
    {
        transform.GetComponent<Animator>().SetBool("artist", true);
    }

    public void Load()
    {
        Invoke("LoadMenu", 1.2f);
    }

    public void LoadMenu()
    {
        AsynLoad.LoadScene("Menu");
    }
}
