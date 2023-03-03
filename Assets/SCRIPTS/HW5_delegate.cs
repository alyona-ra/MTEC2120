using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HW5_delegate : MonoBehaviour
{
    public delegate void OnClickEventDelegate(GameObject g);
    public static event OnClickEventDelegate OnClickEvent;
    public bool clicked;

    private void Start()
    {
        OnClickEvent += Listener;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        if (clicked)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                OnClickEvent?.Invoke(hits[i].collider.gameObject);
            }
        }
    }

    private void Listener(GameObject g)
    {
        Debug.Log(g.name);
    }

    private void OnClick(InputValue value)
    {
        ClickInput(value.isPressed);
    }

    private void ClickInput(bool clickedState)
    {
        clicked = clickedState;
    }
}