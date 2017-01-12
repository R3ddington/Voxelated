using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System; // voor [Serializable]

//voor xml
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class SaveSystem : MonoBehaviour
{

    public SaveData saveData; //een instance van savedata, hierin kan je bij de variabelen
    public string fileName;
    private string pathToFile;
    public GameObject pInfo;
    public bool cantSave;

    [Serializable] //dit zorgt ervoor dat je hem in de inspector kan aanpassen
    public class SaveData
    {
        public string playerName;
        public bool playerIsFemale;
        public string friendName;
        public string playerMaterialID;
        public string friendMaterialID;
        public int level;
        public int qubits;
    }

    void Start()
    {
        if (!cantSave)
        {
            pInfo = GameObject.FindGameObjectWithTag("PlayerInfo");
            if (pInfo != null)
            {
                PullInfo();
            }
        }
        
    }

    public void PullInfo()
    {
        pInfo.GetComponent<PlayerInfo>().SendInfo(4, gameObject);
    }

    public void SaveNewData()
    {
        MakePathToFile();
        SaveScoreProgress();
        PrintXMlData();
    }

    public void LoadData(GameObject g)
    {
        LoadScoreProgress(g);
        PrintXMlData();
    }

    public void SetData (string pN, bool pFemale, string fN, string pM, string fM)
    {
        saveData.playerName = pN;
        saveData.playerIsFemale = pFemale;
        saveData.friendName = fN;
        saveData.playerMaterialID = pM;
        saveData.friendMaterialID = fM;
        SaveNewData();
    }

    private void PrintXMlData()
    {
        //print(saveData.playerName);
    }

    private void MakePathToFile()
    {
        pathToFile = Application.dataPath + "/SaveFolder/" + fileName + ".xml";
    }

    public void LoadScoreProgress(GameObject g)
    {
        MakePathToFile();
        //als je nog geen xml bestand hebt
        if (!File.Exists(pathToFile))
        {
            SaveScoreProgress();
            return;
        }

        #region XMl Loading

        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(pathToFile, FileMode.Open);
        saveData = (SaveData)serializer.Deserialize(stream) as SaveData;
        stream.Close();

        #endregion

        string pN = saveData.playerName;
        bool pFemale = saveData.playerIsFemale;
        string fN = saveData.friendName;
        string pM = saveData.playerMaterialID;
        string fM = saveData.friendMaterialID;

        g.GetComponent<OpeningCutSceneOldMan>().GetLoad(pN, pFemale, fN, pM, fM);
    }

    public void SaveScoreProgress()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SaveData));
        FileStream stream = new FileStream(pathToFile, FileMode.Create);
        serializer.Serialize(stream, saveData);
        stream.Close();
    }
}

