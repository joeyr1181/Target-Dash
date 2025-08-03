using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Bullet script to handle bullet behavior in the game
    // Speed of the bullet
    // Lifetime of the bullet before it gets destroyed
    public float speed = 50f;
    public float lifetime = 2f;


    // Start is called before the first frame update
    // Initialize the bullet's lifetime and movement
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    // Move the bullet forward based on its speed
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
