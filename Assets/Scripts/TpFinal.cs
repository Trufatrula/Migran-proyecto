using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpFinal : InteractConObjeto
{
    [SerializeField]
    private Material encendido;

    [SerializeField]
    private Vector3 position;
    [SerializeField]
    private Quaternion rotation;

    private bool activado = false;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    public void activar() {
        activado = true;
        gameObject.GetComponent<MeshRenderer>().material = encendido;
    }

    // Update is called once per frame
    new void Update()
    {
        ((InteractConObjeto)this).Update();
    }

    override public void interact() {
        if (activado) {
            player.GetComponent<MoveJugador>().setAllowTp();
            player.transform.position = position;
            player.transform.rotation = rotation;
            //añadir fase final
        }
    }

}
