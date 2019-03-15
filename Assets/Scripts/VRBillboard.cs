using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRBillboard : MonoBehaviour
{
    static Transform tCam = null;
    void Update()
    {
        if (!tCam)
        {
            if (!Camera.main)
            {
                return;
            }
            tCam = Camera.main.transform;
        }
        transform.LookAt(tCam.position, Vector3.up);
    }
}