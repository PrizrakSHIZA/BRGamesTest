using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScript : MonoBehaviour
{
    public int number;

    ColorType colorType;
    Material material;
    GameObject stair;
    Collider[] frontBorder;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        stair = transform.Find("../StairObject").gameObject;
        material = stair.GetComponent<MeshRenderer>().material;
        frontBorder = transform.Find("../Border").gameObject.GetComponents<Collider>();
        stair.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collidedObj = collision.gameObject;

        if (collision.tag == "Player")
        {
            PlayerStats PS = collidedObj.GetComponent<PlayerStats>();
            if (PS.blockcount > 0 && (!stair.activeSelf || colorType != PS.playerColor))
            {
                audioSource.pitch = 1 + 0.2f * number;
                audioSource.Play();
                colorType = PS.playerColor;
                PS.RemoveBlock();
                stair.SetActive(true);
                material.color = Block.ToColor(PS.playerColor);
                foreach (Collider col in frontBorder)
                {
                    col.enabled = false;
                }
            }
        }
    }
}
