using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject spawningObject;
    public int columnLength, rowLength;
    public float step = 5f;
    public ColorType[] colors;

    Vector3 offset;

    private void Start()
    {
        offset = new Vector3(0f, spawningObject.GetComponent<Renderer>().bounds.size.y / 2, 0f);

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            //specify color type of block
            int index = Random.Range(0, colors.Length);
            spawningObject.GetComponent<Block>().colorType = colors[index];
            //instantiate block
            GameObject temp = Instantiate(spawningObject, new Vector3(transform.position.x + (step * (i % columnLength)), transform.position.y, transform.position.z + (step * (i / columnLength))) + offset, Quaternion.identity);
            temp.transform.parent = this.transform;
        }
    }

    private void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        offset = new Vector3(0f, spawningObject.GetComponent<Renderer>().bounds.size.y / 2, 0f);
        for (int i = 0; i < columnLength * rowLength; i++)
        {
            Gizmos.DrawCube(new Vector3(transform.position.x + (step * (i % columnLength)), transform.position.y, transform.position.z + (step * (i / columnLength))) + offset, spawningObject.GetComponent<Renderer>().bounds.size);
        }
    }
}
