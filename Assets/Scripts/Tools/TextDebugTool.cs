using System.Collections.Generic;
using UnityEngine;

public class TextDebugTool : MonoBehaviour
{
    private List<TextDebugText> _createdTexts = new List<TextDebugText>();

    private static Dictionary<string, TextDebugTool> _instances = new Dictionary<string, TextDebugTool>();

    public static TextDebugTool GetInstance(string name)
    {
        if (!_instances.ContainsKey(name))
        {
            var tool = new GameObject().AddComponent<TextDebugTool>();
            _instances[name] = tool;
        }

        return _instances[name];
    }

    public void Draw(string text, Vector3 position)
    {
        return;
        
        var textPrefab = Resources.Load<TextDebugText>("TextDebugTextPrefab");
        var textObject = Instantiate(textPrefab, position, Quaternion.identity, transform);
        textObject.Text.text = text;
        _createdTexts.Add(textObject);
    }

    private void OnDestroy()
    {
        Clear();
    }

    public void Clear()
    {
        foreach (var createdText in _createdTexts)
        {
            Destroy(createdText.gameObject);
        }
        _createdTexts.Clear();
    }
}