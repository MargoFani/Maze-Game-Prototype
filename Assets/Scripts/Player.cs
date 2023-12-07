using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Movement movement = null;

    public int Coins { get; private set; } = 0;

    public bool IsAlive { get; private set; } = true;
    public bool HasKey { get; private set; } = false;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        Coins = StateNameController.coins;
    }

    public void Enable()
    {
        movement.enabled = true;
    }
    public void Disable()
    {
        movement.enabled = false;
    }
    public void Kill()
    {
        IsAlive = false;
    }

    public void PickUpKey()
    {
        HasKey = true;
    }

    public void AddCoin()
    {
        Coins++;
    }
}
