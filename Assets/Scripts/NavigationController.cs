using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{
    public NavMeshAgent agent; // trigger to spawn and despawn AR arrows
    public GameObject trigger; // trigger to spawn and despawn AR arrows
    public Transform[] destinations; // list of destination positions
    public GameObject person; // person indicator
    //public GameObject cam; // camera indicator
    private NavMeshPath path; // current calculated path
    private LineRenderer line; // linerenderer to display path
    public Transform target; // current chosen destination
    public Dropdown myDropdown;
    private bool destinationSet; // bool to say if a destination is set

    //create initial path, get linerenderer.
    void Start()
    {
        agent.updateUpAxis = false;
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        destinationSet = false;
        line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.green };
        line.startWidth = 0.2f;
        line.endWidth = 0.2f;
        line.startColor = Color.green;
        line.endColor = Color.green;
        line.transform.position = line.transform.up * -1f;
        PopulateDropdown(myDropdown, destinations);
        //InvokeRepeating("CreateBreadCrumb", 2f, 1f);
    }

    void PopulateDropdown(Dropdown dropdown, Transform[] optionsArray)
    {
        List<string> options = new List<string>();
        foreach (var option in optionsArray)
        {
            options.Add(option.name); // Or whatever you want for a label
        }
        dropdown.AddOptions(options);
    }

    void Update()
    {
        //if a target is set, calculate and update path
        if (target != null)
        {
            NavMesh.CalculatePath(person.transform.position, target.position,
                          NavMesh.AllAreas, path);
            //lost path due to standing above obstacle (drift)
            if (path.corners.Length == 0)
            {
                Debug.Log("Try moving away from obstacles (optionally recalibrate)");
            }
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
            line.enabled = true;
        }
    }

    //void CreateBreadCrumb()
    //{
    //    if (target != null)
    //    {
    //        var spawnPose = cam.transform.position + (transform.forward * 1);
    //        //Quaternion rot = cam.transform.rotation;
    //        //Vector3 rotToApply = rot.eulerAngles;
    //        //float rotationToApplyAroundY = rotToApply.y;
    //        //float newCamRotAngleY = Mathf.LerpAngle(Arrow.transform.eulerAngles.y, rotationToApplyAroundY, 2f);
    //        //Quaternion newCamRotYQuat = Quaternion.Euler(0, newCamRotAngleY, 0);
    //        var crumb = Instantiate(trigger, spawnPose, cam.transform.rotation);
    //        //crumb.transform.rotation = newCamRotYQuat;
    //        crumb.GetComponent<BreadcrumbFollow>().target = target;

    //    }
    //}

    //set current destination and create a trigger for showing AR arrows
    public void setDestination(int index)
    {
        target = destinations[index];
        if (GameObject.Find("NavTrigger(Clone)"))
        {
            Destroy(GameObject.Find("NavTrigger(Clone)"));
        }
        GameObject.Instantiate(trigger, person.transform.position, person.transform.rotation);
        Debug.Log("Trigger Created");
    }
}
