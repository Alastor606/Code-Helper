#if UNITY_EDITOR
namespace CodeHelper.Editor
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using UnityEditor;
    using UnityEngine;

    public class CodeAssets : EditorWindow
    {
        private string _fileName, _code, _message;

        [MenuItem("Code Helper/Create Asset")]
        public static void Init()
        {
            Type inspectorType = Type.GetType("UnityEditor.InspectorWindow,UnityEditor.dll");
            var window = GetWindow<CodeAssets>("Create code asset", new Type[] { inspectorType });
            window.minSize = new Vector2(450, 600);
        }

        private void OnGUI()
        {
            _fileName = EditorGUILayout.TextField("Enter filename", _fileName);
            GUILayout.Label("Code asset");
            EditorGUILayout.BeginVertical();
            _code = EditorGUILayout.TextArea(_code, GUILayout.ExpandHeight(true));
            EditorGUILayout.EndVertical();
            if (GUILayout.Button("Save asset")) SaveFile();
            GUILayout.Label(_message);
        }

        [MenuItem("Assets/Create/Asset script", false, -1)]
        public static void SaveAsAsset()
        {
            var filename = "Assets/Code Helper/Script Assets/" + Selection.activeObject.name + ".cs";
            if (!Directory.Exists("Assets/HelperPrefabs")) Directory.CreateDirectory("Assets/Code Helper/Script Assets/");
            var file = File.ReadAllText(AssetDatabase.GetAssetPath(Selection.activeObject));
            string pattern = @"class\s+(\w+)";
            Match match = Regex.Match(file, pattern);
            if (match.Success)
            {
                string currentClassName = match.Groups[1].Value;
                string newContent = file.Replace(currentClassName, currentClassName + "Asset");
                File.WriteAllText(filename, newContent);
                AssetDatabase.Refresh();
                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(filename);
                EditorGUIUtility.PingObject(Selection.activeObject);
            }
        }

        private void SaveFile()
        {
            if (_code == string.Empty || _fileName == string.Empty) return;
            var filename = "Assets/Code Helper/Script Assets/" + _fileName + ".cs";
            if (!Directory.Exists("Assets/HelperPrefabs")) Directory.CreateDirectory("Assets/Code Helper/Script Assets/");
            _message = "File creating";
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, _code);
                _message = $"File created in `{filename}`!";
                AssetDatabase.Refresh();
                Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(filename);
                EditorGUIUtility.PingObject(Selection.activeObject);
            }
            else
            {
                File.WriteAllText(filename, _code);
                _message = "File edited";
            }
        }
    }
}

#endif