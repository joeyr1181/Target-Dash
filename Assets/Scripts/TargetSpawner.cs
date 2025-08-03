using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // TargetSpawner script to handle spawning targets in the game
    // Prefab for the target to be instantiated
    // Interval for how often targets should be spawned
    // Size of the area where targets can be spawned
    public GameObject targetPrefab;
    public float spawnInterval = 2f;
    public Vector3 spawnAreaSize = new Vector3(10f, 1f, 10f);

    private float timer;

    // Update is called once per frame
    // Increment the timer and check if it has reached the spawn interval
    // If it has, spawn a new target
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnTarget();
            timer = 0f;
        }
    }

    // Method to spawn a target at a random position within the defined spawn area
    // Instantiate the target prefab at the random position
    // Reset the timer
    void SpawnTarget()
    {
        Vector3 randomPos = transform.position + new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Instantiate(targetPrefab, randomPos, Quaternion.identity);
    }

    // Method to visualize the spawn area in the editor
    // Draw a wireframe cube to represent the spawn area
    // Set the color to red
    // Use the transform position as the center of the cube
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
