using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SnowballRegenerator : MonoBehaviour
{
    public GameObject SnowballPrefab;
    private GameObject SpawnedSnowball;

    public void Start()
    {
        SpawnSnowball();
    }

    public void SpawnSnowball()
    {
        StartCoroutine("Timer", 3);
    }

    public IEnumerator Timer(float waitTime)
    {
        float time = waitTime;
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }

        SpawnedSnowball = Object.Instantiate(SnowballPrefab, this.transform);
        SpawnedSnowball.GetComponent<Snowball>().Regenerator = this;
    }
}
