using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3 (0, -4, -10);

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
