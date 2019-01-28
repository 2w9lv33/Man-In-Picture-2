using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private Game.Color.MyColor myColor;
    public Game.Color Color;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myColor = Color.myColor;
        ChangeColor();
    }
    public void ChangeColor()
    {
        switch (myColor)
        {
            case Game.Color.MyColor.RED:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.ORANGE:
                transform.GetComponent<SpriteRenderer>().color = Game.Color.Orange;
                break;
            case Game.Color.MyColor.PURPLE:
                transform.GetComponent<SpriteRenderer>().color = Game.Color.Purple;
                break;
            case Game.Color.MyColor.CYAN:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.BLUE:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.GREEN:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
                break;
            case Game.Color.MyColor.BLACK:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.WHITE:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
                break;
            case Game.Color.MyColor.NOCOLOR:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            default:
                break;
        }
    }
}
