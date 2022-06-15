using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLlevable : InteractConObjeto
{
    public static ObjetoLlevable objetoLlevable;
    private static bool interactActivado = true;

    public CharacterController controller;
    public Transform detectarSuelo;
    public LayerMask suelo;
    public float distanciaSuelo = 0.1f;

    private Vector3 v;
    private bool ground;
    private bool llevando = false;
    private bool puedeSoltar = true;

    [SerializeField]
    private Transform mano;
    [SerializeField]
    private float maxDistancia = 3f;
    [SerializeField]
    private float maxMovimiento = 5f;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        GameObject m = GameObject.Find("Mano");
        if (m != null) mano = m.transform;
    }

    // Update is called once per frame
    new void Update() {
        ((InteractConObjeto)this).Update();
        ground = Physics.CheckSphere(detectarSuelo.position, distanciaSuelo, suelo);
        if (!llevando) {
            if (ground) {
                v = Vector3.zero;
            } else {
                v += new Vector3(0, -9.8f, 0) * Time.deltaTime;
            }
            controller.Move(v * Time.deltaTime);
            return;
        }
        if (!isPulsadoAntes()) puedeSoltar = true;
        transform.rotation = mano.rotation;
        Vector3 d = mano.position - transform.position;
        float s = maxMovimiento * Time.deltaTime;
        float cdist = d.magnitude;
        if (d.magnitude > s) {
            d.Normalize();
            d *= s;
        }
        controller.Move(d);
        if ((ObjetoLlevable.interactActivado && puedeSoltar && Input.GetKeyDown(getInteractKey())) || cdist > maxDistancia) {
            soltar();
        }
    }

    public void soltar() {
        if (llevando) {
            llevando = false;
            ObjetoLlevable.objetoLlevable = null;
            v = Vector3.zero;
            ground = false;
        }
    }

    override public void interact() {
        if (!llevando && ObjetoLlevable.objetoLlevable == null) {
            ObjetoLlevable.objetoLlevable = this;
            llevando = true;
            puedeSoltar = false;
        }
    }

    public static void setInteractActivado(bool interactActivado) {
		ObjetoLlevable.interactActivado = interactActivado;
	}
}
