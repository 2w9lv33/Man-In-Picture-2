using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform[] positions;
    public GameObject comic;
    private int num,max = 0;
    public int pic = 0;
    private Vector3 position =Vector3.zero;
    private Vector3 dir;
    private bool flag = true;
    // Start is called before the first frame update
    private void Awake()
    {
        max = positions.Length; 
    }
    void Start()
    {
        //StartCoroutine(Movie());
        transform.position = positions[num].position;
    }

    public IEnumerator Movie()
    {
        while (max > 0)
        {
            SetCamera(positions[num].position);
            num++;
            max--;
            yield return new WaitForSeconds(2f);
        }
        if(max== 0)
        {
            AsynLoad.LoadScene(comic.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (flag && max > 0)
        {
            dir = positions[num].position - transform.position;
            flag = false;
        }
        else if(max == 0)
        {
            AsynLoad.LoadScene(comic.name);
        }
        transform.position += dir / 300;
        if(max > 0 && Mathf.Abs(transform.position.y - positions[num].position.y) < 0.2f)
        {
            flag = true;
            num++;
            max--;
        }
    }

    public void SetCamera(Vector3 vector3)
    {
        vector3.z = -10;
        transform.position = vector3;
    }

}
