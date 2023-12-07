using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsObserver : MonoBehaviour
{
    [SerializeField] private Transform[] observablePoints;
    [SerializeField] private float lookDelay;

    [SerializeField] private GameObject fieldOfView;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private LayerMask playerMask;

    private float timer = 0f;
    private int currentObservablePointIndex = 0;

    private void Awake()
    {
        timer = lookDelay;
    }

    private void Update()
    {
        LookAtTimerTick();
        LookAtPoint();
    }

    private void LookAtPoint()
    {
        Vector3 distanceToPoint = observablePoints[currentObservablePointIndex].transform.position - transform.position;
        Vector3 directionToPoint = distanceToPoint.normalized;

        fieldOfView.SetActive(Physics.Raycast(transform.position, directionToPoint, distanceToPoint.magnitude, obstacleMask) == false);
        Vector3 forward = new Vector3(directionToPoint.x, 0f, directionToPoint.z);
        if (forward != Vector3.zero)
            transform.forward = forward;

        if (Physics.Raycast(transform.position, directionToPoint, out RaycastHit hit, distanceToPoint.magnitude, playerMask))
            hit.collider.GetComponent<Player>().Kill();

    }

    private void LookAtTimerTick()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            int nextPoint = currentObservablePointIndex + 1;

            if (nextPoint >= observablePoints.Length)
                nextPoint = 0;

            currentObservablePointIndex = nextPoint;
            timer = lookDelay;
        }
    }
}
