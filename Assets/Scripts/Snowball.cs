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


    public ParticleSystem part;


    public void Awake()
    {
        Debug.Log("Starting...");
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.isKinematic = true;
        part = GetComponent<ParticleSystem>();
        part.collision.SetPlane(0,GameManager.Instance.groundPlane.transform);
        part.Pause();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.AddComponent<TriangleExplosion>();
            StartCoroutine(other.gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
            //other.gameObject.SetActive(false);
            GameManager.Instance.GainScore(1);

            startSplatAnimation();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            startSplatAnimation();
        }
    }

    protected virtual void OnAttachedToHand(Hand hand)
    {
        Regenerator.SpawnSnowball();
    }

    private void startSplatAnimation()
    {
        part.Play();
        Destroy(gameObject, part.duration);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}

