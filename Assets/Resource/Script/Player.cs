using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///  Script Ini dipakai ketika akan membuat sebuah game yang ada finnish nya bukan sebuah game endless run
///  Script Utama Yang di pake
///  Secara Default Yang kepake adalah Script yang versi Basic dengan tambahan tools joystick
/// </summary>
public class Player : MonoBehaviour
{
    [SerializeField]
    private Button btnKanan, btnKiri;
    [SerializeField]
    private Rigidbody rbSpeedBoat;
    [SerializeField]
    private float fowardForce, sideWayForce;
    [SerializeField]
    private bl_Joystick joystick;

    private int xPosIndex = 1;
    private float ypos = 0f;

    private float startpos;
    private Vector3 velocityf = Vector3.zero;


    public float[] xPos ;
    public float speed = 5f;
    public float floorHeight;



    // Start is called before the first frame update
    void Awake()
    {
        #region Versi Basic Kanan Kiri

        //fowardForce = 5f;
        //sideWayForce = 1f;

        #endregion


        #region Versi Advance kanan Kiri        
        
        fowardForce = 5f;
        sideWayForce = 1f;
        
        #endregion

    }

    // Update is called once per frame
    public void Update()
    {
        #region Versi Basic Kanan Kiri 

        ////paksa Maju untuk kaan kiri
        //rbSpeedBoat.AddForce(0, 0, fowardForce * Time.deltaTime);

        ////Cek Kanan Kiri
        ////Gerak Kanan Kiri Dari Input BTN
        //Button kanan = btnKanan.GetComponent<Button>();
        //kanan.onClick.AddListener(geserKanan);

        //Button kiri = btnKiri.GetComponent<Button>();
        //kiri.onClick.AddListener(geserKiri);

        #endregion



        #region Versi Advance kanan Kiri

        //paksa Maju untuk kaan kiri
        rbSpeedBoat.AddForce(0, 0, fowardForce * Time.deltaTime);
        //rbSpeedBoat.isKinematic = true;

        //Cek Kanan Kiri
        //Gerak Kanan Kiri Dari Input BTN
        Button kanan = btnKanan.GetComponent<Button>();
        kanan.onClick.AddListener(geserKanan);


        Button kiri = btnKiri.GetComponent<Button>();
        kiri.onClick.AddListener(geserKiri);

        if (kanan)
            geserKanan();
        if (kiri)
            geserKiri();

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos[xPosIndex], floorHeight + ypos, transform.position.z), Time.deltaTime * speed);

        #endregion


    }


    public void geserKiri()
    {
        #region Versi Basic Kiri 

        //rbSpeedBoat.AddForce(-sideWayForce * Time.deltaTime, 0, 0);

        #endregion



        #region Versi Advance Kiri 

        xPosIndex--;
        if (xPosIndex < 0)
            xPosIndex = 0;

        #endregion
    }

    public void geserKanan()
    {

        #region Versi Basic Kanan

        //rbSpeedBoat.AddForce(sideWayForce * Time.deltaTime, 0, 0);

        #endregion

        #region Versi Advance Kanan

        xPosIndex++;
        if (xPosIndex > xPos.Length - 1)
            xPosIndex = xPos.Length - 1;

        #endregion

    }

}
