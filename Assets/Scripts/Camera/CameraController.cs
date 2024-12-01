using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static Rigidbody2D playerBody;
    public float cam_speedOffsetSensitivity;
    public float cam_OffsetSmoothness;
    public float cam_maxOffset;

    Vector3 smoothCameraOffset = new Vector3(0,0,-10);
    void Update()
    {
        if(playerBody) FollowTarget();

    }
    void FollowTarget()
    {
                Vector3 cameraOffset = playerBody.velocity * cam_speedOffsetSensitivity;

        cameraOffset.x= Mathf.Clamp(cameraOffset.x,-cam_maxOffset,cam_maxOffset);
        cameraOffset.x= Mathf.Clamp(cameraOffset.x,-cam_maxOffset,cam_maxOffset);

        smoothCameraOffset = Vector3.Lerp(smoothCameraOffset,cameraOffset,cam_OffsetSmoothness);

        transform.position = playerBody.transform.position + smoothCameraOffset;

        transform.position += new Vector3(0,-0,-10);
    }
}
