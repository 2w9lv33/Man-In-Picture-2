using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecCanvasControl : MonoBehaviour
{
    public Canvas Canvas;
    public GameObject red;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Canvas.transform.Find("Fuze").GetComponent<Game.Color>().myColor == Game.Color.MyColor.YELLOW)
        {
            red.transform.Find("Light").gameObject.SetActive(true);
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
