using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _delay;
    [SerializeField] private Player _player;

    private Transform[] _spawners;

    private void Start()
    {
        _spawners = GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new WaitForSeconds(_delay);

        for (int i = 1; i < _spawners.Length + 1; i++)
        {
            if (i == _spawners.Length)
            {
                i = 1;
            }

            GameObject spawned = Instantiate(_prefab, _spawners[i].position, Quaternion.identity);

            if (spawned.TryGetComponent<Strawberry>(out Strawberry strawberry))
            {
                _player.SubscribeMoney(strawberry);
            }
            
            yield return delay;
        }
    }
}