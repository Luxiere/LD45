using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brezier : MonoBehaviour
{
    Quaternion init_Rot;
    void Awake()
    {
        Init_Rot();
    }

    public void Init_Rot()
    {
        init_Rot = transform.rotation;
    }

    public void Reverse()
    {
        init_Rot = Quaternion.Euler(new Vector3(init_Rot.eulerAngles.x, init_Rot.eulerAngles.y + 180, init_Rot.eulerAngles.z));
    }

    void Update()
    {
        transform.rotation = init_Rot;
    }
}
