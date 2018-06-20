using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomActivation : MonoBehaviour {

    public float maxTimeOffset = 15;
    float time = 0;

    private void OnEnable()
    {
        time = Random.Range(0, maxTimeOffset);
        StartCoroutine(Activate());
    }

    private void OnDisable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    IEnumerator Activate()
    {
        yield return new WaitForSeconds(time);
        transform.GetChild(0).gameObject.SetActive(true);
    }

}
