using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

    public GameObject[] views;
    public int initialView = 0;

    private void Start()
    {
        views[initialView].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            views[1].SetActive(false);
            views[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            views[1].SetActive(true);
            views[0].SetActive(false);
        }
    }

}
