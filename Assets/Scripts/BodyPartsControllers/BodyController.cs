using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour{
    public Pseudo3DController controller;
    float rotationDirectionMultipler = 0;

    Vector3 baseScale;

    float changeScaleMax = 0.12f;

    // Start is called before the first frame update
    void Start(){
        baseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update(){
        rotationDirectionMultipler = controller.rotationDirectionMultipler;
        PerspectiveEffect();
    }

    void PerspectiveEffect(){
        transform.localScale = new Vector3(baseScale.x - (Mathf.Abs(rotationDirectionMultipler) * changeScaleMax), baseScale.y);
    }
}
