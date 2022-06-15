using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractuarMesa : InteractConObjeto
{
    [SerializeField]
    private GameObject posarLibro1;
    [SerializeField]
    private GameObject posarLibro2;
    [SerializeField]
    private GameObject posarLibro3;

    [SerializeField]
    private Material encendido;
    private int contador = 0;

    // Start is called before the first frame update
    new void Start() {
        setDistancia(3f);
    }

    // Update is called once per frame
    new void Update()
    {
        ((InteractConObjeto)this).Update();
    }

    override public void entrarInteract() {
        base.entrarInteract();
        ObjetoLlevable.setInteractActivado(false);
    }

    override public void salirInteract() {
        base.salirInteract();
        ObjetoLlevable.setInteractActivado(true);
    }

    override public void interact() {
        ObjetoLlevable objetoLlevable = ObjetoLlevable.objetoLlevable;
        if (objetoLlevable != null) {
            GameObject posar = null;
            switch(contador) {
			case 0:
				posar = posarLibro1;
				break;
			case 1:
				posar = posarLibro3;
				break;
			case 2:
				posar = posarLibro2;
				//TODO: iniciar fase 2
				break;
			}
            contador++;
            MeshRenderer renderer = posar.GetComponent<MeshRenderer>();
            renderer.material = encendido;
            //quiza luz
            GameObject o = objetoLlevable.gameObject;
            objetoLlevable.soltar();
            Destroy(objetoLlevable);
            Vector3 p = posar.transform.position;
            p.y += 0.3f;
            o.transform.position = p;
            o.transform.rotation = new Quaternion();
        }
    }
}
