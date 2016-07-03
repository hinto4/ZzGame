using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour
{
    [Tooltip ("Minutes per second, default: 60")]
    public float minutesPerSecond;

    void Update()
    {        
        float angleThisFrame = Time.deltaTime / 360 * minutesPerSecond;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
    }
}
