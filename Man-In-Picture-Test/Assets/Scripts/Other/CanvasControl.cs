using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{

    public AudioSource get, set;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public ColorSystem ColorSystem;
    //public Image UI;
    //public ColorSystem ColorSystem;


    public Texture2D cursorTexture_0;
    public Texture2D cursorTexture_1;
    public Texture2D cursorTexture_2;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public Vector3 mousePosition;

    void Start()
    {
        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = GetComponent<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetItem(mousePosition);
        Click();
    }

    public void Click()
    {
        if (ColorSystem.palette == Game.Color.MyColor.NOCOLOR)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);
                m_PointerEventData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                m_Raycaster.Raycast(m_PointerEventData, results);
                if (results.Count > 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().moveVelocity = 0f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Speed", -5f);
                    if (results[0].gameObject.tag == "Item" && results[0].gameObject.GetComponent<Game.Color>().canBeGet)
                    {
                        get.Play();
                        ColorSystem.palette = results[0].gameObject.GetComponent<Game.Color>().myColor;
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_PointerEventData = new PointerEventData(m_EventSystem);
                m_PointerEventData.position = Input.mousePosition;
                List<RaycastResult> results = new List<RaycastResult>();
                m_Raycaster.Raycast(m_PointerEventData, results);
                if (results.Count > 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().moveVelocity = 0f;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Speed", -5f);
                    if (results[0].gameObject.tag == "Item" && results[0].gameObject.GetComponent<Game.Color>().canBeSet)
                    {
                        set.Play();
                        results[0].gameObject.GetComponent<Game.Color>().myColor = ColorSystem.palette;
                        ColorSystem.palette = Game.Color.MyColor.NOCOLOR;
                    }
                }
            }
        }
    }


    private void GetItem(Vector3 mousePosition)
    {
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        m_Raycaster.Raycast(m_PointerEventData, results);
        if (results.Count > 0)
        {
            if (results[0].gameObject.tag == "Item")
            {
                Debug.Log(results[0].gameObject.name);
                if (ColorSystem.palette == Game.Color.MyColor.NOCOLOR)
                {
                    if (results[0].gameObject.GetComponent<Game.Color>() != null && results[0].gameObject.GetComponent<Game.Color>().canBeSet && !results[0].gameObject.GetComponent<Game.Color>().canBeGet)
                    {
                        Cursor.SetCursor(cursorTexture_1, hotSpot, cursorMode);
                    }
                    else
                    {
                        Cursor.SetCursor(cursorTexture_0, hotSpot, cursorMode);
                    }
                }
                else
                {
                    if (results[0].gameObject.GetComponent<Game.Color>() != null && results[0].gameObject.GetComponent<Game.Color>().canBeGet && !results[0].gameObject.GetComponent<Game.Color>().canBeSet)
                    {
                        Cursor.SetCursor(null, hotSpot, cursorMode);
                    }
                    else
                    {
                        Cursor.SetCursor(cursorTexture_2, hotSpot, cursorMode);
                    }
                }
                ColorSystem.IsUILayer = true;
            }
            else
            {
                Cursor.SetCursor(null, hotSpot, cursorMode);
                ColorSystem.IsUILayer = true;
            }
        }
        else
        {
            ColorSystem.IsUILayer = false;
        }
    }

    //public void ChangeUI(Game.Color.MyColor myColor)
    //{
    //    switch (myColor)
    //    {
    //        case Game.Color.MyColor.RED:
    //            UI.color = UnityEngine.Color.red;
    //            break;
    //        case Game.Color.MyColor.ORANGE:
    //            UI.color = UnityEngine.Color.red;
    //            break;
    //        case Game.Color.MyColor.CYAN:
    //            UI.color = UnityEngine.Color.cyan;
    //            break;
    //        case Game.Color.MyColor.BLUE:
    //            UI.color = UnityEngine.Color.blue;
    //            break;
    //        case Game.Color.MyColor.YELLOW:
    //            UI.color = UnityEngine.Color.yellow;
    //            break;
    //        case Game.Color.MyColor.BLACK:
    //            UI.color = UnityEngine.Color.gray;
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
