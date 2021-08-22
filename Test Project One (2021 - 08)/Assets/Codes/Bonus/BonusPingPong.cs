using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPingPong : MonoBehaviour
{
    private int _count = 0;
    private int _dist = 25;
    private float _speed = 5f;
    
    void Update()
    {
        _count++;
        var tp = transform.position;
        tp = new Vector3(tp.x, tp.y + _speed, tp.z);

        if (_count >_dist)
        {
            _speed *= -1;
            _count = 0;
        }
    }
}
