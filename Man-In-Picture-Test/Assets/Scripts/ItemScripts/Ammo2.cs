using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo2 : MonoBehaviour
{
    private Vector3 vector3 = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        vector3 = new Vector3(2, 0, 0);
        StartCoroutine(WaitToDestroy(4));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vector3 * Time.deltaTime;
    }

    private IEnumerator WaitToDestroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
