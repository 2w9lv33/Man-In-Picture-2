using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject ammo;
    public Transform ammoPos;
    public Animator Animator;
    private float time = 0f;

    private void Update()
    {
        if(time < 5.2f)
        {
            time += Time.deltaTime;
        }
        else
        {
            time = 0f;
        }
        Animator.SetFloat("time", time);
    }

    public void CreateAmmo()
    {
        Instantiate(ammo, ammoPos);
    }
}
