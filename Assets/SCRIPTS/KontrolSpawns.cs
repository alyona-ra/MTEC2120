using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KontrolSpawns : MonoBehaviour
{
    public GameObject prefab;
    private LayerMask ground;
    private List <GameObject> mushrooms = new List<GameObject>();
    GameObject player;

    void Setup()
    {
        
    }

    private void OnLeftClick()
    {
        float x = Random.Range(0, 120);
        float z = Random.Range(0, 90);
        ground = LayerMask.GetMask("ground");
        RaycastHit hit;
        Physics.Raycast(new Vector3(x, 100f, z), Vector3.down, out hit, Mathf.Infinity, ground);
        mushrooms.Add(Instantiate(prefab, new Vector3(x, hit.point.y, z), Quaternion.identity));
        Debug.Log(mushrooms);
    }

    private void OnRightClick()
    {
        if (mushrooms.Count == 0)
        {
            return;
        }

        float shortestDistance = Mathf.Infinity;
        int closestIndex = -1;
        player = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < mushrooms.Count; i++)
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, mushrooms[i].transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                closestIndex = i;
            }
        }

        //int index = Random.Range(0, mushrooms.Count);
        Destroy(mushrooms[closestIndex]);
        mushrooms.RemoveAt(closestIndex);
        Debug.Log(mushrooms);
    }
}
