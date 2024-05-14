using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRUV : MonoBehaviour
{
    public float initialVelocity = 5f;
    public float acceleration = 1f;
    private float time = 0f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float posicionX = initialPosition.x + initialVelocity * time + 0.5f * acceleration * time * time;
        transform.position = new Vector3(posicionX, transform.position.y, transform.position.z);
        time += Time.deltaTime;
    }
}