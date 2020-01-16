using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveSystem
{
    /*
    public static void SaveLapTimeToFile()
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";//gets path to a data directory (for diff os), creates a new file called player.data
        FileStream stream = new FileStream(path, FileMode.Create);//creates the new file

        EndOfRace data = new EndOfRace.GetLapTime();

        formatter.Serialize(stream, data);//to write data to the file (convets to binary)
        stream.Close();//close the stream when finished writing data
    }
    public static EndOfRace LoadLapTime()
    {
        string path = Application.persistentDataPath + "player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);//openes the file

            EndOfRace data = formatter.Deserialize(stream) as EndOfRace;// converts the binary file
            stream.Close();//closes the file stream 
            return data;
        }
        else
        {
            Debug.LogError("file not save file at: " + path);
            return null;
        }
    }
*/
}
