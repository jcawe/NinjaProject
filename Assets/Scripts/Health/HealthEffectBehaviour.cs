using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEffectBehaviour : MonoBehaviour
{
    public HealthEffectConfiguration HealthEffect;

    public void ApplyEffect(HealthBehaviour health)
    {
        health.ApplyHealth(HealthEffect.Amount);
    }
}
