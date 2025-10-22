using UnityEngine;

public class dumSkottController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject bomboclat;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

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
