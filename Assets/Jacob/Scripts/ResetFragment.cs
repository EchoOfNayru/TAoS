using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetFragment : MonoBehaviour {

    Vector3 StartPOS;

    void Start()
    {
        StartPOS = transform.localPosition;
    }

    void OnEnable()
    {
        transform.localPosition = StartPOS;
    }
    void OnDisable()
    {
        transform.localPosition = StartPOS;
    }
}
