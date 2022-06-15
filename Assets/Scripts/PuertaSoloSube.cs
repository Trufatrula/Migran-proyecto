using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaSoloSube : MonoBehaviour
{

    private float y;

    void FixedUpdate()
    {
        Vector3 p = transform.position;
        y+= Time.deltaTime;
        p.y += Time.deltaTime;
        transform.position = p;
        if (y >= 2f) Destroy(this);
    }
}
