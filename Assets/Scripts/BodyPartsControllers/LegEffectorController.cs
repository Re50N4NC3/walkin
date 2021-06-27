using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegEffectorController : MonoBehaviour{
    public GameObject effectorBasePosition;

    public Pseudo3DController controller;
    public CharacterMovement characterMovement;

    public float rotationDirectionMultipler = 0;

    public float deltaX;
    public float deltaY;

    [SerializeField]
    float phaseMove = 0;
    [SerializeField]
    float phase = 0;
    
    float animationSpeed = 1.4f;
    float characterMoveMagnitude;

    Vector2 startPosition;
    bool moving = false;

    private void Start() {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update(){
        if (moving == false){
            transform.position = startPosition;
        }
    }

    void ChangePhase(){
        phase += (characterMoveMagnitude / animationSpeed) * Mathf.Sign(characterMovement.velX) * Mathf.Sign(rotationDirectionMultipler);

        if (phase > 360){
            phase -= 360;
        }
        if (phase < 0){
            phase += 360;
        }
    }

    void ChangePosition(){
        deltaY = Mathf.Clamp(deltaY, 0, 99);
        Vector3 pos = new Vector3(effectorBasePosition.transform.position.x + deltaX * rotationDirectionMultipler, effectorBasePosition.transform.position.y + deltaY);
        transform.position = pos;
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegEffectorController : MonoBehaviour{
    public GameObject effectorBasePosition;

    public Pseudo3DController controller;
    public CharacterMovement characterMovement;

    public float rotationDirectionMultipler = 0;

    public float deltaX;
    public float deltaY;

    [SerializeField]
    float phaseMove = 0;
    [SerializeField]
    float phase = 0;
    
    float animationSpeed = 1.4f;
    float characterMoveMagnitude;

    // Update is called once per frame
    void Update(){
        characterMoveMagnitude =  new Vector3(characterMovement.velX, characterMovement.velY).magnitude;
        rotationDirectionMultipler = controller.rotationDirectionMultipler;

        if (characterMoveMagnitude > 0.2f){
            deltaX = (0.2f + Mathf.Abs(rotationDirectionMultipler)) * Mathf.Sin((phase + phaseMove) * Mathf.Deg2Rad);
            deltaY = Mathf.Cos((phase + phaseMove)* Mathf.Deg2Rad );
        }
        else{
            deltaX = Mathf.Lerp(deltaX, 0, Time.deltaTime / 0.2f);
            deltaY = Mathf.Lerp(deltaY, 0, Time.deltaTime / 0.2f);
            phase = 0;
        }

        ChangePhase();
        ChangePosition();
    }

    void ChangePhase(){
        phase += (characterMoveMagnitude / animationSpeed) * Mathf.Sign(characterMovement.velX) * Mathf.Sign(rotationDirectionMultipler);

        if (phase > 360){
            phase -= 360;
        }
        if (phase < 0){
            phase += 360;
        }
    }

    void ChangePosition(){
        deltaY = Mathf.Clamp(deltaY, 0, 99);
        Vector3 pos = new Vector3(effectorBasePosition.transform.position.x + deltaX * rotationDirectionMultipler, effectorBasePosition.transform.position.y + deltaY);
        transform.position = pos;
    }
}

*/