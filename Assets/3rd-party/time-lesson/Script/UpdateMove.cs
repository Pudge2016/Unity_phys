using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    [Range(0f, 10f)]
    public float speed = 2f;

    void Update()
    {
        this.transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
