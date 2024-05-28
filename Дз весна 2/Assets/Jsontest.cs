using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Jsontest : MonoBehaviour
{
    public Text name; 
    public Text lvl;
    public Slider data1;
    public string jsonurl;
    public Jsonclass jsonData;
    // Start is called before the first frame update
    void Start()
    {
        data1.interactable = false;
        StartCoroutine(getData());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator getData()
    {
        Debug.Log("Download ...");
        var uwr = new UnityWebRequest(jsonurl);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultfile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultfile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            name.text = "ERROR";
        else
        {
            Debug.Log("Download saved to: " + resultfile);
            jsonData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            name.text = jsonData.Name.ToString();
            lvl.text = jsonData.LVL.ToString();
            data1.value = jsonData.LVL;
            yield return StartCoroutine(getData());
        }
    }
}
[System.Serializable]

public class Jsonclass
{
    public string Name;
    public int LVL;
}
