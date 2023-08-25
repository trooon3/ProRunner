using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initilaize(GameObject prephab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject objectToSpawn = Instantiate(prephab, _container.transform);
            objectToSpawn.SetActive(false);
           
            _pool.Add(objectToSpawn);
        }
    }

    protected void Initilaize(GameObject[] prephabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prephabs.Length);
            GameObject objectToSpawn = Instantiate(prephabs[randomIndex], _container.transform);
            objectToSpawn.SetActive(false);

            _pool.Add(objectToSpawn);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
