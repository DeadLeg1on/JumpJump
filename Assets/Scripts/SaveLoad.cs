using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
 
public class SaveLoad : MonoBehaviour
{
    //public GameObject namePan;
 
    private Save sv = new Save();
    private string path;
 
    private void Start()
    {
    #if UNITY_ANDROID && !UNITY_EDITOR
            path = Path.Combine(Application.persistentDataPath, "Save.json");
    #else
            path = Path.Combine(Application.dataPath, "Save.json");
    #endif
        if (File.Exists(path))
        {
            sv = JsonUtility.FromJson<Save>(File.ReadAllText(path));
            gameObject.GetComponent<Text>().text = sv.gold.ToString();
            //Debug.Log("Добро пожаловать: " + sv.name + "\nВаш возраст: " + sv.age);
        }
        //else namePan.SetActive(true);
    }
 
#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
#endif
    private void OnApplicationQuit()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sv));
    }
}

[Serializable]
public class Save
{
    //public string name;
    public int gold;
}