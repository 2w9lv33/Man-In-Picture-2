using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    public Transform ComicCamera;
    public float length = 5f;
    public Transform[] pos;
    public Text[] texts;
    public int num = 0;
    public bool flag = false;

    private void Start()
    {
        foreach (var text in texts)
        {
            text.transform.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (num < pos.Length && Mathf.Abs(ComicCamera.position.x - pos[num].position.x) < 0.5f)
        {
            if (Mathf.Abs(ComicCamera.position.y - pos[num].position.y) < length)
            {
                texts[num].gameObject.SetActive(true);
                flag = false;
            }
            else
            {
                if (!flag)
                {
                    texts[num].gameObject.SetActive(false);
                    num++;
                    flag = true;
                }
            }
        }
    }
}
