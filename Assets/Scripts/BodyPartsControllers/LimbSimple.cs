using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbSimple : MonoBehaviour{
    public Transform pointStart;
    public Transform pointEnd;

    // Update is called once per frame
    void Update(){
        Vector2 pointDifference = pointEnd.position - transform.position;
        float angle =  Mathf.Atan2(pointDifference.y, pointDifference.x) * Mathf.Rad2Deg + 90;
        
        Vector3 centerPos = new Vector3( pointStart.position.x + pointEnd.position.x, pointStart.position.y + pointEnd.position.y ) / 2f;
        transform.position = centerPos;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
