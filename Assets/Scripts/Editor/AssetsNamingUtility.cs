using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEditorInternal;

public class AssetsNamingUtility : EditorWindow
{
    [MenuItem("Tools/Assets Naming Utility")]
    public static void ShowWindow()
    {
        GetWindow<AssetsNamingUtility>("Assets Naming Utility");
    }

    private void OnGUI()
    {
        GUILayout.Button("Find Assets");
    }

    private void RenameAssets()
    {
        //foreach (var assetObj in _assetsToRename)
        //{
        //    var path = AssetDatabase.GetAssetPath(assetObj);
        //    Debug.Log(path);
        //}
    }
}
