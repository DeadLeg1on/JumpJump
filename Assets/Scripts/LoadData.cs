using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml.Serialization;

[System.Serializable]
public class SaveData
{
   public int gold;
}

public class LoadData : MonoBehaviour
{
    int _DrawGold;
    public void SaveGame(int _gold)
    {
        var xml = new XmlSerializer(typeof(SaveData));
        var save = new SaveData();

        save.gold = _gold;

        using (var stream = new FileStream("save.xml", FileMode.Create, FileAccess.Write))
        {
            xml.Serialize(stream, save);
        }
    }
    public int LoadGame()
    {
        try
        {
            var xml = new XmlSerializer(typeof(SaveData));
            var save = new SaveData();
            using (var stream = new FileStream("save.xml", FileMode.Open, FileAccess.Read))
            {
                save = xml.Deserialize(stream) as SaveData;
            }
            _DrawGold = save.gold;
        }
        catch
        {
            _DrawGold = 0;
        }
        return _DrawGold;
    }

    void Start() 
    {
       LoadGame();
    }

    void Update()
    {

           gameObject.GetComponent<Text>().text = _DrawGold.ToString();

    }
}
