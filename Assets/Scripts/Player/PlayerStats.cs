using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public List<GameObject> blocks;
    public GameObject model;
    public ColorType playerColor;
    public int blockcount = 0;

    private void Awake()
    {
        model.GetComponent<SkinnedMeshRenderer>().material.color = Block.ToColor(playerColor);
    }

    public void AddBlock(GameObject obj)
    {
        blocks.Add(obj);
        blockcount++;
    }

    public void RemoveBlock()
    {
        Destroy(blocks[blocks.Count - 1]);
        blocks.RemoveAt(blocks.Count - 1);
        blockcount--;
    }
}
