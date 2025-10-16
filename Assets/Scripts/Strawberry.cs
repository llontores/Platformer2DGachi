using UnityEngine;
using UnityEngine.Events;

public class Strawberry : MonoBehaviour
{
    public static event UnityAction OnCollected;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player _))
        {
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
