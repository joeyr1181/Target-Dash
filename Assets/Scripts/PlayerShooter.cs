using UnityEngine;

public class PlayerShooter : MonoBehaviour
{

    // Player shooter script to handle shooting mechanics
    // Prefab for the bullet to be instantiated
    // Transform point from where the bullet will be shot
    // Range of the shooting
    // Layer mask to determine what can be hit by the bullet
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootRange = 100f;
    public LayerMask targetMask;


    // Update is called once per frame
    // Check for player input to shoot
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Shoot();
        }
    }

    // Method to handle shooting logic
    // Cast a ray from the player's position in the forward direction
    // Instantiate a bullet at the shoot point
    // If the ray hits an object within the shoot range, log the hit and destroy the object
    // Add score for hitting the target
    void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation)
;
        if (Physics.Raycast(ray, out hit, shootRange, targetMask)) // Check if the ray hits a target
        {
            Debug.Log("Hit: " + hit.collider.name);
            Destroy(hit.collider.gameObject);
            ScoreManager.Instance.AddScore(1);
        }
    }
}
