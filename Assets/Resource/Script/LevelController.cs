using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public BanyakArena[] arena_Arena;
    public Transform kamera;
    public int banyakSpawn;

    public float jedaAntarStage;
    public float speed;

    public bool gerakArena = true;
    public bool tidakGerak= false;

    Queue<GameObject> arenaAktif = new Queue<GameObject>();
    List<int> listKemungkinan = new List<int>();

    int posisiCamSekarang = 0;
    int posisiCamTerakhir = 0;

    private void Start()
    {
            fungsiKemungkinan();
            //spawning area baru
            for (int i = 0; i < banyakSpawn; i++)

            {
                SpawnNewLevelArena();
            }

            posisiCamSekarang = (int)(kamera.transform.position.z / jedaAntarStage);
            posisiCamTerakhir = posisiCamSekarang;

    }

    private void Update()
    {

        kameraJalan();
    }

    void kameraJalan()
    {
        if (gerakArena)
        {

            kamera.transform.position = Vector3.MoveTowards(kamera.transform.position, kamera.transform.position + Vector3.forward, Time.deltaTime * speed);

            posisiCamSekarang = (int)(kamera.transform.position.z / jedaAntarStage);
            if (posisiCamTerakhir != posisiCamSekarang)
            {

                posisiCamTerakhir = posisiCamSekarang;
                DeSpawnLevelArena();
                SpawnNewLevelArena();
            }
        }
        else if (tidakGerak == true)
        {

            kamera.transform.position = Vector3.MoveTowards(kamera.transform.position, kamera.transform.position, Time.deltaTime * 0f);


        }
    }

    void SpawnNewLevelArena()
    {
        int kemungkinanIndex = listKemungkinan[Random.Range(0, listKemungkinan.Count)];

        GameObject newLevelArena = Instantiate(arena_Arena[kemungkinanIndex].stage, new Vector3(0f, 0f, (posisiCamSekarang + arenaAktif.Count ) * jedaAntarStage ), Quaternion.identity);
        arenaAktif.Enqueue(newLevelArena);

    }
    
    void DeSpawnLevelArena()
    {
        GameObject oldArea = arenaAktif.Dequeue();
        Destroy(oldArea);

    }

    void fungsiKemungkinan()
    {
        int index = 0;
        foreach(BanyakArena arena in arena_Arena)
        {
            for (int i = 0; i<arena.kemungkinanSpwan; i++)
            {
                listKemungkinan.Add(index);

            }

            index++;
        }
    }

}

[System.Serializable]
public class BanyakArena
{
    public string nama;
    public GameObject stage;
    public int kemungkinanSpwan;



}