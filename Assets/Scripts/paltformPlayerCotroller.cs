using UnityEngine;

public class paltformPlayerCotroller : MonoBehaviour
{
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject groundCheck;
    [SerializeField]
    LayerMask groundLayer;
    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle
        (
            groundCheck.transform.position,
            .3f,
            groundLayer
        );

        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Vector2 movment = Vector2.right * inputX;
        transform.Translate(movment * speed * Time.deltaTime);
    }
}
