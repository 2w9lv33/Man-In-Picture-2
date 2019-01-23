using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampControl : MonoBehaviour
{
    public Game.Color.MyColor color;
    public GameObject White;
    public Game.Color Color;
    public bool red, yellow, green, blue, cyan, purple, orange;
    private void Start()
    {
        red = yellow = green = blue = cyan = purple = orange = false;
    }
    void Update()
    {
        color = Color.myColor;
        CheckColor(color);
        if (red && yellow && green && blue && cyan && purple && orange)
        {
            White.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    public void CheckColor(Game.Color.MyColor color)
    {
        switch (color)
        {
            case Game.Color.MyColor.RED:
                transform.Find("red").gameObject.SetActive(true);
                red = true;
                break;
            case Game.Color.MyColor.BLUE:
                transform.Find("blue").gameObject.SetActive(true);
                blue = true;
                break;
            case Game.Color.MyColor.ORANGE:
                transform.Find("orange").gameObject.SetActive(true);
                orange = true;
                break;
            case Game.Color.MyColor.PURPLE:
                transform.Find("purple").gameObject.SetActive(true);
                purple = true;
                break;
            case Game.Color.MyColor.CYAN:
                transform.Find("cyan").gameObject.SetActive(true);
                cyan = true;
                break;
            case Game.Color.MyColor.YELLOW:
                transform.Find("yellow").gameObject.SetActive(true);
                yellow = true;
                break;
            case Game.Color.MyColor.GREEN:
                transform.Find("green").gameObject.SetActive(true);
                green = true;
                break;
            default:
                break;
        }
    }
}
