using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Image mask;
    public Animator artist,player;
    private bool flag = false;

    public void Scale()
    {
        if (!flag)
        { transform.GetComponent<RectTransform>().localScale *= 1.2f; }
    }

    public void ReScale()
    {
        if (!flag)
        { transform.GetComponent<RectTransform>().localScale = Vector3.one; }
    }

    public void Click()
    {
        flag = true;
        mask.gameObject.SetActive(false);
        artist.SetBool("draw", true);
        player.SetBool("awake", true);
    }
}
