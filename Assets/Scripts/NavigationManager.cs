using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationManager : MonoBehaviour
{

    public NavMeshAgent[] agents;
    public Transform target;
    public int deads = 25;
    public float interval = 5;
    private float timer = 0;

    private void OnEnable()
    {
        agents = FindObjectsOfType<NavMeshAgent>();
        foreach (var v in agents)
        {
            v.SetDestination(target.position);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0;
            for (int i = 0; i < deads; i++)
            {
                int num = Random.Range(0, agents.Length);
                agents[num].gameObject.SetActive(false);
            }
        }
    }





}
