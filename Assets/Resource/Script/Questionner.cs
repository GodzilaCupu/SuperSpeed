using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Questionner : MonoBehaviour
{
    [SerializeField]
    private InputField nama, noTlp, sosMed, q1, q2;
    [SerializeField]
    private Loading Loading;
    [SerializeField]
    private PopupMenuController PopupMenu;
    //[SerializeField]
    //private Button btnNext;

    private string Nama, Notelp, Sosmed, Q1, Q2;

    //public GameObject MassageError;
    //public GameObject MissingObject;


    // datanya di check udah masuk apa belom
    public void CheckLoginInfo()
    {
            Nama = nama.text.Trim().ToLower();
            Notelp = noTlp.text.ToString();
            Sosmed = sosMed.text.Trim();
            Q1 = q1.text.ToLower();
            Q2 = q2.text.ToLower();
            
            //di cek dulu gan 
            if (Nama == "" || Sosmed == "" || Notelp == "" || Q1 == "" || Q2 == "")
            {

            //PesanError();
            
            PopupMenu.ErrorMassage();

            Debug.Log("Somthing Empty, please Fill the blank");
            }
            else
            {
            Debug.Log("yeayy berhasil");
            Debug.Log("Nama ku adalah " + Nama);
            Debug.Log("Nomor telfon ku" + Notelp );
            Debug.Log("Sosmed aku " + Sosmed);
            Debug.Log("Jawabannnya Q1" + Q1);
            Debug.Log("Jawabannnya Q2" + Q2);

            Save();
            Loading.LoadLevel(1);
        }
    }

    //Udah Gak Dipake Karena udah Ngambil dari popupmenucontroller

    //void PesanError()
    //{
    //    MassageError.SetActive(true);
    //    Time.timeScale = 0f;
    //    Debug.Log("Pesan Error Muncul");
    //}


    // data ditampung 
    void dataContainner()
    {
        // inisialisi ulang
        Nama = nama.text;
        Notelp = noTlp.text;
        Sosmed = sosMed.text;
        Q1 = q1.text;
        Q2 = q2.text;
     }


    void Save() 
    {

        // Membuat Objek JSON baru sebagai Containner data
        JSONObject data = new JSONObject();

        // data di simpan dalam bentuk JSON
        data.Add("Nama ",Nama);
        data.Add("Nomor Telfonnya ",Notelp);
        data.Add("Social Medianya ",Sosmed);
        data.Add("Jawaban dari Pertanyaan 1 ",Q1);
        data.Add("Jawaban dari Pertanyaan 2 ",Q2);

        // di cek apaakah bisa di simpan dalam bentuk JSON
        Debug.Log(data.ToString());

        //save ke directori lokal
        string TempatData = Application.persistentDataPath + "/TesDataPlayerSay.Json";
        File.WriteAllText(TempatData, data.ToString());
    }

    //Akses datanya Lagi
    void Load()
    {

        //Load dari disimpannya data Json kita
        string TempatData = Application.persistentDataPath + "/TesDataPlayerSay.Json";

        // script untuk convert balik ke string
        string jsonStringBalik = File.ReadAllText(TempatData);

        // bikin object baru sebagai containner function nya
        JSONObject dataDariJson = (JSONObject)JSON.Parse(jsonStringBalik);

        //Deklarasiin tipe data lagi biar bisa di baca di C#
        Nama = dataDariJson["Nama "];
        Notelp = dataDariJson["Nomor Telfonnya "];
        Sosmed = dataDariJson["Social Medianya "];
        Q1 = dataDariJson["Jawaban dari Pertanyaan 1 "];
        Q2 = dataDariJson["Jawaban dari Pertanyaan 2 "];
      
    }
}

