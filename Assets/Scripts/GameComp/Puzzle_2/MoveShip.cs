using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
       float moveLeftRight = Input.GetAxis("Horizontal");
       float moveForwardBackward = Input.GetAxis("Vertical");
       
       Vector3 movement = new Vector3(moveLeftRight, 0.0f, moveForwardBackward);
       
       
       
       MoveShipXZ(movement);
       
         if (Input.GetKey(KeyCode.E))
         {
              MoveShipY(Vector3.up);
         }
         else if (Input.GetKey(KeyCode.Q))
         {
              MoveShipY(Vector3.down);
         }
    }

    public void MoveShipXZ(Vector3 direction)
    {
        direction = rb.rotation * direction;
        rb.AddForce(direction * movementSpeed);
    }
    
    public void MoveShipY(Vector3 direction)
    {
        rb.AddForce(direction * movementSpeed);
    }
}
