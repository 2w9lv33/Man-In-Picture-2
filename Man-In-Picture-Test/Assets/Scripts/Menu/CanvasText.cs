using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasText : MonoBehaviour
{
    public Transform ComicCamera;
    public Transform[] pos;
    public Text[] texts;
    public int num = 0;

    private void Start()
    {
        foreach (var text in texts)
        {
            text.transform.gameObject.SetActive(false);
        }
        texts[0].gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (num < pos.Length && Mathf.Abs(ComicCamera.position.x - pos[num].position.x) < 0.5f) 
        {
            texts[num].gameObject.SetActive(true);
        }
        else
        {
            texts[num].gameObject.SetActive(false);
            num++;
        }
    }
}
