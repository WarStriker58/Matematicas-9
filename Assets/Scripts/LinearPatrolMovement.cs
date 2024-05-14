using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearPatrolMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float[] arrivalTimes;

    private int currentPoint = 0;
    private float startTime;
    private float speedPrevious;
    private Vector3 previousPosition;

    void Start()
    {
        startTime = Time.time;
        previousPosition = transform.position;
        CalculatePreviousSpeed();
    }

    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        if (currentPoint < patrolPoints.Length && currentPoint < arrivalTimes.Length)
        {
            float distance = Vector3.Distance(transform.position, patrolPoints[currentPoint].position);
            float timeElapsed = Time.time - startTime;

            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, speedPrevious * Time.deltaTime);

            if (distance < 0.1f)
            {
                float timeToGo = Time.time - startTime;
                float distanceTraveled = Vector3.Distance(previousPosition, transform.position);
                float speed = distanceTraveled / timeToGo;

                Debug.Log("Punto: " + currentPoint);
                Debug.Log("Tiempo de llegada: " + timeToGo.ToString("F2") + " segundos");
                Debug.Log("Distancia recorrida: " + distanceTraveled.ToString("F2") + " metros");
                Debug.Log("Velocidad utilizada: " + speed.ToString("F2") + " metros por segundo");

                currentPoint = (currentPoint + 1) % patrolPoints.Length;
                startTime = Time.time;
                previousPosition = transform.position;
                CalculatePreviousSpeed();
            }
        }
        else
        {
            Debug.LogError("Error: El indice puntoActual está fuera de los limites de los arreglos PatrolPoints o arrivalTimes.");
        }
    }

    void CalculatePreviousSpeed()
    {
        int siguientePunto = (currentPoint + 1) % patrolPoints.Length;
        if (currentPoint < arrivalTimes.Length && siguientePunto < patrolPoints.Length)
        {
            speedPrevious = arrivalTimes[currentPoint] > 0 ? Vector3.Distance(patrolPoints[currentPoint].position, patrolPoints[siguientePunto].position) / arrivalTimes[currentPoint] : 0;
        }
        else
        {
            Debug.LogError("Error: CurrentPoint esta fuera de los limites del arreglo ArrivalTimes.");
        }
    }
}