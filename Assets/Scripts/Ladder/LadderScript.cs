using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public GameObject stair;
    public int ladderLength = 10;

    Vector3 stairSize;

    private void Awake()
    {
        stairSize = stair.transform.Find("StairObject").GetComponent<Renderer>().bounds.size;
        for (int i = 0; i < ladderLength; i++)
        {
            GameObject temp = Instantiate(stair, new Vector3(transform.position.x - (i * stairSize.x), transform.position.y + (i * stairSize.y), transform.position.z), Quaternion.identity);
            temp.transform.parent = this.transform;
            temp.transform.Find("TriggerBuild").GetComponent<StairScript>().number = i;
        }
    }

    //need to be changed to local space both spawn and gizmos
    private void OnDrawGizmos()
    {
        stairSize = stair.transform.Find("StairObject").GetComponent<Renderer>().bounds.size;
        for (int i = 0; i < ladderLength; i++)
        {
            Gizmos.DrawCube(transform.TransformDirection(new Vector3(transform.position.x - (i * stairSize.x), transform.position.y + (i * stairSize.y), transform.position.z)), stairSize);
        }
    }
}
