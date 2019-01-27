using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
     //25.1 29.9 -8.3
    Vector3 v = new Vector3(25.1f,29.9f,-8.3f);
    CinemachineTransposer transposer;

    Vector3 delta = Vector3.zero;
    Vector3 lastJoystickInput=Vector3.zero;
    [SerializeField] float rotationAngle;
    void Start()
    {
        vcam = this.GetComponent<CinemachineVirtualCamera>();
        transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
    }

    void Update()
    {
        Vector3 dir = MainCube.instance.getDirection();
       // Debug.Log(dir);

        if (dir.magnitude>0.2f) {
            Debug.Log("try rotate");
            Vector3 rotate = new Vector3(0, rotationAngle * delta.x, 0);
            transposer.m_FollowOffset = rotatePoint(transposer.m_FollowOffset, Vector3.zero, rotate);
        }
        lastJoystickInput = dir;
    }

    Vector3 rotatePoint(Vector3 position, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = position - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        position = dir + pivot; // calculate rotated point
        return position;
    }
}
