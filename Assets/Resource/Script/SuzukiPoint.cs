using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuzukiPoint : MonoBehaviour
{
    private GameObject pointTxt;

    public static int suzukiScore;
    public AudioSource collectSound;
    private void Start()
    {
        pointTxt = GameObject.FindGameObjectWithTag("Logo");
    }

    private void Update()
    {
        scoringSystem();       
    }

    private void OnTriggerEnter(Collider other)
    {
        collectSound.Play();
        suzukiScore += 10;
        Destroy(gameObject);
        Debug.Log("Berhasil dapet point");
    }

    public void scoringSystem()
    {
        pointTxt.GetComponent<Text>().text = "" + suzukiScore;

    }

}