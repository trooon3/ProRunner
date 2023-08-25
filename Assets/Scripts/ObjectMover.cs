using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    void Update()
    {
        transform.Translate(Vector3.right * _speed* Time.deltaTime);
    }
}
