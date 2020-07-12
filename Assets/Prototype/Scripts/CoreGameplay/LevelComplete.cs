using System;
using System.Collections;
using System.Collections.Generic;

using BR;

using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
		PlayerActor.Instance.SaveCurrentStats(); 
        GameCycle.Instance.LevelComplete();
    }
}
