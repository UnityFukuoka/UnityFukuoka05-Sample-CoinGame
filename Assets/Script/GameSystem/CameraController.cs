using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CameraController : MonoBehaviour {

    public CameraContainer[] cameras;
    public bool CallCamera(string key)
    {
        foreach(var camera in cameras) { camera.camera.gameObject.SetActive(false); }
        cameras.First(n => n.key == key).camera.gameObject.SetActive(true);
        return true;
    }
}

[System.Serializable]
public class CameraContainer
{
    public string key;
    public Camera camera;
}