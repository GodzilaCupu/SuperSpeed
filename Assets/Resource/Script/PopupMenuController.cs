using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PopupMenuController : MonoBehaviour
{ 

    public static bool PopupExit = false;
    public static bool PopError = false;
    public static bool PopupLoading = false;
    public static bool GameisPause = false;

    //scene 1
    public GameObject PopUpmenuExit;
    public GameObject MissingObject;
    //Scene 2
    public GameObject PauseMenu;
    public GameObject SettingMenu;
    public GameObject CountdownTimer;
    public GameObject scoreText;
    public GameObject losse;

    public Text textScore;
    public GameObject win;

    public Transform boat;

    public Button pause;
    public Button restrat;
    public Button resume;
    public UiGameplay ui;
    public PlayerMove gerak;
    public StageController level;

    //CamController camController;

     

    public void Win()
    {
        win.SetActive(true);
        gerak.Setop();
        Time.timeScale= 0f;
        IsPaused();
    }

    public void Lose()
    {
        losse.SetActive(true);
        gerak.Setop();
        Time.timeScale = 0f;
        IsPaused();

    }
    public void StartScore()
    {
        scoreText.SetActive(true);
        GameisPause = false;
        Time.timeScale = 1f;
        textScore.text = boat.position.z.ToString("0");
    }


    public void BelumMulaiScore()
    {
        scoreText.SetActive(false);
        
    }

    public void CountDown()
    {
        CountdownTimer.SetActive(true);
    }


    public void CountDownMati()
    {
        CountdownTimer.SetActive(false);
    }
    public void menuPopup()
    {
        PopUpmenuExit.SetActive(true);
        Time.timeScale = 0f;
        PopupExit = true;
    }

    public void Yes()
    {
        //camController.keluar();
        Application.Quit();
        Debug.Log("Üdah keluar");
    }

    public void No()
    {
        PopUpmenuExit.SetActive(false);
        Time.timeScale = 1f;
        PopupExit = false;
    }


    public void ErrorMassage()
    {
        MissingObject.SetActive(true);
        PopError = true;
    }

    public void Btn_Ok()
    {
        MissingObject.SetActive(false);
        PopError = false;
    }
    public void CheckIsPause()
    {
        Button btn = pause.GetComponent<Button>();
        btn.onClick.AddListener(Pause);
    }

    public void IsPaused()
    {
        Time.timeScale = 0f;
        GameisPause = true;
        Debug.Log("game is paused");
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
        Debug.Log("game is paused");
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        GameisPause = false;
        Time.timeScale = 1f;
        Debug.Log("game is play again");
    }


    public void ChackIsResume()
    {
        Button resumeBTN = resume.GetComponent<Button>();
        resumeBTN.onClick.AddListener(Resume);
        Debug.Log("Berhasil Resume");

    }

    public void ChackIsRestart()
    {
        Button restartBTN = restrat.GetComponent<Button>();
        restartBTN.onClick.AddListener(Restart);
        Debug.Log("Berhasil Restrat");
    }

    public void Restart()
    {
        //Application.LoadLevel(1);
        //Debug.Log("Berhasil LoadLavel");
        SceneManager.LoadScene(0);
        //Application.LoadLevel("0");
        Debug.Log("berhasil Restrat");
    }

    public void menuSetting()
    {
        PauseMenu.SetActive(false);
        SettingMenu.SetActive(true);
        Time.timeScale = 0f;
        GameisPause = true;
    }

    public void PauseBack()
    {
        PauseMenu.SetActive(true);
        SettingMenu.SetActive(false);
        Time.timeScale = 0f;
        GameisPause = true;
    }
}
