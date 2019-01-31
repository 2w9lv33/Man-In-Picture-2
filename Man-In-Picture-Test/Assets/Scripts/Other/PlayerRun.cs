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
    private Vector3 clickPos = Vector3.zero;
    private Vector3 dst = Vector3.zero;
    private float speed = 0f;

    private void Start()
    {
        midP = transform.position;
        maxP = transform.position + new Vector3(-4, 0, 0);
        minP = transform.position + new Vector3(4, 0, 0);
        mousePos = midP;
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
        MoveTo(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            clickPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(clickPos.x - now.x>0f)
            {
                mousePos = minP;
            }
            else
            {
                mousePos = maxP;
            }
        }
        if (bookCase2.myColor == Game.Color.MyColor.BLACK || bookCase1.myColor == Game.Color.MyColor.BLACK)
        {
            Invoke("LoadLastScene", 0.4f);
        }
    }

    public void MoveTo(Vector3 pos)
    {
        if(Mathf.Abs(transform.position.x - pos.x) > 0.05f)
        {
            speed = (mousePos.x - midP.x > 0 ? 4 : -4);
            dst.x = speed;
            transform.GetComponent<Rigidbody2D>().velocity = dst;
            Debug.Log("speed"+dst+"pos"+mousePos);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
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
