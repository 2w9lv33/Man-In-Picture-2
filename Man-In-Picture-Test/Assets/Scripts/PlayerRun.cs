using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    public Animator Player,Enemy;
    public BackgroundRUN BackgroundRUN;
    public Game.Color bookCase;
    [SerializeField] public Vector3 maxP, minP, midP;
    public Vector3 now;
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
        now = transform.position;
        if (Input.GetMouseButtonDown(0))
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
        if(bookCase.myColor == Game.Color.MyColor.BLACK)
        {
            BackgroundRUN.flag = false;
            //Player.SetBool("Stand", true);
            //Enemy.SetBool("Stand", true);
        }
    }

    public void SetUseFalse()
    {
        Player.SetBool("Use", false);
    }
}
