using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour
{
    [SerializeField] int particleDamage = 1; //MUST BE SERIALIZEDFIELD

    public int GetDamage()
    {
        return particleDamage;
    }
}
