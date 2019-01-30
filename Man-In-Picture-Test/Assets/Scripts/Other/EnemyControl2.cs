using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl2 : MonoBehaviour
{
    public GameObject prefab;
    public AudioSource bullet;
    public void Attack()
    {
        bullet.Play();
        GameObject.Instantiate(prefab, transform.Find("ammo").transform.position, transform.Find("ammo").transform.rotation);
    }
}
