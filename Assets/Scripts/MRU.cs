using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRU : MonoBehaviour
{
    public float initialVelocity = 5f;
    private float time = 0f;

    void Update()
    {
        transform.position += Vector3.right * initialVelocity * Time.deltaTime;
        time += Time.deltaTime;
    }
}