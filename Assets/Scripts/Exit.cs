using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
public class Exit : MonoBehaviour
{
    [SerializeField] private Material closedMaterial;
    [SerializeField] private Material openMaterial;
    [SerializeField] private bool startExitState;
    public bool IsOpen { get; private set; }

    private MeshRenderer render;

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
        if (startExitState)
            Open();
        else Close();
    }
    public void Open()
    {
        IsOpen = true;
        render.sharedMaterial = openMaterial;
    }

    public void Close()
    {
        IsOpen = false;
        render.sharedMaterial = closedMaterial;
    }
}
