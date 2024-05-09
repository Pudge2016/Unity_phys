using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    [Range(0f, 5f)]
    public float speed;

    void Update()
    {
        this.transform.Translate(0, Time.deltaTime * speed * 0.5f, Time.deltaTime * speed);
    }
}
