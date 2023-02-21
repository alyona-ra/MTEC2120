using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classwork : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn3DGrid();
        SpawnOnSphere();
    }

    public void SpawnOnSphere()
    {
        int numToSpawn = 100;
        float r = 7f;
        float goldenRatio = Mathf.PI * (3f - Mathf.Sqrt(5f));
        float yOff = 2f / numToSpawn;

        for (int i = 0; i < numToSpawn; i++)
        {
            float phi = i * goldenRatio;
            float y = (i * yOff - 1f + (yOff / 2f));
            float x = Mathf.Cos(phi) * Mathf.Sqrt(1f - y * y);
            float z = Mathf.Sin(phi) * Mathf.Sqrt(1f - y * y);

            GameObject go = Instantiate(prefab, new Vector3(x*r, y*r, z*r), Quaternion.identity);

            Renderer rend = go.GetComponent<Renderer>();
            rend.material.color = first.GetRandomColor();   
        }
    }

    public void Spawn3DGrid()
    {
        float spacing = 10f;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    float x = i * spacing;
                    float y = j * spacing;
                    float z = k * spacing;
                    GameObject go = Instantiate(prefab, new Vector3(x, y, z), Quaternion.identity);

                    Renderer rend = go.GetComponent<Renderer>();
                    rend.material.color = GetRGB(x/10/spacing, y/10/spacing, z/10/spacing);
                }
            }
        }
    }

    public Color GetRGB(float r, float g, float b)
    {
        return new Color(r, g, b);

    }

    public void Rotate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Instantiate(prefab, new Vector3(5, 5, 5), Quaternion.identity);

        //for (int i = 0; i < 12; i++)
        //{
        //    float x = 5 * Mathf.Cos(2 * Mathf.PI * i / 12);
        //    float y = 5 * Mathf.Sin(2 * Mathf.PI * i / 12);
        //    Instantiate(prefab, new Vector3(x, 1, y), Quaternion.identity);
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
