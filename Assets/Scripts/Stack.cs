using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour {
    public float value;
    public Vector3 worldDimensions;

    private void Awake()
    {
        if(worldDimensions == Vector3.zero)
        {
            BoxCollider bc = GetComponentInChildren<BoxCollider>();
            worldDimensions = new Vector3(bc.bounds.size.x, bc.bounds.size.y, bc.bounds.size.z);
        }
    }
}
