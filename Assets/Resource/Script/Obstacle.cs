using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private StageController gerak;
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private PopupMenuController popup;

    private void Update()
    {
        if (SuzukiPoint.suzukiScore == 100)
        {
            popup.Win();
            gerak.enabled = false;
            Debug.Log("Beerhasill akhirnya ");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Rock" 
           || collision.collider.tag == "Sponsor" 
           || collision.collider.tag == "Bouy")
        {
            Debug.Log(collision.collider.tag);
            gerak.enabled = false;
            popup.Lose();
            

            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }

    }



}


