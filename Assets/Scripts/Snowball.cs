using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.GainScore(1);
        gameObject.SetActive(false);
    }
}
