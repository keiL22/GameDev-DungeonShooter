using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //serialized fields
    [SerializeField] private float SmoothTime = 2f;
    [SerializeField] private Transform Target;
    [SerializeField] private float OffsetX;
    [SerializeField] private float OffsetY;
    [SerializeField] private float OffsetZ;

    //unserialized fields
    private Vector3 _Velocity = Vector3.zero;

    //called at the end of each frame
    void LateUpdate()
    {
        //if the target exists
        if(Target != null)
        {
            //follow the target
            transform.position = Vector3.SmoothDamp(
                transform.position, 
                new Vector3(Target.position.x + OffsetX, Target.position.y + OffsetY, Target.position.z + OffsetZ), 
                ref _Velocity, SmoothTime);
        }
    }
}
