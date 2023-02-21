using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    Vector3 origin = new Vector3(0, 0, 0);
    Vector3 rotationAxis = new Vector3(0, 1, 0);
    float rotationAngle = 1;
    public float speed = 10;

    public void Start()
    {
        Center.OnEnableGravity += Rotate;
        Center.OnEnableGravity += RotateAboutAxis;
    }

    public void RotateAboutAxis()
    {
        transform.RotateAround(this.transform.position, rotationAxis, rotationAngle * speed);
    }

    public void Rotate()
    {
        transform.RotateAround(origin, rotationAxis, rotationAngle * speed);
    }
}
