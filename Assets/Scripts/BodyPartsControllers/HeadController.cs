using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour{
    public GameObject baseController;

    public Pseudo3DController controller;
    float rotationDirectionMultipler = 0;

    Vector3 baseScale;
    Vector3 basePosition;

    float changeScaleMax = 0.12f;
    float changePositionmax = 0.2f;

    // Start is called before the first frame update
    void Start(){
        baseScale = transform.localScale;
        basePosition = transform.position;
    }

    // Update is called once per frame
    void Update(){
        rotationDirectionMultipler = controller.rotationDirectionMultipler;
        PerspectiveEffect();
    }

    void PerspectiveEffect(){
        transform.localScale = new Vector3(baseScale.x - (Mathf.Abs(rotationDirectionMultipler) * changeScaleMax), baseScale.y);
        transform.position = new Vector3(
            baseController.transform.position.x + (rotationDirectionMultipler * changePositionmax), 
            baseController.transform.position.y + basePosition.y);
    }
}
