using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
   
    public float speed = 0.5f; // Speed of the asteroid

    public GameObject spawnLocation;
    public GameObject targetLocation;

    public int amount = 1;

    private float count = 0f;

    public GameObject[] asteroidPrefab;

    void SpawnAsteroid()
    {
        Vector3 origin = RandomPointInBounds(spawnLocation.GetComponent<Collider2D>().bounds); // Position where the asteroid spawns
        Vector3 target = RandomPointInBounds(targetLocation.GetComponent<Collider>().bounds); // Direction to player
        // Calculate the final direction with randomness

        Vector3 dir = (origin - target).normalized;

        // Create the asteroid and apply the velocity
        GameObject asteroid = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], origin, Quaternion.identity);
        asteroid.GetComponent<Rigidbody>().velocity = dir * speed * -1f;
    }

    void FixedUpdate()
    {
        count += Time.fixedDeltaTime;

        if (count > 1f) {
            count = 0f;
            SpawnAsteroid();
        }
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     this.GetComponent<Collider2D>().enabled = false;
    //     if (other.gameObject.CompareTag("Player"))
    //     {
    //         StartCoroutine(SpawnAsteroids());
    //     }
    // }

    IEnumerator SpawnAsteroids()
    {
        for (int i = amount - 1; i >= 0; i--)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(1);
        }
    }

    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
