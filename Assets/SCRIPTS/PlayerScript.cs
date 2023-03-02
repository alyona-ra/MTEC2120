using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[AddComponentMenu("Input/Player Input")]
//[DisallowMultipleComponent]

public class PlayerScript : MonoBehaviour
{
    //public GameObject projectilePrefab;

    //private Vector2 m_Look;
    //private Vector2 m_Move;
    //private bool m_Fire;

    // 'Fire' input action has been triggered. For 'Fire' we want continuous
    // action (i.e. firing) while the fire button is held such that the action
    // gets triggered repeatedly while the button is down. We can easily set this
    // up by having a "Press" interaction on the button and setting it to repeat
    // at fixed intervals.
    //public void OnFire()
    //{
    //    Instantiate(projectilePrefab);
    //}

    // 'Move' input action has been triggered.
    public void OnJump(InputValue value)
    {
        Debug.Log("Jumped");
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce(0, 100f, 0);
    }

    // 'Look' input action has been triggered.
    //public void OnLook(InputValue value)
    //{
    //    m_Look = value.Get<Vector2>();
    //}

    public void OnUpdate()
    {
        // Update transform from m_Move and m_Look
    }
}
