using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveSystem
{
    

    public static void SaveValues(Values val)
    {
        string[] export = { JsonUtility.ToJson(val) };
        string path = "D:/NeuralFlappy/values/values.json";
        File.WriteAllLines(path,export);
    }
    public static Values LoadValues()
    {
        string path = "D:/NeuralFlappy/values/values.json";
        string importData = File.ReadAllText(path);
        return JsonUtility.FromJson<Values>(importData);
    }
}
