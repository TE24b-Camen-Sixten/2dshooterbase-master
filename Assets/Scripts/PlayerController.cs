using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    [SerializeField]
    GameObject boltPrefab;

    [SerializeField]
    GameObject Heal;
    float timeSinceLastShot = 0;
    [SerializeField]
    float timeBetweenShot = 0.5f;

    float HP;
    [SerializeField]
    float maxHP = 3;

    [SerializeField]
    Slider hpSlider;

    void Start()
    {
        HP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = HP;
    }
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movment = Vector2.right * inputX + Vector2.up * inputY;

        transform.Translate(movment * speed * Time.deltaTime);

        //Skjuta

        timeSinceLastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSinceLastShot > timeBetweenShot)
        {
            GetComponent<AudioSource>().Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSinceLastShot = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dum")
        {
            HP--;
            hpSlider.value = HP;
            if (HP <= 0)
            {
                print("Game Over");
                SceneManager.LoadScene("Game Over");
            }
        }
        else if (collision.gameObject.tag == "Healer")
        {
            Destroy(Heal);
            if (HP <= maxHP)
            {
                HP++;
                hpSlider.value = HP;
            }
        }
    }
}