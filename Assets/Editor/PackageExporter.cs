using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class PackageExporter
{
    // Packages以下を指定する場合フォルダパスではなく Packages/{パッケージ名} なので注意
    private static readonly string PackagePath = "Packages/com.kameffee.unity-package-test";

    [MenuItem("Edit/Export")]
    private static void Export()
    {
        // 出力ファイル名
        var fileName = "UnityPackageTest.unitypackage";

        var exportedPackageAssetList = new List<string>();
        foreach (var guid in AssetDatabase.FindAssets("", new[] { PackagePath }))
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);

            Debug.Log(path);
            exportedPackageAssetList.Add(path);
        }

        AssetDatabase.ExportPackage(exportedPackageAssetList.ToArray(),
            fileName,
            ExportPackageOptions.Recurse);
    }
}
