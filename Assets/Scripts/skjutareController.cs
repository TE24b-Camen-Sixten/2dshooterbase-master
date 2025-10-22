using UnityEngine;

public class skjutareController : MonoBehaviour
{
    public Transform player;
    
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
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }

        waited += Time.deltaTime;
        if (waited > wait)
        {
            Instantiate(skott, transform.position, Quaternion.identity);
            waited = 0;
        }

        Vector3 pos = player.position;
        transform.LookAt(pos);
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
