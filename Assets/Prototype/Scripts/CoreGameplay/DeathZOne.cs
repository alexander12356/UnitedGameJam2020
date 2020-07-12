using System;
using System.Collections;
using System.Collections.Generic;

using BR;

using UnityEngine;

public class DeathZOne : MonoBehaviour
{
    public LayerMask _targetLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerActor>()?.Die();
        }
    }
}
