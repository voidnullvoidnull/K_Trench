using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraChanger : MonoBehaviour {


    public enum CameraSet
    {
        first,
        second
    }

    public CameraSet activeCamera = CameraSet.first;

    public GameObject fist;
    public GameObject second;

    private string cameraSettingsFileName = "CameraSet.json";

    private void Start()
    {
        if (File.Exists(cameraSettingsFileName))
        {
            activeCamera = JsonUtility.FromJson<CameraSet>(
                File.ReadAllText(cameraSettingsFileName)
                );
        }
        Apply();
    }

    public void Apply()
    {
        switch (activeCamera)
        {
            case CameraSet.first:
                second.SetActive(false);
                fist.SetActive(true);
                break;
            case CameraSet.second:
                second.SetActive(true);
                fist.SetActive(false);
                break;
        }
        File.WriteAllText(cameraSettingsFileName, 
            JsonUtility.ToJson(activeCamera)
            );
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            activeCamera = CameraSet.first;
            Apply();
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            activeCamera = CameraSet.second;
            Apply();
        }
    }


}
