using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockShip : MonoBehaviour
{
    public Transform spaceDock, spaceShip;
    bool docking = false;


    private void FixedUpdate()
    {
        if (docking)
        {
            spaceShip.position = Vector3.Lerp(spaceShip.position, spaceDock.position, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            docking = true;
        }
    }
}
