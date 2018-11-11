using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{
    public HealthConfiguration Health;
    private int CurrentHealth;

    void Start()
    {
        CurrentHealth = Health?.InitialHealth ?? 0;
    }
    
    public void ApplyHealth(int amount)
    {
        CurrentHealth += amount;

        if(CurrentHealth > Health.MaxHealth) CurrentHealth = Health.MaxHealth;
        else if(CurrentHealth < 0) CurrentHealth = 0;
    }
}
