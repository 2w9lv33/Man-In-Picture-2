using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicCamera : MonoBehaviour
{
    public Transform[] positions;
    public GameObject comic;
    private int num,max = 0;
    private Vector3 position =Vector3.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        max = positions.Length; 
    }
    void Start()
    {
        StartCoroutine(Movie());
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
        
    }

    public void SetCamera(Vector3 vector3)
    {
        vector3.z = -10;
        transform.position = vector3;
    }
}
