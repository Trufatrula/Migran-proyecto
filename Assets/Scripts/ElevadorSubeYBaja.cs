using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevadorSubeYBaja : MonoBehaviour
{
    private Vector3 posicionAbajo;
	private Vector3 posicionArriba;
    private float direccion = 0.01f;


    // Start is called before the first frame update
    void Start()
    {
        posicionAbajo = transform.position;
        posicionArriba = posicionAbajo + new Vector3(0, 7.5f, 0);
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        if (pos.y > posicionArriba.y || pos.y < posicionAbajo.y) {
			direccion = -this.direccion;
			if (pos.y > posicionArriba.y) {
				pos.y = posicionArriba.y;
			} else {
				pos.y = posicionAbajo.y;
			}
		}
		pos.y += direccion;
        transform.position = pos;
    }
}
