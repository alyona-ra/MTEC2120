using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HW5_delegate : MonoBehaviour
{
    // Event Handler
    public delegate void OnClickEventDelegate();
    public event OnClickEventDelegate OnClickEvent;

    private void Update()
    {
        OnClickEvent = OnClick;
    }

    private void OnClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].collider.gameObject.name);
        }
    }
}
