using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAvatarColor : MonoBehaviour
{

    public GameObject player;
    Renderer rend;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("mesh");
        rend = player.GetComponent<Renderer>();
    }

    public void OnTriggerEnter(Collider other)
    {
        Color newColor = first.GetRandomColor();

        foreach(Material material in rend.materials)
        {
            material.color = newColor;
        } 
    }

    public void OnTriggerExit(Collider other)
    {
        Color newColor = first.GetRandomColor();

        foreach (Material material in rend.materials)
        {
            material.color = newColor;
        }
    }
}
