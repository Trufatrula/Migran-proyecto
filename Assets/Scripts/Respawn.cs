using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private Vector3 pos;
    [SerializeField]
    private float min;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= min) {
            gameObject.GetComponent<MoveJugador>().setAllowTp();
            transform.position = pos;
        }
    }
}
