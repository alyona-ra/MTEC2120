using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    private GameObject prefab;
    private GameObject player;

    private List<GameObject> trees = new List<GameObject>();
    public int maxTrees = 25;

    private LayerMask ground;

    public TextMeshProUGUI counterText;

    float shortestDistance = Mathf.Infinity;
    int closestIndex = -1;
    float distanceToPlayer;

    public static int count = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        ChangeCounter(0);
        treeGenerator();
    }

    private void spawnTree()
    {
        int x = Random.Range(0, 120);
        int z = Random.Range(0, 90);
        ground = LayerMask.GetMask("Ground");
        RaycastHit hit;
        Physics.Raycast(new Vector3(x, 100f, z), Vector3.down, out hit, Mathf.Infinity, ground);
        int rand = Random.Range(0, 10);
        if (rand < 5)
        {
            prefab = prefab1;
        }
        else
        {
            prefab = prefab2;
        }

        trees.Add(Instantiate(prefab, new Vector3(x, hit.point.y, z), Quaternion.identity));
    }

    public void ChangeCounter(int counter)
    {
        counterText.text = counter.ToString();
    }

    private void treeGenerator()
    {
        for (int i = 0; i < maxTrees; i++)
        {
            spawnTree();
        }
    }

    private void OnLeftClick()
    {
        if (trees.Count == 0)
        {
            return;
        }

        for (int i = 0; i < trees.Count; i++)
        {
            distanceToPlayer = Vector3.Distance(player.transform.position, trees[i].transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                closestIndex = i;
            }
        }

        if (shortestDistance > 2)
        {
            return;
        }

        if (trees[closestIndex].name == "TreePink3(Clone)")
        {
            count = count + 10;
        }
        else
        {
            count = count + 5;
        }

        Debug.Log(count);
        ChangeCounter(count);

        Destroy(trees[closestIndex]);
        trees.RemoveAt(closestIndex);

        if (trees.Count < maxTrees)
        {
            spawnTree();
        }

        shortestDistance = Mathf.Infinity;
        closestIndex = -1;
    }
}
