using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3 (0, -4, -10);
    
    private float initialX;

    private void Start()
    {
        initialX = target.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initialX, target.position.y, target.position.z) + offset;
    }
}
