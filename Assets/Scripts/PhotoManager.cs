using System;
using System.Collections;
using System.Collections.Generic;
using SFB;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class PhotoManager : MonoBehaviour
{
    private string _path;
    public RawImage[] images;

    // --- WebGL podpora ---
#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

    public void OpenFileExplorer() {
        // Na WebGL zavoláme JS metodu, která otevře okno prohlížeče
        // "png, jpg, jpeg" je filtr, "OnWebFileUploaded" je metoda, kterou JS zavolá zpět
        UploadFile(gameObject.name, "OnWebFileUploaded", ".png, .jpg, .jpeg", false);
    }

    // Tuto metodu zavolá JavaScript, až uživatel vybere soubor
    public void OnWebFileUploaded(string url) {
        _path = url;
        StartCoroutine(GetPhotos());
    }
#else
    // --- PC / Editor podpora ---
    public void OpenFileExplorer()
    {
        var extensions = new[] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg")
        };

        StandaloneFileBrowser.OpenFilePanelAsync("Open File", "", extensions, false, (string[] paths) => 
        {
            if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
            {
                _path = paths[0];
                if (!_path.StartsWith("file://") && !_path.StartsWith("http"))
                {
                    _path = "file://" + _path;
                }
                StartCoroutine(GetPhotos());
            }
        });
    }
#endif

    private void Start()
    {
        RefreshPhotos();
    }

    private void RefreshPhotos()
    {
        if (images.Length == 0 || GlobalVariables.PhotosTextures.Count == 4) return;
        for (int i = 0; i < images.Length; i++)
        {
            if (i < GlobalVariables.PhotosTextures.Count)
            {
                images[i].texture = GlobalVariables.PhotosTextures[i];
                images[i].enabled = true;
                continue;
            }
            images[i].enabled = false;
        }
    }

    private IEnumerator GetPhotos()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(_path))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Chyba při načítání: " + www.error);
            }
            else
            {
                Texture2D newTexture = DownloadHandlerTexture.GetContent(www);
                GlobalVariables.PhotosTextures.Add(newTexture);
                RefreshPhotos();
            }
        }
    }
}