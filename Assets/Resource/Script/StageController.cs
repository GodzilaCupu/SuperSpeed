using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public LevelPiece[] levelPieces;
    public Transform _camera;

    public int drawdistance;
    int currentCampStep = 0;
    int LastCampStep = 0;

    public float pieceLength;
    public float speed;
    //float hitungKecepatan;

    bool isPaused = false;
    public PopupMenuController popup;

    Queue<GameObject> activePiece = new Queue<GameObject>();
    List<int> probabilityList = new List<int>();


    // Start is called before the first frame update
    void Start()
    {
        BuildProbabilityList();
        // starting spawn a lavel '
        for (int i = 0; i < drawdistance; i++)
        {
            NewSpawnLevelPieces();
        }
        currentCampStep = (int)(_camera.transform.position.z / pieceLength);
        LastCampStep = currentCampStep;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         float a = 3;
         float b = 10;
         float c = 30;
         float d = 70;
         float e = 120;
         hitungKecepatan += Time.deltaTime;

         if (hitungKecepatan < a)
         {
             _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * 1.5f);
         }
         else if(hitungKecepatan<b)
         {
             _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * 3f);

         }else if (hitungKecepatan<c)
         {
             _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * 6f);

         }else if (hitungKecepatan<d)
         {
             _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * 12f);

         }*/
        //move camera foward

        if (!isPaused)
        {
            Resume();
        }else if (isPaused)
        {
            Pause();
        }

        //calculate current position in level pieces and check if it has change since the last frame/
        currentCampStep = (int)(_camera.transform.position.z / pieceLength);
        if (currentCampStep != LastCampStep)
        {
            // if it change, update the last camera position adn spawn/despawn the level pieces 
            LastCampStep = currentCampStep;
            DelateLevelPiecesCurrent();
            NewSpawnLevelPieces();
        }
    }

    public void Pause()
    {
        isPaused = true;
        popup.Pause();
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime * 0f);
    }

    public void Resume()
    {
        isPaused = false;
        _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, _camera.transform.position + Vector3.forward, Time.deltaTime *speed);
        popup.Resume();

    }

    void NewSpawnLevelPieces()
    {
        //          get a levelpiece from the probabilitylist and use it to spawn a new spwannewlevel pieces and add it to the active pieces quertenion 

        int PiecesIndex = probabilityList[Random.Range(0, probabilityList.Count)];
        GameObject newLevelPeice = Instantiate(levelPieces[PiecesIndex].Prefabs, new Vector3(0f, 0f, (currentCampStep + activePiece.Count) * pieceLength), Quaternion.identity);
        activePiece.Enqueue(newLevelPeice);

    }

    void DelateLevelPiecesCurrent()
    {
        //remove the old piece form active pieces queue and destroy associated gameobject.
        GameObject oldPieces = activePiece.Dequeue();
        Destroy(oldPieces);
    }

    void BuildProbabilityList()
    {
        //create list of integers representing level piece index, the higher of probability, the more that index will appear
        int index = 0;
        foreach (LevelPiece piece in levelPieces)
        {
            for (int i = 0; i < piece.probability; i++)
                probabilityList.Add(index);
            index++;

        }
    }
}

[System.Serializable]
public class LevelPiece
{

    public string name;
    public GameObject Prefabs;
    public int probability = 1;
}
