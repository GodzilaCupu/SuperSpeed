using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class Loading : MonoBehaviour
{
    public GameObject LoadingScene;
    public Slider LoadingBar;
    public Text LoadingText;

    public void LoadLevel( int sceneIndex)
    {
        StartCoroutine(LoadAsycnhronasily(sceneIndex));
    }

    IEnumerator LoadAsycnhronasily (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        
        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            Debug.Log("Aku Kepencet Mas :(");
            LoadingBar.value = progress;

            LoadingText.text = progress * 100f + "%";


            yield return null;
        }
    }
}



// Loading Textnya masih bermasalah, ubah kembali uiny menggunakan text biasa jangan menggunakan textmeshpro