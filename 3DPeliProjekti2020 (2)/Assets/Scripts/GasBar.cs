using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public Slider GasSlider;

    public void SetMaxGas(float Gas)
    {
        GasSlider.maxValue = Gas;
        GasSlider.value = Gas;
    }

    public void SetGas(float Gas)
    {
        GasSlider.value = Gas;
    }
}
