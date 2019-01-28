using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSystem_2 : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    private Vector3 mousePosition;
    [SerializeField] public bool Get = false;
    public bool Set = false;
    [SerializeField] public Game.Color.MyColor palette;

    private void Update()
    {
        Click();
        OnClickGet();
        OnClickSet();
        ChangePlayerColor(palette);
    }

    public void OnClickGet()
    {
        if (Mathf.Abs(player.transform.position.x - mousePosition.x) < 3f && Get)
        {
            GetColor(mousePosition);
            Get = false;
        }
    }

    public void OnClickSet()
    {
        if (Mathf.Abs(player.transform.position.x - mousePosition.x) < 3f && Set)
        {
            SetColor(mousePosition);
            Set = false;
        }
    }

    public void Click()
    {
        if (palette == Game.Color.MyColor.NOCOLOR && IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) )
            {
                Get = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (palette != Game.Color.MyColor.NOCOLOR && IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Set = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    //set color
    private void SetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if ((hit.transform.tag == "Item") && hit.transform.GetComponent<Game.Color>().canBeSet && palette != Game.Color.MyColor.NOCOLOR)
            {
                animator.SetBool("Use", true);
                hit.transform.GetComponent<Game.Color>().myColor = palette;
                palette = Game.Color.MyColor.NOCOLOR;
                ChangePlayerColor(palette);
            }
        }
    }

    public bool IsItem(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Item")
            {
                return true;
            }
        }
        return false;
    }

    //get color
    private void GetColor(Vector3 mousePosition)
    {
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider != null)
        {
            if ((hit.transform.tag == "Item") && hit.transform.GetComponent<Game.Color>().canBeGet)
            {
                animator.SetBool("Use", true);
                palette = hit.transform.GetComponent<Game.Color>().myColor;
                ChangePlayerColor(palette);
            }
        }
    }

    public void ChangePlayerColor(Game.Color.MyColor myColor)
    {
        player.GetComponent<Game.Color>().myColor = myColor;
        switch (myColor)
        {
            case Game.Color.MyColor.RED:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.CYAN:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.GREEN:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
                break;
            case Game.Color.MyColor.PURPLE:
                player.GetComponent<SpriteRenderer>().color = Game.Color.Purple;
                break;
            case Game.Color.MyColor.ORANGE:
                player.GetComponent<SpriteRenderer>().color = Game.Color.Orange;
                break;
            case Game.Color.MyColor.BLUE:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.BLACK:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.NOCOLOR:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
                break;
            case Game.Color.MyColor.WHITE:
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
                break;
            case Game.Color.MyColor.HASCOLOR:
                break;
            default:
                break;
        }
    }

}
