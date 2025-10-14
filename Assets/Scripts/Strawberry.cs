using UnityEngine;

public class Strawberry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player _))
        {
            Destroy(gameObject);
        }
    }
}
