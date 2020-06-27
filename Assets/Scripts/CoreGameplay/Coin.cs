using System;
using System.Collections;
using System.Collections.Generic;

using BR;

using MetaGameplay;

using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        PlayerActor.Instance.Data.Coins += Count;
        Destroy(gameObject);
    }
}
