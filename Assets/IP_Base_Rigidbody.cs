using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class IP_Base_Rigidbody : MonoBehaviour
{
    #region Variables
    [Header("Rigidbody Properties")]
    [SerializeField] private float weightInlbs = 1f;
    
    const float lbsToKg = 0.454f;
    protected Rigidbody rb;

    protected float startDrag;
    protected float startAngularDrag;

    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.mass = weightInlbs * lbsToKg;
            startDrag=rb.drag;
            startAngularDrag=rb.angularDrag;
        }
    }
    void Start()
    {

    }

    void FixedUpdate()
    {
        if (!rb)
        {
            return;
        }

        HandlePhysics();
    }

    #region Custom Methods

    protected virtual void HandlePhysics()
    {
        throw new NotImplementedException();
    }
    #endregion
}
