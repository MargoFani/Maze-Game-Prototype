using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private float step;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryMove(Vector3.forward);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryMove(Vector3.back);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryMove(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryMove(Vector3.right);
        }
    }

    private void TryMove(Vector3 direction)
    {
        var ray = new Ray(transform.position, direction);
        if (Physics.Raycast(ray, step, obstacleMask))
            return;

        transform.forward = direction;
        transform.Translate(direction * step, Space.World);
            
    }

}
