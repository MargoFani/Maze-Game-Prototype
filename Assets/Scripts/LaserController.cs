using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private float laserDelay;

    private bool IsShoot { get; set; } = false;
    private float timer = 0f;

    private void Awake()
    {
        timer = laserDelay;
        LaserShotStop();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = laserDelay;
            IsShoot = !IsShoot;
            if (IsShoot)
                LaserShotStart();
            else LaserShotStop();
        }

    }

    private void LaserShotStart()
    {

        laser.SetActive(true);

    }

    private void LaserShotStop()
    {
        laser.SetActive(false);
    }
}
