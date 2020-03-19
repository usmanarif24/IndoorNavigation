using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BreadcrumbFollow : MonoBehaviour
{

    private NavMeshAgent agent;

    //public GameObject Cam;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector3.Distance(Camera.main.transform.position, transform.position) > 5 || Vector3.Distance(transform.position, target.transform.position) < 1)
        {
            Destroy(gameObject);
        }
    }
}
