using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour {

    public float step = 3;
    public float stepSpeed = 100;
    public float accel = 100;
    public Vector3 target;
    private NavMeshAgent agent;
    private static float speed = 3;
    private float factor = 0;
    public MeshRenderer ren;
    public GameObject deadPrefab;

    private void OnEnable()
    {
        ren = GetComponentInChildren<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target);
        StartCoroutine(Step());
    }


    IEnumerator Step()
    {
        //agent.Stop();
        agent.velocity = Vector3.zero;
        agent.acceleration = 0;
        agent.angularSpeed = 0;
        yield return StartCoroutine(Fade(true));
        yield return new WaitForSeconds(step);

        yield return StartCoroutine(Fade(false));
        Instantiate(deadPrefab, transform.position-Vector3.up, Quaternion.identity);
        agent.acceleration = accel;
        agent.speed = stepSpeed;
        agent.angularSpeed = 10000;
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Step());

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
