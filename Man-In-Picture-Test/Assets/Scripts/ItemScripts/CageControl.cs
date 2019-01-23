using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CageControl : MonoBehaviour
{
    public Animator cage1, cage2;
    public Game.Color color;
    public GameObject bigman;
    public SpriteMask SpriteMask;
    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(color.myColor == color.checkColor)
        {
            cage1.SetBool("Save", true);
            cage2.SetBool("Save", true);
            transform.Find("Pop").gameObject.SetActive(false);
            SpriteMask.enabled = true;
            Player.GetComponent<Animator>().SetBool("Get",true);
            color.checkColor = Game.Color.MyColor.NOCOLOR;
            GameObject.Find("key").GetComponent<SpriteRenderer>().enabled = true;
            Invoke("Unshowkey", 3);
        }
        else
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        switch (color.myColor)
        {
            case Game.Color.MyColor.RED:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.WALL:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.BLUE:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.BLACK:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.NOCOLOR:
                transform.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
                break;
            default:
                break;
        }
    }

    public void SetBigMan()
    {
        bigman.SetActive(true);
    }

    public void Unshowkey()
    {
        GameObject.Find("key").GetComponent<SpriteRenderer>().enabled = false;

    }

}
