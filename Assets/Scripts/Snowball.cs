using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Snowball : MonoBehaviour
{
    public SnowballRegenerator Regenerator;
    public Rigidbody rb;
    public Throwable Throwable;

    public void Start()
    {
        Debug.Log("Starting...");
        Throwable = gameObject.GetComponent<Throwable>();
        Throwable.onPickUp.AddListener(OnPickUp);
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.isKinematic = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GainScore(1);
        gameObject.SetActive(false);
        other.gameObject.SetActive(false);
    }

    public void OnPickUp()
    {
        Debug.Log("Disabling Kinematics!");
        //rb.isKinematic = false;
        Regenerator.SpawnSnowball();
        Throwable.onPickUp.RemoveListener(OnPickUp);
    }
}

