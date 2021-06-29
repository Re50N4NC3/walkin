using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour{
    public GameObject baseController;

    public CharacterMovement characterMovement;
    public Pseudo3DController controller;
    
    float rotationDirectionMultipler = 0;

    Vector3 baseScale;
    Vector3 basePosition;

    public float changeScaleMax = 0.12f;
    public float changePositionmax = 0.2f;

    float phase = 0;
    float deltaY = 0;

    [SerializeField]
    float wobbleHeightMulti = 0.001f;

    // Start is called before the first frame update
    void Start(){
        baseScale = transform.localScale;
        basePosition = transform.position;
    }

    // Update is called once per frame
    void Update(){
        rotationDirectionMultipler = controller.rotationDirectionMultipler;
        PerspectiveEffect();
        BodyWobble();
    }

    void PerspectiveEffect(){
        transform.localScale = new Vector3(baseScale.x - (Mathf.Abs(rotationDirectionMultipler) * changeScaleMax), baseScale.y);
    }

    void BodyWobble(){
        float magn = new Vector3(characterMovement.velX, characterMovement.velY).magnitude;

        if (magn > 0.1f){
            // 1.2f allows to wobble for each step, should be adaptive
            phase += magn * 1.2f;
            deltaY = Mathf.Sin(phase * Mathf.Deg2Rad) * wobbleHeightMulti * magn;
        }

        if (phase > 360){
            phase -= 360;
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + deltaY);

    }
}
