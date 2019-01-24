using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorSystem : MonoBehaviour
{
    public GameObject player;
    public PlayerController PlayerController;
    public Animator animator;
    private Vector3 mousePosition;
    [SerializeField]public bool Use = false;
    public bool IsUILayer = false;
    public SpriteMask spriteMask;
    [SerializeField] public Game.Color.MyColor palette;
    public SpriteRenderer player2;

    private void Update()
    {
        Click();
        OnClickUse();
        ChangePlayerColor(palette);
        IsUILayer = false;
    }

    public void OnClickUse()
    {
        if (Mathf.Abs(player.transform.position.x - mousePosition.x) < 3f && Use)
        {
            GetColor(mousePosition);
            Use = false;
            player.GetComponent<PlayerMove>().moveVelocity = 0f;
            animator.SetFloat("Speed", -5f);
        }
    }
    public void Click()
    {
        if (palette == Game.Color.MyColor.NOCOLOR && IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) && !IsUILayer)
            {
                Use = true;
                mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (palette != Game.Color.MyColor.NOCOLOR && IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            if (Input.GetMouseButtonDown(0) && !IsUILayer)
            {
                Use = true;
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
            if ((hit.transform.tag == "Item" || hit.transform.tag == "Enemy") && hit.transform.GetComponent<Game.Color>().canBeSet && palette != Game.Color.MyColor.NOCOLOR)
            {
                PlayerController.canMove = false;
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
        if(hit.collider != null)
        {
            if ((hit.transform.tag == "Item" || hit.transform.tag == "Enemy") && hit.transform.GetComponent<Game.Color>().canBeGet)
            {
                PlayerController.canMove = false;
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
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.red;
                break;
            case Game.Color.MyColor.CYAN:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.cyan;
                break;
            case Game.Color.MyColor.GREEN:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.green;
                break;
            case Game.Color.MyColor.PURPLE:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = Game.Color.Purple;
                break;
            case Game.Color.MyColor.ORANGE:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = Game.Color.Orange;
                break;
            case Game.Color.MyColor.BLUE:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.blue;
                break;
            case Game.Color.MyColor.YELLOW:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;
                break;
            case Game.Color.MyColor.BLACK:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.NOCOLOR:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.gray;
                break;
            case Game.Color.MyColor.WHITE:
                colorfulOff();
                player.GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
                break;
            case Game.Color.MyColor.HASCOLOR:
                colorfulOn();
                break;
            default:
                break;
        }
    }

    public void colorfulOn()
    {
        player2.enabled = true;
        spriteMask.enabled = true;
        player.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
    }

    public void colorfulOff()
    {
        player2.enabled = false;
        spriteMask.enabled = false;
        player.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
    }
}
