#if UNITY_EDITOR
namespace CodeHelper.Editor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEngine;

    public class SpawnAssets : EditorWindow
    {
        private string _folderToSpawn, _filename;
        private List<string> _assetNames;
        private int _index, _scriptCount;
        private bool _show, _copyFilenameToClass, _multiSpawn;

        [MenuItem("Code Helper/Spawn Asset")]
        public static void Init()
        {
            Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
            var window = GetWindow<SpawnAssets>("Spawn assets", new Type[] { inspectorType });
            window.minSize = new Vector2(450, 600);
        }


        private void OnEnable()
        {
            var path = "Assets/Code Helper/Script Assets";
            if (Directory.Exists(path)) _assetNames = new(Directory.GetFiles(path));
        }

        private void OnGUI()
        {
            GUILayout.Label("Select folder path");
            _folderToSpawn = EditorGUILayout.TextArea(_folderToSpawn);
            _index = EditorGUILayout.Popup(_index, _assetNames.ToArray());
            GUILayout.Space(10);
            if (GUILayout.Button("Create script")) Spawn();
            _show = EditorGUILayout.Foldout(_show, "Optional settings");
            if (_show)
            {
                _filename = EditorGUILayout.TextField("Enter filename", _filename);
                _copyFilenameToClass = EditorGUILayout.Toggle("File name is class name",_copyFilenameToClass);
                _multiSpawn = EditorGUILayout.Toggle("Multi spawn",_multiSpawn);
                if (_multiSpawn) _scriptCount = EditorGUILayout.IntSlider("Script count",_scriptCount, 1, 10);
            }
        } 

        private void Spawn()
        {
            var filename = _filename == string.Empty ? $"{_folderToSpawn}/{_assetNames[_index].Remove(0, 33)}" : _folderToSpawn + "/"+ _filename + ".cs";
            if (_multiSpawn)
            {
                if (_copyFilenameToClass)
                {
                    for (int i = 0; i < _scriptCount; i++)
                    {
                        var name = filename.Replace(".cs", i.ToString()) + ".cs";
                        var file = File.ReadAllText(_assetNames[_index]);
                        string pattern = @"class\s+(\w+)";
                        Match match = Regex.Match(file, pattern);

                        if (match.Success)
                        {
                            string currentClassName = match.Groups[1].Value;
                            string newContent = file.Replace(currentClassName, _filename + i.ToString());
                            File.WriteAllText(name, newContent);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < _scriptCount; i++)
                    {
                        var name = filename.Replace(".cs", i.ToString()) + ".cs";
                        File.Copy(_assetNames[_index], name, true);
                    }
                }
            }
            
            AssetDatabase.Refresh();
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(filename);
            EditorGUIUtility.PingObject(Selection.activeObject);
        }
    }
}

#endif