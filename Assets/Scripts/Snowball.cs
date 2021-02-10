using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Snowball : MonoBehaviour
{
    public SnowballRegenerator Regenerator;
    public Rigidbody rb;
    public Throwable Throwable;

    public Hand attachedToHand;


    public void Awake()
    {
        Debug.Log("Starting...");
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.isKinematic = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GainScore(1);
        gameObject.SetActive(false);
        other.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }

    protected virtual void OnAttachedToHand(Hand hand)
    {
        Regenerator.SpawnSnowball();
    }

}

