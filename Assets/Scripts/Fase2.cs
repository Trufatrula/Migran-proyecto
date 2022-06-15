using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase2 : MonoBehaviour
{
    

    private MeshRenderer[] bolas = new MeshRenderer[9];
    private bool[] correcto = new bool[9];
    private bool[] actual = new bool[9];

    private bool hecho = false;

    [SerializeField]
    private GameObject elevador;
    [SerializeField]
    private Material apagado;
    [SerializeField]
    private Material encendido;

    // Start is called before the first frame update
    public void iniciarFase2()
    {
        RenderSettings.ambientLight = Color.black;
        elevador = GameObject.Find("Elevador");
        elevador.AddComponent(typeof(ElevadorSubeYBaja));
        RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f, 1f);
        for (int i = 0; i < 9; i++) {
            bolas[i] = GameObject.Find("Bola" + i).GetComponent<MeshRenderer>();
            correcto[i] = Random.Range(0, 2) == 1;
            if (correcto[i]) {
                GameObject.Find("Cubo" + i).GetComponent<MeshRenderer>().material = encendido;
            }
            actual[i] = false;
        }
    }

    public void setBola(int i, bool estado) {
        if (hecho) return;
        actual[i] = estado;
        if (estado) {
            bolas[i].material = encendido;
        } else {
            bolas[i].material = apagado;
        }
        if (check()) {
            Debug.Log("Fase 2 brrr");
        }
    }

    public void toggleBola(int i) {
        setBola(i, !actual[i]);
    }

    private bool check() {
        for (int i = 0; i < 9; i++) {
            if (correcto[i] != actual[i]) return false;
        }
        return true;
    }
}
