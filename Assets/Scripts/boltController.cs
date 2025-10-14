using UnityEngine;

public class boltController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    void Start()
    {
        // Destroy(gameObject, 3);
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dum")
        {
            Destroy(gameObject);
        }
    }
}
