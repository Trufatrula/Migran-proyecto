using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibroPosFix : MonoBehaviour
{
    private Vector3 pos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setPos(Vector3 p) {
        pos = p;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = transform.position;
        if (p.x == 0 && p.y == 0 & p.z == 0) {
            Debug.Log("posFixed");
            transform.position = pos;
        }
    }
}
