using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    protected Joystick joystick;

    [SerializeField]
    private Rigidbody rbSpeedBoat;
    [SerializeField]
    private float fowardForce, sideWayForce;

    private bool xRotate;
    
    // Start is called before the first frame update
    public void Awake()
    {
        joystick = FindObjectOfType<Joystick>();
        sideWayForce = 2.5f;
        Maju();
    }

    public void Setop()
    {
        fowardForce = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        //camera.transform.position = Vector3.MoveTowards(camera.transform.position, camera.transform.position + Vector3.forward, Time.deltaTime * fowardForce);


        //paksa Maju untuk kanan kiri
        //Maju();

        rbSpeedBoat.velocity = new Vector3(joystick.Horizontal * sideWayForce,
                                            rbSpeedBoat.velocity.y,
                                            rbSpeedBoat.velocity.z);

        rbSpeedBoat.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void Maju()
    {
        

        rbSpeedBoat.AddForce(0, 0, fowardForce * Time.deltaTime);
        rbSpeedBoat.constraints = RigidbodyConstraints.FreezeRotationX;
    }
 }
