using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class ShipHandler : MonoBehaviour
{
    public XRJoystick joyStick;
    public MoveShip moveShip;
    
    // Update is called once per frame
    void Update()
    {
        if (moveShip == null)
            moveShip = GameObject.FindWithTag("Ship").GetComponent<MoveShip>();

        Vector3 joyToShip = new Vector3(joyStick.value.x, 0, joyStick.value.y);
        
        moveShip.MoveShipXZ(joyToShip);
    }
}
