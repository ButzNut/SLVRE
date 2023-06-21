using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VrJoystick : MonoBehaviour
{
    public Transform joystickHandle;

    private float _xTilt;
    private float _zTilt;
    
    public MoveShip moveShip;
    
    private void Update()
    {
        if (moveShip == null)
            moveShip = GameObject.FindWithTag("Ship").GetComponent<MoveShip>();
        
        
        _xTilt = joystickHandle.rotation.eulerAngles.x;
        _zTilt = joystickHandle.rotation.eulerAngles.z;

        if (_xTilt > 355 && _xTilt > 290)
        {
            _xTilt = Math.Abs(_xTilt - 360);
        }
        else if (_xTilt > 5 && _xTilt < 74)
        {
            Debug.Log("No Movement");
        }
        
        if (_zTilt > 355 && _zTilt > 290)
        {
            _zTilt = Math.Abs(_zTilt - 360);
        }
        else if (_zTilt > 5 && _zTilt < 74)
        {
            Debug.Log("No Movement");
        }
        
        
        Vector3 movement = new Vector3(_xTilt, 0.0f, _zTilt).normalized;
        
        moveShip.MoveShipXZ(movement);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerHands"))
        {
            transform.LookAt(other.transform.position,transform.up);
        }
    }
}
