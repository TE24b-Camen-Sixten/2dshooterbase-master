using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    float wait;
    float waited;
    [SerializeField]
    float waitShooter;
    float waitedShooter;

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject shooterPrefab;

    void Update()
    {
        waited += Time.deltaTime;
        waitedShooter += Time.deltaTime;

        if (waited > wait)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            waited = 0;
        }
        if (waitedShooter > waitShooter)
        {
            Instantiate(shooterPrefab, transform.position, Quaternion.identity);
            waitedShooter = 0;
        }
    }
}
