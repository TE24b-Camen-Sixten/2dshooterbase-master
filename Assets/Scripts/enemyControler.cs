using UnityEngine;

public class enemyControler : MonoBehaviour
{
    [SerializeField]
    GameObject BOMBACLAT;

    [SerializeField]
    GameObject Heal;

    [SerializeField]
    float speed = 1f;

    void Start()
    {

        Vector2 newPosition = new();
        newPosition.x = Random.Range(-12, 12);
        newPosition.y = Camera.main.orthographicSize + 1;
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // if (transform.position.y < Camera.main.orthographicSize + 1)
        // {
        //     Destroy(gameObject);
        // }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        Instantiate(BOMBACLAT, transform.position, Quaternion.identity);

        if (collision.gameObject.tag == "Skott")
        {
            int healChance = Random.Range(0, 21);
            if (healChance == 20)
            {
                Instantiate(Heal, transform.position, Quaternion.identity);
            }
        }
    }
}
