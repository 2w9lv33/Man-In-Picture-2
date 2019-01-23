using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideManControl : MonoBehaviour
{
    public Game.Color en1, en2;
    private void Update()
    {
        if (en1.myColor == Game.Color.MyColor.WHITE && en2.myColor == Game.Color.MyColor.WHITE)
        {
            transform.Find("Hideman_1").gameObject.SetActive(false);
            transform.Find("Hideman_2").gameObject.SetActive(true);
        }
    }
}
