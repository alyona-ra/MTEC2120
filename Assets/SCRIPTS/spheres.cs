using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spheres : MonoBehaviour
{

    public GameObject sun;


    public Vector3 rotationAxis;

    public float rotationAngle = 1.0f;

    private float countDown = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(sun.transform.position, rotationAxis, rotationAngle);
        //countDownColorChange();
    }

    public void countDownColorChange()
    {
        if (countDown < 0)
        {
            Renderer rend = sun.GetComponent<Renderer>();
            rend.material.color = first.GetRandomColor();
            countDown = 1.0f;
        }
        else
        {
            countDown -= Time.deltaTime;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
        Renderer rend = sun.GetComponent<Renderer>();
        rend.material.color = first.GetRandomColor();
    }

}
