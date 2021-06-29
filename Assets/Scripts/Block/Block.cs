using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public ColorType colorType;
    public ParticleSystem[] particles;

    private void Awake()
    {
        switch (colorType)
        {
            case ColorType.red: 
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                foreach (ParticleSystem ps in particles)
                {
                    var main = ps.main;
                    main.startColor = Color.red;
                }
                break;
            case ColorType.blue: 
                gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                foreach (ParticleSystem ps in particles)
                {
                    var main = ps.main;
                    main.startColor = Color.blue;
                }
                break;
            case ColorType.green: 
                gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                foreach (ParticleSystem ps in particles)
                {
                    var main = ps.main;
                    main.startColor = Color.green;
                }
                break;
            default: break;
        }
    }

    public static Color ToColor(ColorType type)
    {
        switch (type)
        {
            case ColorType.red: return Color.red;
            case ColorType.green: return Color.green;
            case ColorType.blue: return Color.blue;
            default: return Color.gray;
        }
    }
}

public enum ColorType
{ 
    red,
    green,
    blue
}
