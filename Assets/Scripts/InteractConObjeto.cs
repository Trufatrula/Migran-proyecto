using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractConObjeto : Interact
{
    [SerializeField]
    private KeyCode interactKey = KeyCode.F;
    private bool pulsadoAntes = false;
    private bool enRango = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new public void Update() {
        base.Update();
        if (enRango) {
            if (Input.GetKeyDown(interactKey)) {
                if (!this.pulsadoAntes) {
                    interact();
                }
                pulsadoAntes = true;
            } else {
                pulsadoAntes = false;
            }
        }
    }

    override public void entrarInteract() {
        enRango = true;
        pulsadoAntes = false;
    }

    override public void salirInteract() {
        enRango = false;
        pulsadoAntes = false;
    }

    public bool isPulsadoAntes() {
        return pulsadoAntes;
    }

    public KeyCode getInteractKey() {
        return interactKey;
    }

    public abstract void interact();
}
