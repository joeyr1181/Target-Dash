using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public float shootRange = 100f;
    public LayerMask targetMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation)
;
        if (Physics.Raycast(ray, out hit, shootRange, targetMask))
        {
            Debug.Log("Hit: " + hit.collider.name);
            Destroy(hit.collider.gameObject);
            ScoreManager.Instance.AddScore(1);
        }
    }
}
