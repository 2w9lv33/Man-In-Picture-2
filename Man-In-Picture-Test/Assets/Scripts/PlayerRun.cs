using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public Animator Player,Enemy;
    public BackgroundRUN BackgroundRUN;
    public Game.Color bookCase1 , bookCase2;
    public bool reload,die = false;
    [SerializeField] public Vector3 maxP, minP, midP;
    private Vector3 now;
    private Vector3 mousePos = Vector3.zero;

    private void Start()
    {
        midP = transform.position;
        maxP = transform.position + new Vector3(-4, 0, 0);
        minP = transform.position + new Vector3(4, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (die)
        {
            transform.position += new Vector3(0.08f, 0, 0);
            Invoke("Reload", 1f);
        }
        now = transform.position;
        if (Input.GetMouseButtonDown(0) && !IsItem(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            if (Mathf.Abs(now.x-maxP.x)< 0.2f)
            {
                if (mousePos.x > now.x)
                {
                    Debug.Log("max to mid");
                    transform.position = midP;
                }
            }
            if (Mathf.Abs(now.x - minP.x) < 0.2f)
            {
                if (mousePos.x < now.x)
                {
                    Debug.Log("min to mid");
                    transform.position = midP;
                }
            }
            if (Mathf.Abs(now.x - midP.x) < 0.2f)
            {
                if (mousePos.x > now.x)
                {
                    Debug.Log("mid to min");
                    transform.position = minP;
                }
                else
                {
                    Debug.Log("mid to max");
                    transform.position = maxP;
                }
            }
        }
        if(bookCase2.myColor == Game.Color.MyColor.BLACK || bookCase1.myColor == Game.Color.MyColor.BLACK)
        {
            Invoke("LoadLastScene", 2f);
        }
    }

    public void Reload()
    {
        AsynLoad.LoadScene("ThirdScene");
    }

    public void LoadLastScene()
    {
        AsynLoad.LoadScene("LastScene");
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

    public void SetDieFalse()
    {
        Player.SetBool("die", true);
    }

    public void LoadLastSecne()
    {
        AsynLoad.LoadScene("ThirdScene");
    }

    public void SetUseFalse()
    {
        Player.SetBool("Use", false);
    }
}
