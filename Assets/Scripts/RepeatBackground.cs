﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 _startPos;

    private float _repeatWidth;

    void Start()
    {
        _startPos = transform.position;

        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    
    void Update()
    {
        if(transform.position.x < _startPos.x - _repeatWidth)
        {
            transform.position = _startPos;
        }
    }
}//class
