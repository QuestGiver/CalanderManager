using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Test : MonoBehaviour
{
    List<MonthSettingsNode> nodes;
    DateTracker dateTracker;
    // Start is called before the first frame update
    void Start()
    {
        GameObject calander = GameObject.Find("TimeObject");
        dateTracker = calander.GetComponent<Calander>().dateTracker;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeData()
    {
        GameObject calander = GameObject.Find("TimeObject");
        nodes = calander.GetComponent<Calander>().dateTracker.PoolMonthSettingsList;
        FileStream fs = new FileStream(Application.dataPath + "/UserSaveData.dat", FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fs, nodes);
        fs.Close();
    }

    public void LoadUserData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/UserSaveData.dat", FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        nodes = (List<MonthSettingsNode>)binaryFormatter.Deserialize(fs);
        dateTracker.PoolMonthSettingsList = nodes;
    }

    //public void MakeData()
    //{
    //    GameObject calander = GameObject.Find("TimeObject");
    //    nodes = calander.GetComponent<Calander>().dateTracker.PoolMonthSettingsList;
    //    UserAppData data = new
    //                                    UserAppData(
    //                                                            Clock.Second,
    //                                                            Clock.Minute,
    //                                                            Clock.Hour,
    //                                                            Date.day,
    //                                                            Date.month.numericPlacement,
    //                                                            Date.year
    //                                                          );
    //    Debug.Log(JsonUtility.ToJson(data) + "\n" + MonthListToJSON(nodes));
    //    File.WriteAllText(Application.dataPath + "/UserData.txt", JsonUtility.ToJson(data) + "\n " + MonthListToJSON(nodes));
    //}

    //public void LoadData()
    //{
    //    string temp = "";

    //    if (File.Exists(Application.dataPath + "/UserData.txt"))
    //    {
    //        temp = File.ReadAllText(Application.dataPath + "/UserData.txt");   
    //    }
         

    //}

    //string MonthListToJSON(List<MonthSettingsNode> _nodes)
    //{
    //    string temp = "";
    //    foreach  (MonthSettingsNode node in _nodes)
    //    {
    //        temp += JsonUtility.ToJson(node) + "\n";
    //    }
    //    return temp;

    //}
}
