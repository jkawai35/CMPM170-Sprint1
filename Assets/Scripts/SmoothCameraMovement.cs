using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movePosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
