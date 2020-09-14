using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public float speedFactor = 0.0125f;
    public float zoomCamera = 1.0f;
    public Camera cameraMove;
    public Transform currentMount;

    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);
        var velocity = Vector3.Magnitude(transform.position - lastPosition);
        cameraMove.fieldOfView = 60 + velocity * zoomCamera;
        lastPosition = transform.position;
    }
    public void setMount(Transform newMount)
    {
        currentMount = newMount;
    }
}
