using System;
using System.Collections;
using System.Collections.Generic;

using BR;

using CommandPattern;

using UnityEngine;

public class SpikeActor : MonoBehaviour
{
    private DamageCommand _damageCommand = null;

    public int DamageValue = 0;
    public DamageType DamageType = 0;
    public Vector2 DamageForce = Vector2.zero;
    
    void Awake()
    {
        _damageCommand = new DamageCommand {DamageValue = DamageValue, DamageType = DamageType};
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        var actor = other.GetComponent<IActor>();
        _damageCommand.Execute(actor);

        //if (actor.GetPosition().x > transform.position.x)
        //{
        //    actor.AddForce(DamageForce);
        //}
        //else
        //{
        //    actor.AddForce(new Vector2(-DamageForce.x, DamageForce.y));
        //}
    }
}
