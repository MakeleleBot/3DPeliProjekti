using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    public float maxGas = 100f;
    public float currentGas;

    public GasBar GB;

    public float GasBurnRate = 20f;

    bool isShooting = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentGas = maxGas;
        GB.SetMaxGas(maxGas);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&currentGas>0)
        {
           
            isShooting = true;

            GetComponent<Animator>().SetBool("FTON", true);
            
        }
        if (Input.GetMouseButtonUp(0)|| currentGas < 0)
        {
            isShooting = false;
            GetComponent<Animator>().SetBool("FTON",false);
           
        }


        if (isShooting)
        {
            GB.SetGas(currentGas);
            currentGas -= GasBurnRate * Time.deltaTime;
        }

      
    }

    public void GasPickUp(float Gas)
    {
        currentGas += Gas;
        if (currentGas > 100f)
        {
            currentGas = 100f;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GAS"))
        {
            Debug.Log("GAAS");
            GasPickUp(20);
            GB.SetGas(currentGas);
            Destroy(other.gameObject);
        }
    }


}
