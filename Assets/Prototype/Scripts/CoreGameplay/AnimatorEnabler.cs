using System;
using System.Collections;
using System.Collections.Generic;

using BR;

using UnityEngine;

public class AnimatorEnabler : MonoBehaviour
{
    public float EnableDistance = 0f;
    public Animator _Animator = null;
    
    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PlayerActor.Instance.transform.position, transform.position) <= EnableDistance)
        {
            _Animator.enabled = true;
        }
        else
        {
            _Animator.enabled = false;
        }
    }
}
