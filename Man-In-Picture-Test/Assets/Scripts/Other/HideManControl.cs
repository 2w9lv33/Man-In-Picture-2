using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideManControl : MonoBehaviour
{
    public Game.Color en1, en2;
    public GameObject enemy1, enemy2;
    public SpriteRenderer Paint;
    public Color Color = Color.clear;
    public GameObject room1, room2;
    private Vector3 down = new Vector3(0, -2, 0);
    private bool isChecked = false;
    public bool flag = false;

    private void Update()
    {
        if(en1.myColor == Game.Color.MyColor.WHITE)
        {
            en2.myColor = Game.Color.MyColor.WHITE;
        }
        if (en2.myColor == Game.Color.MyColor.WHITE)
        {
            en1.myColor = Game.Color.MyColor.WHITE;
        }
        if (en1.myColor == Game.Color.MyColor.WHITE && en2.myColor == Game.Color.MyColor.WHITE && flag)
        {
            LerpColor();
        }
    }
    private void LerpColor()
    {
        Color = Paint.color;
        if (Color.a < 0.8)
        {
            Color.a += 0.004f;
            Paint.color = Color;
            Paint.transform.position += down * Time.deltaTime;
        }
        else
        {
            flag = false;
            room1.SetActive(false);
            room2.SetActive(true);
            Paint.color = Color.clear;
            //Invoke("LoadScene", 1f);
        }
    }

    public void LoadScene()
    {
        AsynLoad.LoadScene("AfterSecond");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(en1.myColor == Game.Color.MyColor.WHITE && en2.myColor == Game.Color.MyColor.WHITE && collision.name == "Player" && !isChecked)
        {
            enemy1.transform.Find("after").gameObject.SetActive(true);
            enemy1.transform.Find("Enemy_1").gameObject.SetActive(false);
            enemy2.transform.Find("after").gameObject.SetActive(true);
            enemy2.transform.Find("Enemy2_1").gameObject.SetActive(false);
            transform.Find("Hideman_1").gameObject.SetActive(false);
            transform.Find("Hideman_2").gameObject.SetActive(true);
            transform.Find("P").gameObject.SetActive(true);
            collision.GetComponent<Animator>().SetBool("Get", true);
            collision.GetComponent<Animator>().SetBool("OnlyGet", true);
            Invoke("HideP", 2);
            flag = true;
            isChecked = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().secondClear = true;
        }
    }

    public void HideP()
    {
        transform.Find("P").gameObject.SetActive(false) ;
    }
}
