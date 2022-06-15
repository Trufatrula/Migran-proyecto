using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : InteractConObjeto
{

    [SerializeField]
    private Fase2 fase2;
    [SerializeField]
    private int bola;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        ((InteractConObjeto)this).Update();
    }

    override public void interact() {
        fase2.toggleBola(bola);
    }
}
