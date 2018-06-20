using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Fader), typeof(AIAgent))]
public class AIAgent : MonoBehaviour {

    public float step = 3;
    public float stepSpeed = 10000;
    public float accel = 3000;
    public Vector3 target;
    private NavMeshAgent agent;
    private Fader fader;
    public MeshRenderer ren;
    public GameObject deadPrefab;

    private void OnEnable()
    {
        ren = GetComponentInChildren<MeshRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target);
        fader = GetComponent<Fader>();
        StartCoroutine(Step());
    }


    IEnumerator Step()
    {
        agent.velocity = Vector3.zero;
        agent.acceleration = 0;
        agent.angularSpeed = 0;
        yield return StartCoroutine(fader.Fade(true));
        yield return new WaitForSeconds(step);
        yield return StartCoroutine(fader.Fade(false));
        Instantiate(deadPrefab, transform.position-Vector3.up, Quaternion.identity);
        agent.acceleration = accel;
        agent.speed = stepSpeed;
        agent.angularSpeed = 10000;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Step());

    }
 

}
