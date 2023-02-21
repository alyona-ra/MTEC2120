using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour
{
    public delegate void EnableGravity();
    public static event EnableGravity OnEnableGravity;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnEnableGravity?.Invoke();
        }
    }
}

