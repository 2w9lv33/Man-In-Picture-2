using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRUN : MonoBehaviour
{
    public GameObject room_1, room_2;
    public GameObject front;
    public GameObject back;
    private Vector3 dis;
    private Vector3 speed;
    private Vector3 Min;

    public bool flag = true;

    private void Start()
    {
        dis = room_2.transform.position - room_1.transform.position;
        front = room_2;
        back = room_1;
        Min = new Vector3(20, 0, 0);
        speed = new Vector3(3, 0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            Run();
        }
        if(front.transform.position.x > 15)
        {
            front = room_1;
            room_1 = room_2;
            room_2 = front;
            back = room_1;
            front.transform.position = back.transform.position + dis;
        }
    }

    public void Run()
    {
        room_1.transform.position += speed *Time.deltaTime;
        room_2.transform.position += speed * Time.deltaTime;
    }
}
