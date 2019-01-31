using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public GameObject title, play;
    public Image mask;
    public Animator artist,player;
    public Text text;
    private bool flag = false;

    private void Update()
    {
        if (flag)
        {
            title.GetComponent<Image>().color = Color.Lerp(title.GetComponent<Image>().color, Color.clear, 0.04f);
            play.GetComponent<Image>().color = Color.Lerp(play.GetComponent<Image>().color, Color.clear, 0.04f);
        }
    }

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
        if (!flag)
        {
            text.gameObject.SetActive(true);
            flag = true;
            mask.gameObject.SetActive(false);
            artist.SetBool("draw", true);
            player.SetBool("awake", true);
        }
    }

    public void Reload()
    {
        AsynLoad.LoadScene(transform.name);
    }

}
