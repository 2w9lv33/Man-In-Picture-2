using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public Transform end;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.tag == "Player" && transform.position.x > end.position.x) 
        {
            transform.position -= new Vector3(4, 0, 0);
            Debug.Log(transform.position);
        }
        else
        {
            if (transform.tag == "Player")
            {
                transform.localScale = new Vector3(1.4f,1,0);
            }
            transform.GetComponent<Animator>().SetBool("get", true);
        }
    }

    public void Load()
    {
        AsynLoad.LoadScene("AfterMenu");
    }

    public void Appear()
    {
        player.SetActive(true);
        transform.gameObject.SetActive(false);
    }
}
