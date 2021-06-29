using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmEffectorController : MonoBehaviour{
    public GameObject controllerObject;
    public GameObject armEffector;

    public GameObject shoulder;
    public GameObject shoulderOpposite;

    public GameObject effector;
    public GameObject effectorOpposite;

    public Pseudo3DController controller;

    float rotationDirectionMultipler;
    float directionY = 0;

    float distanceBetweenShoulders;
    Vector2 shoulderBaseTransform;
    Vector2 shoulderBaseTransformOpposite;

    float distanceBetweenEffectors;
    Vector2 effectorBaseTransform;
    Vector2 effectorBaseTransformOpposite;

    [SerializeField]
    int armSide = 1;

    // Start is called before the first frame update
    void Start(){
        distanceBetweenShoulders = Vector2.Distance(shoulder.transform.position, shoulderOpposite.transform.position);

        shoulderBaseTransform = shoulder.transform.position - controllerObject.transform.position;
        shoulderBaseTransformOpposite = shoulderOpposite.transform.position - controllerObject.transform.position;

        distanceBetweenEffectors = Vector2.Distance(effector.transform.position, effectorOpposite.transform.position);

        effectorBaseTransform = effector.transform.position - controllerObject.transform.position;
        effectorBaseTransformOpposite = effectorOpposite.transform.position - controllerObject.transform.position;
    }

    // Update is called once per frame
    void Update(){
        rotationDirectionMultipler = controller.rotationDirectionMultipler;
        directionY = controller.directionMultiplerY;
        
        // move it to function
        if(Mathf.Sign(directionY) == -1){ 
            shoulder.transform.position = new Vector2(
                controllerObject.transform.position.x + shoulderBaseTransform.x + (rotationDirectionMultipler * distanceBetweenShoulders * armSide * Mathf.Sign(rotationDirectionMultipler))/2, 
                controllerObject.transform.position.y + shoulderBaseTransform.y);
        }
        else{ 
            shoulder.transform.position = new Vector2(
                controllerObject.transform.position.x + shoulderBaseTransformOpposite.x - (rotationDirectionMultipler * distanceBetweenShoulders * armSide * Mathf.Sign(rotationDirectionMultipler))/2, 
                controllerObject.transform.position.y + shoulderBaseTransform.y);
        }

    
        if(Mathf.Sign(directionY) == -1){ 
            effector.transform.position = new Vector2(
                controllerObject.transform.position.x + effectorBaseTransform.x + (rotationDirectionMultipler * distanceBetweenEffectors * armSide * Mathf.Sign(rotationDirectionMultipler))/2, 
                controllerObject.transform.position.y + effectorBaseTransform.y);
        }
        else{ 
            effector.transform.position = new Vector2(
                controllerObject.transform.position.x + effectorBaseTransformOpposite.x - (rotationDirectionMultipler * distanceBetweenEffectors * armSide * Mathf.Sign(rotationDirectionMultipler))/2, 
                controllerObject.transform.position.y + effectorBaseTransform.y);
        }
    }
}
