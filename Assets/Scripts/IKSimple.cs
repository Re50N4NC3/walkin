using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class IKSimple : MonoBehaviour{
    public Pseudo3DController controller;
    float rotationDirectionMultipler = 0;
    
    public Transform basePoint;
    public Transform midPoint;
    public Transform endPoint;
    
    public Transform effector;

    public float baseLen;
    public float endLen;
    float targetLen;

    float baseLenStart;
    float endLenStart;
    float targetLenStart;

    float limbLenScale = 0.25f;
    float angleScale = 0.8f;
    float baseToTargetRatio;

    void Start(){
        baseLen = Vector3.Distance(basePoint.position, midPoint.position);
        endLen = Vector3.Distance(midPoint.position, endPoint.position);
        targetLen = Vector3.Distance(basePoint.position, endPoint.position);

        baseLenStart = baseLen;
        endLenStart = endLen;
        targetLenStart = targetLen;

        baseToTargetRatio = baseLen / targetLenStart;
    }

    void Update(){
        targetLen = Vector3.Distance(basePoint.position, effector.position);
        ChangePerspective();

        // get angles
        float baseToTargetAngle = PointAngle(basePoint.position, effector.position);
        float midToTargetAngle = PointAngle(midPoint.position, effector.position);

        // set base angles if effector is not reachable
        float angleBaseToMid = baseToTargetAngle;
        float angleMidToEnd = baseToTargetAngle;

        // if point is reachable calculate new angles
        if (baseLen + endLen > targetLen){
            float cosAngle0 = (((targetLen * targetLen) + (baseLen * baseLen) - (endLen * endLen)) / (2 * targetLen * baseLen));
            float angle0 = Mathf.Acos(cosAngle0) * Mathf.Rad2Deg * Mathf.Sign(-rotationDirectionMultipler);// * (-rotationDirectionMultipler * angleScale);
            
            angleBaseToMid = baseToTargetAngle - angle0;
            angleMidToEnd =  midToTargetAngle;
        }
        
        midPoint.position = PointTowards(angleBaseToMid, basePoint.position, baseLen);
        endPoint.position = PointTowards(angleMidToEnd, midPoint.position, endLen);
    }

    void ChangePerspective(){
        rotationDirectionMultipler = controller.rotationDirectionMultipler;

        float baseIni = (targetLen * baseToTargetRatio);
        float endIni = (targetLen * (1 - baseToTargetRatio));

        // divide by 10 to prevent limb splitting
        baseLen = baseIni + (baseLenStart) * baseToTargetRatio * Mathf.Abs(rotationDirectionMultipler) / 10;
        endLen = endIni + (baseLenStart) * (1 - baseToTargetRatio) * Mathf.Abs(rotationDirectionMultipler) / 10;
    }

    #region Math functions
    Vector3 PointTowards(float angle, Vector3 posFrom, float dist){
        float addX = dist * Mathf.Cos(angle * Mathf.Deg2Rad);
        float addY = dist * Mathf.Sin(angle * Mathf.Deg2Rad);
        Vector3 newPosition = posFrom;
        newPosition.x += addX;
        newPosition.y += addY;
        
        return newPosition;
    }

    float PointAngle(Vector3 pointFrom, Vector3 pointTo){
        Vector2 pointDifference = pointTo - pointFrom;

        return Mathf.Atan2(pointDifference.y, pointDifference.x) * Mathf.Rad2Deg;
    }
    #endregion
}
