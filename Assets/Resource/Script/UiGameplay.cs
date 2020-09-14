using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UiGameplay : MonoBehaviour
{
    [SerializeField] 
    private float delayLoading = 5f;
    private float timeElapsed;

    public int countDownTime = 5;
    public Text countdownText;

    public PopupMenuController Popup;
    public PlayerMove gerak;

    private void Awake()
    {
        timeElapsed += Time.deltaTime;
        if (delayLoading > timeElapsed){
            OnDisable();
            StartCoroutine(CountDownStart());
        }else
        {
            OnEnable();

        }
    }

    private void OnDisable()
    {
        gerak.Maju();
    }

    private void OnEnable()
    {
        gerak.Maju();
    }

    public void Update()
    {
        Popup.StartScore();

    }

    IEnumerator CountDownStart()
    {

        while (countDownTime > 0)
        {
            Popup.CountDown();  

            countdownText.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        countdownText.text = "Go !!!";

        //Pas udah ada gameplaynya masukin dan bikin script baru untuk gameplay sendiri
        //GameController.instance.BeginGame();
        //Popup.StartScore();

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        Popup.CountDownMati();
        Popup.BelumMulaiScore();
        Popup.StartScore();
    }
}
