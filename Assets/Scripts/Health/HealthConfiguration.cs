using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Health", menuName="NinjaProject/Health")]
public class HealthConfiguration : ScriptableObject
{
    public int MaxHealth;
    public int InitialHealth;
}
