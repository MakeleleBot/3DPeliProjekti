using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{

    public GameObject FTHZ1; //HitZone
    public GameObject FTHZ2;

    //public int damage = 25;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("FTON", true);
            //FTHZ1.gameObject.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("FTON",false);
            //FTHZ1.gameObject.SetActive(false);
        }

      
    }

    //public void OnTriggerEnter(Collider hitInfo)
    //{
    //    Enemy enemy = hitInfo.GetComponent<Enemy>();

    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //    }
        
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    Enemy enemy = other.GetComponent<Enemy>();

    //    if(other.gameObject.CompareTag("Enemy"))
    //    {
    //        Debug.Log("Osuma");
    //        enemy.TakeDamage(damage);
    //    }
    //}
}
