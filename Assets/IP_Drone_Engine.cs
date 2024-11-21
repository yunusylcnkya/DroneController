using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class IP_Drone_Engine : MonoBehaviour, IEngine
{
    [Header("Engine Properties")]
    [SerializeField] private float maxPower = 4f;

    [Header("Propeller Properties")]
    [SerializeField] private Transform proppeller;
    [SerializeField] private float propSpeed;

    public void InitEngine()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb, IP_Drone_Inputs input)
    {
        /// Debug.Log("runninhengine"+gameObject.name);
       // Vector3 upVec = transform.up;
        //upVec.x = 0f;
        //upVec.y = 0f;

      //  float diff = 1 - upVec.magnitude;
      //  float finalDiff = Physics.gravity.magnitude * diff;
        
        Vector3 engineForce=Vector3.zero;

        engineForce=transform.up*((rb.mass*Physics.gravity.magnitude)+(input.Throttle*maxPower))/4f;
        rb.AddForce(engineForce,ForceMode.Force);

        HandlePropellers();
    }

    private void HandlePropellers()
    {
        if (!proppeller)
        {
            return;
        }
        proppeller.Rotate(Vector3.up,propSpeed);
    }
}
