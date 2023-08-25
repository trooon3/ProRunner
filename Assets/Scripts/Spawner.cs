using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private Transform[] _points;
    [SerializeField] private GameObject[] _objectsToSpawn;

    private WaitForSeconds _waitOneSecond = new WaitForSeconds(1);
    
    private void Start()
    {
        Initilaize(_objectsToSpawn);

        _points = new Transform[_spawner.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _spawner.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            if (TryGetObject(out GameObject objectToSpawn))
            {
                SetObject(objectToSpawn);

                yield return _waitOneSecond;
            }
        }
    }
    
    private void SetObject(GameObject objectToSpawn)
    {
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position =_points[Random.Range(0, _spawner.childCount)].position;
    }
}
