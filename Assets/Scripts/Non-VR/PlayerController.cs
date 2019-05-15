using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float walkspeed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * walkspeed;
        float verticalMovement = Input.GetAxisRaw("Vertical") * walkspeed;

        transform.Translate(horizontalMovement * Time.deltaTime, 0, verticalMovement * Time.deltaTime);
    }
} 
