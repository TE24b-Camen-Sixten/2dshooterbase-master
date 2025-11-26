using UnityEngine;

public class dumSkottController : MonoBehaviour
{
    enemySpawner playerTransformGetter;
    Transform playerTransform;
    Vector2 pointer;
    
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject bomboclat;

    void Start()
    {
        playerTransformGetter = GameObject.Find("Enemy Spawner").GetComponent<enemySpawner>();
        playerTransform = playerTransformGetter.playerTransformSend;
        Vector2 playerPos = playerTransform.position;
        Vector2 shooterPos = transform.position;
        pointer = playerPos - shooterPos;
        transform.up = pointer.normalized;
        
        
    }

    void Update()
    {
        transform.Translate(pointer.normalized * speed * Time.deltaTime, Space.World);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(bomboclat, transform.position, Quaternion.identity);
    }
}
