using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    private static float speed = 3;
    private float factor = 0;
    private MeshRenderer ren;

    private void Awake()
    {
        ren = GetComponent<MeshRenderer>();
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(true));

    }

    public void FadeOut()
    {
        StartCoroutine(Fade(false));

    }

    public IEnumerator Fade(bool isFadeIn)
    {
        float dest = isFadeIn ? 3 : 0;

        if (isFadeIn)
        {

            while (factor < dest)
            {
                factor += Time.deltaTime * speed;
                ren.material.SetFloat("_Range", factor);
                yield return null;
            }
        }
        else
        {
            while (factor > dest)
            {
                factor -= Time.deltaTime * speed;
                ren.material.SetFloat("_Range", factor);
                yield return null;
            }
        }
    }

}
