/*
 * HOW TO USE:
 *  1. Make "developmemo.txt" in "Asset" folder.
 *  2. Place this code in "Editor" folder.  (if the "Editor" folder doesn't exists, make the folder in "Asset".)
 *  3. Select [Window -> MemoPad] from unity's menu bar.
 *  4. "Load" & "Save" buttons read & write "developmemo.txt".
 */
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text;

public class MemoPad : EditorWindow {
    private const string filePath = "/developmemo.txt";
    private static string memoText = "";
    private Vector2 scrollPos;

    [MenuItem("Window/MemoPad")]
    public static void ShowWindow() {
        EditorWindow.GetWindow<MemoPad>();
    }

    void OnGUI() {
        EditorGUILayout.LabelField("File");
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Save")) {
            if (!File.Exists(Application.dataPath + filePath)) {
                Debug.Log(filePath + " don't exists.");
            } else {
                FileStream textFile = new FileStream(Application.dataPath + filePath, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(textFile, Encoding.Unicode);
                writer.Write(memoText);
                writer.Close();
                Debug.Log("memo Saved!");
            }
        }
        if (GUILayout.Button("Load")) {
            if (!File.Exists(Application.dataPath + filePath)) {
                Debug.Log(filePath + " don't exists.");
            } else {
                FileStream textFile = new FileStream(Application.dataPath + filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(textFile,Encoding.Unicode);
                if (reader != null) {
                    memoText = "";
                    while (!reader.EndOfStream) {
                        memoText += reader.ReadLine();
                        memoText += "\n";
                    }
                    reader.Close();
                    Debug.Log("memo Loaded!");
                }
            }
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.LabelField("↓Write Memo↓");
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
        memoText = EditorGUILayout.TextArea(memoText);
        EditorGUILayout.EndScrollView();
    }
}
