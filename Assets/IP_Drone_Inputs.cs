using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent (typeof(PlayerInput))]
public class IP_Drone_Inputs : MonoBehaviour
{
    private Vector2 cyclic;
    private float pedals;
    private float throttle;
    private float deneme;

    public Vector2 Cyclic { get => cyclic; }
    public float Pedals { get => pedals; }
    public float Throttle { get => throttle; }
    public float Deneme { get => deneme; }

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCyclic(InputValue value)
    {
        cyclic = value.Get<Vector2>();
    }

    private void OnThrottle(InputValue value) 
    { 
        throttle = value.Get<float>(); 
    }


    private void OnPedals(InputValue value)
    {
        pedals = value.Get<float>();
    }
    private void OnDeneme(InputValue value)
    {
        deneme = value.Get<float>();
        Debug.Log(deneme);
    }
}
