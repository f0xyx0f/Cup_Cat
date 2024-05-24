using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public class SaveData : MonoBehaviour
{
    public static bool[] Active = new bool[36];

    public static void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        Data data = new Data();
        data.Active = Active;
        bf.Serialize(file, data);
        file.Close();
    }
    public static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();
            Active = data.Active;
        }
        else
            for (int i = 0; i < Active.Length; i++)
                Active[i] = false;
    }
}
[Serializable]
class Data
{
      public bool[] Active = new bool[36];
}