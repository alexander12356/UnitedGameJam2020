using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public void CloseStore()
    {
        GameCycle.Instance.CloseStore();
    }
}
