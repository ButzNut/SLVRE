using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EqualForceScale : MonoBehaviour
{
    float forceToMass;
 
    public float combinedForce;
    public float calculatedMass;
 
    public int registeredRigidbodies;
 
    public Dictionary<Rigidbody, float> _impulseDownPerRigidBody = new Dictionary<Rigidbody, float>();
    public Dictionary<Rigidbody, float> _impulseUpPerRigidBody = new Dictionary<Rigidbody, float>();

    float currentDeltaTime;
    float lastDeltaTime;
 
    private void Awake()
    {
        forceToMass = 1f / Physics.gravity.magnitude;
    }
 
    void UpdateWeight()
    {

        registeredRigidbodies = _impulseDownPerRigidBody.Count + _impulseUpPerRigidBody.Count;
        combinedForce = 0;
 
        foreach (var force in _impulseDownPerRigidBody.Values)
        {
            combinedForce += force;
        }

        foreach (var force in _impulseUpPerRigidBody.Values)
        {
            combinedForce -= force;
        }
 
        calculatedMass = (float)(combinedForce * forceToMass);
    }
 
    private void FixedUpdate()
    {
        lastDeltaTime = currentDeltaTime;
        currentDeltaTime = Time.deltaTime;
    }
 
    private void OnCollisionStay(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            if (_impulseDownPerRigidBody.ContainsKey(collision.rigidbody) && collision.rigidbody.CompareTag("DownForce"))
                _impulseDownPerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            
            if(_impulseUpPerRigidBody.ContainsKey(collision.rigidbody) && collision.rigidbody.CompareTag("UpForce"))
                _impulseUpPerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            // else
            //     _impulseDownPerRigidBody.Add(collision.rigidbody, collision.impulse.y / lastDeltaTime);
 
            UpdateWeight();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            if (_impulseDownPerRigidBody.ContainsKey(collision.rigidbody) && collision.rigidbody.CompareTag("DownForce"))
                _impulseDownPerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            
            if(_impulseUpPerRigidBody.ContainsKey(collision.rigidbody) && collision.rigidbody.CompareTag("UpForce"))
                _impulseUpPerRigidBody[collision.rigidbody] = collision.impulse.y / lastDeltaTime;
            // else
            //     _impulseDownPerRigidBody.Add(collision.rigidbody, collision.impulse.y / lastDeltaTime);
            //
            UpdateWeight();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            _impulseDownPerRigidBody.Remove(collision.rigidbody);
            _impulseUpPerRigidBody.Remove(collision.rigidbody);
            UpdateWeight();
        }
    }
}