using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KontrolFire : MonoBehaviour
{
    private GameObject fire;
    private GameObject player;

    public float time;
    private float emRate = 0;

    private void Start()
    {
        fire = GameObject.FindGameObjectWithTag("Fire");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            time = 0;
            if (emRate > 0)
            {
                emRate--;
            }
        }

        ParticleSystem.EmissionModule psE = fire.GetComponent<ParticleSystem>().emission;
        psE.rateOverTime = emRate;
    }

    private void OnFireControl()
    {
        
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

    private void OnFireRestock()
    {       
        
        float distanceToPlayer = Vector3.Distance(player.transform.position, fire.transform.position);

        if (distanceToPlayer < 2)
        {
            Interaction script = FindObjectOfType<Interaction>();


            if (Interaction.count >= 5)
            {
                emRate += 2f;

                Interaction.count = Interaction.count - 5;
                Debug.Log(Interaction.count);

                script.ChangeCounter(Interaction.count);

            }
            else
            {
                Debug.Log("You need more wood.");
            }
            
        }
    }
}
