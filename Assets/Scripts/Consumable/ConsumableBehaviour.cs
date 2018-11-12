using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConsumableBehaviour : MonoBehaviour
{
    public UnityEvent OnConsume;

    [ContextMenu("Consume")]
    public void Consume()
    {
        OnConsume?.Invoke();
        Destroy(gameObject, 0.5f);
    }
}
