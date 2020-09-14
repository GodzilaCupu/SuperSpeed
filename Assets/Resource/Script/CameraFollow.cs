using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 Offset;


    private float smoothSpeed = 1f;


    private void Awake()
    {
        Offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 posisiSekarang = target.position + Offset;
        Vector3 posisiSmooth = Vector3.Slerp(transform.position, posisiSekarang, smoothSpeed * Time.deltaTime);
        transform.position = posisiSmooth;
    }
}
