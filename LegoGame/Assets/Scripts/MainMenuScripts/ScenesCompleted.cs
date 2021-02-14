using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class ScenesCompleted
{
    private static List<string> _completed = new List<string>();

    public static void SetCompleted(string _namescene) { _completed.Add(_namescene); SaveCompleted(); }
    
    public static List<string> GetCmopleted() {LoadCompleted(); return _completed; }

    public static bool GetBoolCompleted(string _name)
    {
        LoadCompleted();
        if (_completed.Any(x => x == _name))
        { return true; }
        else
        {return false; }
        
    }

    public static void SaveCompleted()
    {
        var _path = Application.persistentDataPath + "/savecompleted.dat";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(_path, FileMode.OpenOrCreate);
        bf.Serialize(fs,_completed);
        fs.Close();
    }

    public static void LoadCompleted()
    {
        var _path = Application.persistentDataPath + "/savecompleted.dat";
        if (File.Exists(_path))
        {
            using (Stream stream = File.Open(_path, FileMode.Open))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                _completed = (List<string>) bformatter.Deserialize(stream);
            }
        }else{SaveCompleted();}
    }
}




