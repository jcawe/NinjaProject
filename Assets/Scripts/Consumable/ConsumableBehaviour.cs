using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ConsumeEvent : UnityEvent<GameObject> { }
public class ConsumableBehaviour : MonoBehaviour
{
    public ConsumeEvent OnConsume;

    public void Consume(GameObject who)
    {
        OnConsume?.Invoke(who);
        Destroy(gameObject);
    }
}