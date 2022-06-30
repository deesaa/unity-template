using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class LocalDao<T> : IDao<T>
{
    private readonly string _fileName;
    private readonly string _filePath;

    public LocalDao(string fileName)
    {
        _fileName = fileName;
        _filePath = Path.Combine(UnityEngine.Application.persistentDataPath, _fileName);
    }

    public void Save(T Data)
    {
        var json = JsonConvert.SerializeObject(Data);
        UnityEngine.Debug.Log($"SAVE JSON: {json}");

        var directory = Path.GetDirectoryName(_filePath);
        UnityEngine.Debug.Log($"SAVE PATH: {_filePath}");
        UnityEngine.Debug.Log($"SAVE DIRECTORY: {directory}");

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        File.WriteAllText(_filePath, json);
    }

    public T Load()
    {
        
        if (!File.Exists(_filePath))
        {
            UnityEngine.Debug.Log($"LOAD PATH DOES NOT EXISTS: {_filePath}");
            return default;
        }

        UnityEngine.Debug.Log($"LOAD PATH: {_filePath}");
        var json = File.ReadAllText(_filePath);
        
        UnityEngine.Debug.Log($"LOAD JSON: {json}");
        try
        {
            T data = JsonConvert.DeserializeObject<T>(json);

           // T data = JsonUtility.FromJson<T>(json);
            
            return data;
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Error while FromJson" + e);
            return default;
        }
    }

    public void Delete()
    {
        if (File.Exists(_filePath)) File.Delete(_filePath);
    }
}