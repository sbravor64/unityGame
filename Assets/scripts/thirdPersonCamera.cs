using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonCamera : MonoBehaviour
{

    public Vector3 offset;
    private Transform target;
    [Range(0,1)] public float lerpValue;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpValue);
    }
} 
