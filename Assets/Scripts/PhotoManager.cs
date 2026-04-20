using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PhotoManager : MonoBehaviour
{
    private string _path;
    
    public RawImage[] images;
    
    
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

    public void OpenFileExplorer()
    {
        _path = EditorUtility.OpenFilePanel("Open Photo File", "Assets", "png");
        StartCoroutine(GetPhotos());

    }

    private IEnumerator GetPhotos()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + _path);
        yield return www.SendWebRequest();

        switch (www.result)
        {
            case UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError:
                Debug.Log(www.error);
                break;
            case UnityWebRequest.Result.Success:
            {
                Texture newTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
                GlobalVariables.PhotosTextures.Add(newTexture);
                RefreshPhotos();
                break;
            }
        }
    }
}
