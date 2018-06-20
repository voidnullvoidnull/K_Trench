using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPlace : MonoBehaviour {

    public float shift;

    private void Awake()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            transform.position = hit.point + new Vector3(0, shift, 0);
        }
    }
}
