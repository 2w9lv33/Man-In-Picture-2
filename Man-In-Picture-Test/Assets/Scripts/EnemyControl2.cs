using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl2 : MonoBehaviour
{
    public GameObject prefab;
    public void Attack()
    {
        GameObject.Instantiate(prefab, transform.Find("ammo").transform.position, transform.Find("ammo").transform.rotation);
    }
}
