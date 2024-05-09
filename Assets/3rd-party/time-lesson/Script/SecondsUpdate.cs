using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    [Range(0f, 10f)]
    public float speed = 2f;

    float timeStartOffset = 0;
    bool gotStartTime = false;

    void Update()
    {
        if (!gotStartTime)
        {
            timeStartOffset = Time.realtimeSinceStartup;
            gotStartTime = true;
        }

        this.transform.position = new Vector3(transform.position.x, transform.position.y, ( Time.realtimeSinceStartup - timeStartOffset ) * speed);
    }
}
