using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
// duration of the rotation in seconds, can be set via Inspector
public float RotationDuration = 0.5f;
private bool _isRotating = false;

void Update () {
    if (Input.GetKeyDown(KeyCode.C) && !_isRotating) { 
        StartCoroutine(RotateObject(
            transform.rotation, 
            transform.rotation * Quaternion.Euler(0, 0, 90), 
            RotationDuration
        ));
    }
    if (Input.GetKeyDown(KeyCode.V) && !_isRotating) {
        StartCoroutine(RotateObject(
            transform.rotation, 
            transform.rotation * Quaternion.Euler(0, 0, -90), 
            RotationDuration
        ));
    }
}

IEnumerator RotateObject(Quaternion start, Quaternion end, float duration)
{
    float endTime = Time.time + duration;
    _isRotating = true;
    while (Time.time <= endTime) {
        // normalized progress from 0 - 1
        float t = 1f - (endTime - Time.time) / duration;
        transform.rotation = Quaternion.Lerp(start, end, t);
        yield return 0;
    }
    transform.rotation = end;
    _isRotating = false;
}
}
