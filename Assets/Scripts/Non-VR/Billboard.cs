using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://www.justinreinhart.com/2016/07/08/pixel-perfect-billboard-sprites/

public class Billboard : MonoBehaviour {

    public Transform MyCameraTransform;
    private Transform MyTransform;
    public bool alignNotLook = true;

    // Use this for initialization
    void Start()
    {
        MyTransform = this.transform;
        MyCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (alignNotLook)
            MyTransform.forward = MyCameraTransform.forward;
        else
            MyTransform.LookAt(MyCameraTransform, Vector3.up);
    }
}
