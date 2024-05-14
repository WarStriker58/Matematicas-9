using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitMovementWithAcceleration : MonoBehaviour
{
    public Transform objective;
    public float acceleration = 1f;

    private float timeArrival;

    private bool hasArrived = false;
    void Update()
    {
        if (!hasArrived)
        {
            Vector3 direction = (objective.position - transform.position).normalized;

            Vector3 vectorAcceleration = direction * acceleration;

            float speed = acceleration * Time.time;

            timeArrival = speed / acceleration;

            transform.position += direction * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, objective.position) < 0.1f)
            {
                hasArrived = true;
                ShowArrivalTime();
            }
        }
    }

    void ShowArrivalTime()
    {
        Debug.Log("El jugador ha llegado al objetivo en " + timeArrival.ToString("F2") + " segundos.");
    }
}