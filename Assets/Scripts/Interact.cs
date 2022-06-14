using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interact : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float distancia = 1.2f;
    [SerializeField]
    private float angulo = Mathf.PI / 2f;
    private bool interactuando = false;

    public bool estaInteractuando() {
		return interactuando;
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update() {
        Vector3 rotJugador = player.transform.forward;
        Vector3 pos = transform.position;
        Vector3 dir = pos - player.transform.position;
        float dist = dir.magnitude;
        float ang = Mathf.Acos(Vector3.Dot(dir.normalized, rotJugador));
        bool interacting = false;
        if (dist < distancia && ang < angulo) {
            interacting = true;
        }
        if (interacting != interactuando) {
            interactuando = interacting;
            if (interactuando) {
                entrarInteract();
            } else {
                salirInteract();
            }
        }
    }

    public abstract void entrarInteract();
	public abstract void salirInteract();

    public void setDistancia(float d) {
        distancia = d;
    }

}
