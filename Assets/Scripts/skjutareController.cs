using UnityEngine;

public class skjutareController : MonoBehaviour
{
    enemySpawner playerTransformGetter;
    Transform playerTransform;
    // [SerializeField]
    // Transform playerTransform;
    
    [SerializeField]
    GameObject BOMBACLAT;

    [SerializeField]
    GameObject Heal;
    
    [SerializeField]
    float wait;
    float waited;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject skott;
    void Start()
    {
        Vector2 newPosition = new();
        newPosition.x = Random.Range(-12, 12);
        newPosition.y = Camera.main.orthographicSize + 1;
        transform.position = newPosition;
    }

    void Update()
    {
        playerTransformGetter = GameObject.Find("Enemy Spawner").GetComponent<enemySpawner>();
        playerTransform = playerTransformGetter.playerTransformSend;
        Vector2 playerPos = playerTransform.position;
        Vector2 shooterPos = transform.position;
        Vector2 pointer = playerPos - shooterPos;
        transform.up = pointer.normalized;
        
        transform.Translate(pointer.normalized * speed * Time.deltaTime, Space.World);
        // transform.position = Vector2.MoveTowards(shooterPos, playerPos, speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

        waited += Time.deltaTime;
        if (waited > wait)
        {
            Instantiate(skott, transform.position, transform.rotation);
            waited = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(BOMBACLAT, transform.position, Quaternion.identity);

        if (collision.gameObject.tag == "Skott")
        {
            int healChance = Random.Range(0, 16);
            if (healChance == 15)
            {
                Instantiate(Heal, transform.position, Quaternion.identity);
            }
        }
    }
}
