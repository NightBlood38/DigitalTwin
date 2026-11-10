using UnityEngine;
using System.Collections;

public class AutoSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float spawnInterval = 2.5f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (itemPrefabs.Length > 0)
            {
                int randomIndex = Random.Range(0, itemPrefabs.Length);
                Instantiate(itemPrefabs[randomIndex], transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}