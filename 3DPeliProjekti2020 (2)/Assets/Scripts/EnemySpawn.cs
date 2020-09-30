using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(55, 84);
            zPos = Random.Range(0, -51);
            Instantiate(theEnemy, new Vector3(xPos, 0.26f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }

    void Update()
    {
        
    }
}
