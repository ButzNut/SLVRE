using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpForceTrigger : MonoBehaviour
{
    public EqualForceScale equalForceScale;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MeasureableWeight"))
        {
            other.tag = "UpForce";
            equalForceScale._impulseUpPerRigidBody.Add(other.GetComponent<Rigidbody>(), 0);
        }
        else if (other.CompareTag("UpForce"))
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.up;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MeasureableWeight"))
        {
            other.tag = "UpForce";
            equalForceScale._impulseUpPerRigidBody.Add(other.GetComponent<Rigidbody>(), 0);
        }
        else if (other.CompareTag("UpForce"))
        {
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.up * Physics.gravity.magnitude;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.tag = "MeasureableWeight";
        equalForceScale._impulseUpPerRigidBody.Remove(other.GetComponent<Rigidbody>());
        other.GetComponent<Rigidbody>().useGravity = true;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}