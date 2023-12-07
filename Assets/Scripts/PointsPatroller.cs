using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointsPatroller : MonoBehaviour
{
    [SerializeField] private Transform[] patrollingPoints;
    [SerializeField] private float patrolDelay;
    [SerializeField] private float step;


    private float timer = 0f;
    private int currentPatrolPointIndex = 0;

    private void Awake()
    {
        timer = patrolDelay;
    }

    private void Update()
    {
        PatrolTimerTick();
        MoveToPoint(currentPatrolPointIndex);
    }

    private void MoveToPoint(int pointIndex)
    {
        transform.position = new Vector3(patrollingPoints[pointIndex].position.x, transform.position.y, patrollingPoints[pointIndex].position.z);
    }

    private void PatrolTimerTick()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int nextPoint = currentPatrolPointIndex + 1;

            if (nextPoint >= patrollingPoints.Length)
                nextPoint = 0;

            currentPatrolPointIndex = nextPoint;
            timer = patrolDelay;
        }
    }
}
