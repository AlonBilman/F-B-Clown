using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePairPrefab;
    public float spawnInterval = 1.2f;

    // internal vertical band for randomization
    const float MinY = -1.0f;
    const float MaxY =  1.0f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            float y = Random.Range(MinY, MaxY); // random y position
            Vector3 pos = new Vector3(transform.position.x, y, 0f);
            Instantiate(pipePairPrefab, pos, Quaternion.identity);
        }
    }
}
