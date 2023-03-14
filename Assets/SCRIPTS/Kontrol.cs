using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kontrol : MonoBehaviour
{
    public float maxVolumeLevel = 1.0f;
    private string microphoneDevice = null;
    private const int ClipLength = 1;
    private const int SampleRate = 44100;
    private AudioClip clip;

    private GameObject player;
    public float gravityScale = 5;

    private void Start()
    {
        //foreach (var device in Microphone.devices)
        //{
        //    Debug.Log("Name: " + device);
        //}

        microphoneDevice = Microphone.devices[0];
        clip = Microphone.Start(microphoneDevice, true, ClipLength, SampleRate);
        player = GameObject.FindGameObjectWithTag("Player");

        while (Microphone.GetPosition(microphoneDevice) <= 0) { }

    }

    void Update()
    {
        // Calculate the volume level
        float[] samples = new float[SampleRate * ClipLength];
        clip.GetData(samples, 0);
        float volume = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            volume += Mathf.Abs(samples[i]);
        }
        volume /= samples.Length;
        //Debug.Log(volume);

        if (volume > 0.05)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        }

    }

    void OnDestroy()
    {
        Microphone.End(microphoneDevice);
    }
}
