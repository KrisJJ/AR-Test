using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAndRotate : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50;
    [SerializeField] private float floatAmplitude = 2.0f;
    [SerializeField] private float floatFrequency = 0.5f;

    private Vector3 startPos;

    void Start() {
        startPos = transform.position;

    }

    void Update()
    {
        //animation
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        Vector3 temPos = startPos;
        temPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency)
                * floatAmplitude;
        transform.position = temPos;
    }
}
