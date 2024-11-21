using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[RequireComponent(typeof(IP_Drone_Inputs))]

public class IP_Drone_Controller : IP_Base_Rigidbody
{

    #region Variables
    [Header("Control Properties")]
    [SerializeField] private float minMaxPitch = 30f;
    [SerializeField] private float minMaxRoll = 30f;
    [SerializeField] private float yawPower = 4f;

    private float lerpSpeed = 2f;

    private IP_Drone_Inputs inputs;
    private List<IEngine> engines = new List<IEngine>();

    private float finalPitch;
    private float finalRoll;
    private float yaw;
    private float finalYaw;

    #endregion
    void Start()
    {
        inputs = GetComponent<IP_Drone_Inputs>();
        engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
    }


    #region

    protected override void HandlePhysics()
    {
        HandleEngines();
        HandleControls();
    }

    protected virtual void HandleEngines()
    {
        // rb.AddForce(Vector3.up*(rb.mass*Physics.gravity.magnitude));
        foreach (IEngine engine in engines)
        {

            engine.UpdateEngine(rb, inputs);
        }
    }
    protected virtual void HandleControls()
    {
        float pitch = inputs.Cyclic.y * minMaxPitch;
        float roll = -inputs.Cyclic.x * minMaxRoll;
        yaw += inputs.Deneme * yawPower;

        finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
        finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
        finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

        Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);
        rb.MoveRotation(rot);
    }
    #endregion

}
