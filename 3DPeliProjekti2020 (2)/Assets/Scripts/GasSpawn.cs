using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawn : MonoBehaviour
{
    public GameObject gasBottle;
    public int xPos;
    public int zPos;
    public int gasCount;

    void Start()
    {
        StartCoroutine(GasDrop());
    }

    IEnumerator GasDrop()
    {
        while (gasCount < 10)
        {
            xPos = Random.Range(-10, 36);
            zPos = Random.Range(9, -26);
            Instantiate(gasBottle, new Vector3(xPos, 0.26f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            gasCount += 1;
        }
    }
}
