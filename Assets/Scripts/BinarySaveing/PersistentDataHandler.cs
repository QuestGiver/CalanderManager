using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PersistentDataHandler : MonoBehaviour
{
    [SerializeField]
    Calander calander;
    DateTracker dateTracker;
    [SerializeField]
    ClockTracker clockTracker;
    UserClockData savedClockData;
    UserCalanderData savedCalanderData;

    private void Start()
    {
        dateTracker = calander.dateTracker;
    }

    public void SaveUserData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/UserSaveData.dat", FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fs, packPersistentData());
        fs.Close();
       
    }

    public void LoadUserData()
    {
        FileStream fs = new FileStream(Application.dataPath + "/UserSaveData.dat", FileMode.Open);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        PersistentData userSave = (PersistentData)binaryFormatter.Deserialize(fs);
        calander.LoadSaveDate(userSave.calanderData);
        clockTracker.LoadSaveData(userSave.clockData);
        fs.Close();
    }

    PersistentData packPersistentData()
    {
        savedCalanderData = new UserCalanderData
            (
                Date.day,
                Date.month.numericPlacement, 
                Date.year, 
                dateTracker.PoolMonthSettingsList
            );

        savedClockData = new UserClockData
            (
                Clock.Second,
                Clock.Minute,
                Clock.Hour
             );


        return new PersistentData(savedCalanderData, savedClockData);
    }
}
