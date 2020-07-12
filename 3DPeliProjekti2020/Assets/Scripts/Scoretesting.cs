using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoretesting : MonoBehaviour
{
    public static int pointCount;
    Text points;

    void Start()
    {
        points = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + pointCount;
    }
}
