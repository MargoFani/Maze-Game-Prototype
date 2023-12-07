using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport teleportTo;
    [SerializeField] private float teleportDelay;

    private bool canTeleport = true;
    private float timer = 0f;

    private void Update()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;
        else canTeleport = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player)&&canTeleport)
        {
            TeleportTo(player);
        }
    }

    private void TeleportTo(Player player)
    {
        teleportTo.TurnOnTeleportDelay();
        player.transform.position = new Vector3(teleportTo.transform.position.x, teleportTo.transform.position.y, teleportTo.transform.position.z);      

    }

    public void TurnOnTeleportDelay()
    {
        timer = teleportDelay;
        canTeleport = false;
    }
}
