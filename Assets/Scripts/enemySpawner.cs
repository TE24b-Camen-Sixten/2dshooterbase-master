using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    float wait;
    float waited;

    [SerializeField]
    GameObject enemyPrefab;

    // Update is called once per frame
    void Update()
    {
        waited += Time.deltaTime;

        if (waited > wait)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            waited = 0;
        }
    }
}
