using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedUpdateMove : MonoBehaviour
{
    [Range(0f, 10f)]
    public float speed = 2f;

    void FixedUpdate()
    {
        this.transform.Translate(0, 0, Time.deltaTime* speed);
    }
}
