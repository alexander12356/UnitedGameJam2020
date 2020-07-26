using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
 
public class SpriteSheetExporter : EditorWindow
{
    private Texture2D texture;
    private string name;
    [MenuItem("Window/Spritesheet exporter")]
    public static void ShowWindow()
    {
        GetWindow<SpriteSheetExporter>("Spritesheet Exporter");
    }
 
    private void OnGUI()
    {
        texture = (Texture2D)EditorGUILayout.ObjectField(texture, typeof(Texture2D), allowSceneObjects: false);
        name = EditorGUILayout.TextField("File name: ", name);
        if (GUILayout.Button("Run Function") && texture != null)
        {
            SaveTextureAsPNG(texture, name);
        }
    }
 
    public static void SaveTextureAsPNG(Texture2D texture, string fileName)
    {
        byte[] _bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/Sprite Sheets/";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + fileName + ".png", _bytes);
        Debug.Log(_bytes.Length / 1024 + "Kb was saved as: " + fileName + ".png");
    }
}
