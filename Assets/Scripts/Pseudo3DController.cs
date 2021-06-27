using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pseudo3DController : MonoBehaviour{
    [Range(-1.0f, 1.0f)]
    public float rotationDirectionMultipler = 0;
    public Vector3 lookPoint;

    // Update is called once per frame
    void Update(){
        CalculateRotationFromLook();
    }

    void CalculateRotationFromLook(){
        rotationDirectionMultipler = lookPoint.normalized.x;
    }
}
