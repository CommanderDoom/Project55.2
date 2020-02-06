using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorsoRotation : MonoBehaviour
{
    public float speedH = 1.5f;
    float yaw = 0.0f;
    private int look = 0;
    private float lookcontrol;
    private int currentyaw = 0;
    private int yawlimit = 45;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookcontrol = Input.GetAxis("Mouse X");

        if (0 < lookcontrol && currentyaw < yawlimit)
        {
            look = 1;
           currentyaw++;
        }
        else if (0 > lookcontrol && currentyaw > -yawlimit)
        {
            look = -1;
            currentyaw--;
        }
        else
        {
            look = 0;
        }

        yaw = speedH * look;
        transform.eulerAngles += new Vector3(0.0f, yaw, 0.0f);
    }
}
