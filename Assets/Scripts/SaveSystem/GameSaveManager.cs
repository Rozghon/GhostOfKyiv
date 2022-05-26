using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaveManager : MonoBehaviour
{
    public static GameSaveManager instance;

    public PlaneUpdates[] _planes;
    public SityUpdates[] _sities;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);

        LoadGame();
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/Saves");
    }

    public void SaveGame()
    {
        if(!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }

        CreateDirectories();

        for(int i = 0; i < _planes.Length; i++)
        {
            string _path = "/Saves/Planes/Plane" + i.ToString() + ".txt";
            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream _file = File.Create(Application.persistentDataPath + _path);
            var _json = JsonUtility.ToJson(_planes[i]);
            _formatter.Serialize(_file, _json);
            _file.Close();
        }
        for (int i = 0; i < _sities.Length; i++)
        {
            string _path = "/Saves/Cities/City" + i.ToString() + ".txt";
            BinaryFormatter _formatter = new BinaryFormatter();
            FileStream _file = File.Create(Application.persistentDataPath + _path);
            var _json = JsonUtility.ToJson(_sities[i]);
            _formatter.Serialize(_file, _json);
            _file.Close();
        }
    }

    public void LoadGame()
    {
        CreateDirectories();
        BinaryFormatter _formatter = new BinaryFormatter();

        for (int i = 0; i < _planes.Length; i++)
        {
            string _path = "/Saves/Planes/Plane" + i.ToString() + ".txt";
            if(File.Exists(Application.persistentDataPath + _path))
            {
                FileStream _file = File.Open(Application.persistentDataPath + _path, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)_formatter.Deserialize(_file), _planes[i]);
                _file.Close();
            }
        }

        for (int i = 0; i < _sities.Length; i++)
        {
            string _path = "/Saves/Cities/City" + i.ToString() + ".txt";
            if (File.Exists(Application.persistentDataPath + _path))
            {
                FileStream _file = File.Open(Application.persistentDataPath + _path, FileMode.Open);
                JsonUtility.FromJsonOverwrite((string)_formatter.Deserialize(_file), _sities[i]);
                _file.Close();
            }
        }
    }

    private void CreateDirectories()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/Saves/Planes"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/Planes");
        }
        if (!Directory.Exists(Application.persistentDataPath + "/Saves/Sities"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/Cities");
        }
    }

}
