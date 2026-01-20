using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject mushroomPrefab;
    [SerializeField]
    private GameObject cactusPrefab;

    int enemyType;


    private void Awake()
    {
        enemyType = Random.Range(0, 1); // 0: Mushroom, 1: Cactus

        if (enemyType == 0)
        {
            Instantiate(mushroomPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(cactusPrefab, transform.position, Quaternion.identity);
        }
    }

}
