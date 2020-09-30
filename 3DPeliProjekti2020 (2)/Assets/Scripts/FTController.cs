using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FTController : MonoBehaviour
{
    public GameObject ft;

    void Start()
    {
        ft.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ft.SetActive(true);
        }

        else
        {
            ft.SetActive(false);
        }
    }
}
