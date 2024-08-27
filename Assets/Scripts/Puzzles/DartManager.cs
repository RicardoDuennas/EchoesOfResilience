using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartManager : MonoBehaviour
{
    public Transform[] darts;
    private Vector3[] dartPositions;

    void Awake()
    {
        darts = new Transform[6];
        dartPositions = new Vector3[6];

        for (int i = 0; i < darts.Length; i++)
        {
            darts[i] = transform.Find($"Dart{i}");
            if (darts[i] != null)
            {
                dartPositions[i] = darts[i].position;
            }
            else
            {
                Debug.LogWarning($"Dart{i} not found");
            }
        }
    }

    public Vector3 GetDartPosition(int index)
    {
        if (index >= 0 && index < dartPositions.Length)
        {
            return dartPositions[index];
        }
        return Vector3.zero;
    }
}