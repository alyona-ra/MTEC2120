using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolFire : MonoBehaviour
{
    private GameObject fire;

    private void OnFireControl()
    {
        fire = GameObject.FindGameObjectWithTag("Fire");
        ParticleSystem particleSystem = fire.GetComponent<ParticleSystem>();

        if (particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
        else
        {
            particleSystem.Play();
        }


    }
}
