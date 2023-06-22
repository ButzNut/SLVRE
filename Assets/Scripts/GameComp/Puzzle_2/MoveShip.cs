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
