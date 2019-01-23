using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabControl : MonoBehaviour
{
    public Canvas Canvas;
    public Image[] images;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MixColor();
    }

    public void MixColor()
    {
        if(images[0].GetComponent<Game.Color>().myColor == Game.Color.MyColor.BLUE)
        {
            if (images[2].GetComponent<Game.Color>().myColor == Game.Color.MyColor.RED)
            {
                images[1].GetComponent<Game.Color>().myColor = Game.Color.MyColor.PURPLE;
            }
            if (images[2].GetComponent<Game.Color>().myColor == Game.Color.MyColor.YELLOW)
            {
                images[1].GetComponent<Game.Color>().myColor = Game.Color.MyColor.GREEN;
            }
        }
        if (images[2].GetComponent<Game.Color>().myColor == Game.Color.MyColor.BLUE)
        {
            if (images[0].GetComponent<Game.Color>().myColor == Game.Color.MyColor.RED)
            {
                images[1].GetComponent<Game.Color>().myColor = Game.Color.MyColor.PURPLE;
            }
            if (images[0].GetComponent<Game.Color>().myColor == Game.Color.MyColor.YELLOW)
            {
                images[1].GetComponent<Game.Color>().myColor = Game.Color.MyColor.GREEN;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Canvas.gameObject.SetActive(false);
        }
    }
}
