using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)        
    {
        Debug.Log("on trigger enter");
        if (other.TryGetComponent(out Player player))
        {
            player.Kill();
        }
    }
}

