using System;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Rigidbody rb;
    const float G = 0.0006674f;
    public static List<Gravity> otherObjectsList;
    
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (otherObjectsList == null) 
        {
         otherObjectsList = new List<Gravity>();
        }
        otherObjectsList.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (Gravity obj in otherObjectsList)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody rbOther = other.rb;

        Vector3 disrection = rb.position - rbOther.position;

        float distance = disrection.magnitude;

        if (distance == 0) 
        {
            return;
        }

        float forceMagnitude = G * ((rb.mass * rbOther.mass)/ Mathf.Pow(distance, 2));
        Vector3 force = forceMagnitude * disrection.normalized;
        rbOther.AddForce(force);
    }
}
