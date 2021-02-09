using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnowballRegenerator : MonoBehaviour
{
    public GameObject SnowballPrefab;
    public Transform spawnPoint;
    public GameObject SpawnedSnowball;

    public void Start()
    {
        SpawnSnowball();
    }

    public void Update()
    {

    }

    public void SpawnSnowball()
    {
        SpawnedSnowball = Object.Instantiate(SnowballPrefab, this.transform);
        SpawnedSnowball.GetComponent<Snowball>().Regenerator = this;
        //SpawnedSnowball.GetComponent<Throwable>().onPickUp.AddListener(SnowBallPickedUp);
    }

    public void SnowBallPickedUp()
    {
        SpawnSnowball();
    }



}
