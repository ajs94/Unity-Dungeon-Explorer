using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Rotater : MonoBehaviour
{
    bool rotate = true;

    void Start ()
    {
        if (GetComponent<VRTK_InteractableObject>() == null)
        {
            Debug.LogError("This requires to be attached to an Object that has the VRTK_InteractableObject script attached to it");
            return;
        }
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);
    }

    void Update () 
    {
        if(rotate)
            transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        rotate = false;
    }
}
