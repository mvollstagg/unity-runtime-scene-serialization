using UnityEngine;
using Unity.RuntimeSceneSerialization;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SaveGameManager : MonoBehaviour
{
    private string saveDirectoryName = "saves";
    private string saveFileName = "save.json";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveScene();
        }
        else if (Input.GetKeyDown(KeyCode.F9))
        {
            LoadScene();
        }
    }

    public void SaveScene()
    {
        var activeScene = SceneManager.GetActiveScene();
        if (!activeScene.IsValid())
            return;

        var path = Path.Combine(Application.dataPath, saveDirectoryName);

        if (string.IsNullOrEmpty(path))
            return;

        var assetPackPath = Path.ChangeExtension(path, ".asset");
        assetPackPath = assetPackPath.Replace(Application.dataPath, "Assets");

        var assetPack = AssetDatabase.LoadAssetAtPath<AssetPack>(assetPackPath);
        var created = false;
        if (assetPack == null)
        {
            created = true;
            assetPack = ScriptableObject.CreateInstance<AssetPack>();
        }
        else
        {
            assetPack.Clear();
        }

        var renderSettings = SerializedRenderSettings.CreateFromActiveScene();
        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(activeScene.path);
        if (sceneAsset != null)
            assetPack.SceneAsset = sceneAsset;

        File.WriteAllText(path, SceneSerialization.SerializeScene(activeScene, renderSettings, assetPack));

        //if (created)
        //{
        //    if (assetPack.AssetCount > 0)
        //        AssetDatabase.CreateAsset(assetPack, assetPackPath);
        //}
        //else
        //{
        //    if (assetPack.AssetCount > 0)
        //        EditorUtility.SetDirty(assetPack);
        //    else if (AssetDatabase.LoadAssetAtPath<AssetPack>(assetPackPath) != null)
        //        AssetDatabase.DeleteAsset(assetPackPath);
        //}

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    public void LoadScene()
    {
        var fullPath = Path.Combine(Application.persistentDataPath, saveDirectoryName, saveFileName);
        if (File.Exists(fullPath))
        {
            string sceneJson = File.ReadAllText(fullPath);

            // Placeholder for the process to deserialize the AssetPack from a file
            var assetPackPath = Path.Combine(Application.persistentDataPath, saveDirectoryName, "assetPack.json");
            AssetPack assetPack = null;
            if (File.Exists(assetPackPath))
            {
                string assetPackJson = File.ReadAllText(assetPackPath);
                assetPack = JsonUtility.FromJson<AssetPack>(assetPackJson);
            }

            SceneSerialization.ImportScene(sceneJson, assetPack);
            Debug.Log("Scene loaded from " + fullPath);
        }
        else
        {
            Debug.LogError("Save file not found at " + fullPath);
        }
    }
}
