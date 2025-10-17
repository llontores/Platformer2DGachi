using UnityEngine;
using UnityEngine.Events;

public class Strawberry : MonoBehaviour
{
    public event UnityAction<Strawberry> OnCollected;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player _))
        {
            OnCollected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
