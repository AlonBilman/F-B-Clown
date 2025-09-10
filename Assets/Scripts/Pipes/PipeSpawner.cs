using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePairPrefab;
    [SerializeField] private float spawnInterval = 1.2f;
    [SerializeField] private int poolSize = 3;
    [SerializeField] private float minY = -1.0f;
    [SerializeField] private float maxY = 1.0f;
    private List<GameObject> pipes = new List<GameObject>();
    private float timer;
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pipePairPrefab);
            obj.SetActive(false);
            pipes.Add(obj);
        }
    }

    private void Update()
    {
        // spawn pipes if game is active
        if (!GameManager.Instance.IsGameActive()) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnPipe();
        }
    }
    private void SpawnPipe()
    {
        // find a pipe 
        GameObject pipe = GetFreePipe();

        if (pipe == null) return; 
        float y = Random.Range(minY, maxY);
        pipe.transform.position = new Vector3(transform.position.x, y, 0f);

        pipe.SetActive(true);
    }
    private GameObject GetFreePipe()
    {
        return pipes.Find(p => !p.activeInHierarchy);
    }
}