using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float gap = 0.1f;
    public float speed = 10f;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collidedObj = collision.gameObject;

        if (collidedObj.tag == "Player" && gameObject.GetComponent<Block>().colorType == collidedObj.GetComponent<PlayerStats>().playerColor)
        {
            Transform backpack = GameObject.Find("Backpack").transform;

            transform.parent = backpack;

            //Adds to backpack
            if (collidedObj.GetComponent<PlayerStats>().blockcount == 0)
            {
                StartCoroutine(MoveTo(backpack, Vector3.zero, speed));
            }
            else
            {
                Vector3 additional = new Vector3(0f, (gameObject.GetComponent<Renderer>().bounds.size.y + gap) * collidedObj.GetComponent<PlayerStats>().blockcount, 0f);
                StartCoroutine(MoveTo(backpack, additional, speed));
            }

            transform.rotation = backpack.rotation;

            //disable collider
            Destroy(gameObject.GetComponent<Collider>());

            //increase blockcount in invetory
            collidedObj.GetComponent<PlayerStats>().AddBlock(gameObject);

            //play sound
            audioSource.Play();
        }
    }

    IEnumerator MoveTo(Transform target, Vector3 add, float speed)
    {
        foreach (ParticleSystem ps in gameObject.GetComponent<Block>().particles)
        {
            ps.Play();
        }

        while (Vector3.Distance(transform.localPosition, target.localPosition + add) > 0.01f)
        {
            //Debug.Log(transform.position +" | "+ (target.position + add));
            transform.localPosition = Vector3.Lerp(transform.localPosition, target.localPosition + add, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
