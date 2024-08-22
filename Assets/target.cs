using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Stats")]
    public int hits;

    public void TakeHit(int singleHit)
    {
        hits += singleHit;
    }
}