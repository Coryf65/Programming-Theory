using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public 

    private float horizontalMovement;
    private float verticalMovement;
    
    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontalMovement + transform.forward * verticalMovement;
    }
}
