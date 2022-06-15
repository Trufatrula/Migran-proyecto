using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3 : MonoBehaviour
{   
    private bool hacerVasosCheck = false;

    [SerializeField]
    private GameObject puerta;
    [SerializeField]
    private VasoMover vaso0;
    [SerializeField]
    private VasoMover vaso1;
    [SerializeField]
    private VasoMover vaso2;


    public void iniciarFase3() {
        hacerVasosCheck = true;
        puerta.AddComponent(typeof(PuertaSoloSube));
        RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f);
    }

    void Update() {
        if (hacerVasosCheck) {
            Vector3 v = transform.position;
            if (v.y > 7 && v.z < -7) {
                hacerVasosCheck = false;
                Vector3[] posiciones = new Vector3[3];
                posiciones[0] = vaso0.gameObject.transform.position;
                posiciones[1] = vaso1.gameObject.transform.position;
                posiciones[2] = vaso2.gameObject.transform.position;
                VasoMover.setPosiciones(posiciones);
                subirVasos();
            }
        }
    }

    public void moverVasos() {
        int countMoves = Random.Range(5, 16);
        int[][] movesVasos = new int[3][];
        for (int i = 0; i < 3; i++) {
            movesVasos[i] = new int[countMoves];
        }
        movesVasos[0][0] = vaso0.getPosition();
        movesVasos[1][0] = vaso1.getPosition();
        movesVasos[2][0] = vaso2.getPosition();
        for (int i = 1; i < countMoves; i++) {
            int c1 = Random.Range(0, 3);
            int c2;
            do {
                c2 = Random.Range(0, 3);
            } while (c1 == c2);
            movesVasos[0][i] = movesVasos[0][i - 1];
			movesVasos[1][i] = movesVasos[1][i - 1];
			movesVasos[2][i] = movesVasos[2][i - 1];
            int tmp = movesVasos[c2][i];
			movesVasos[c2][i] = movesVasos[c1][i];
			movesVasos[c1][i] = tmp;
        }
        vaso0.animar(movesVasos[0]);
        vaso1.animar(movesVasos[1]);
        vaso2.animar(movesVasos[2]);
    }

    public void subirVasos() {
        vaso0.setArriba(true);
        vaso0.setTiempoArriba(3.5);
        vaso1.setArriba(true);
        vaso1.setTiempoArriba(3.5);
        vaso2.setArriba(true);
        vaso2.setTiempoArriba(3.5);
    }

    public void completado() {
            Destroy(vaso0);
            Destroy(vaso1);
            Destroy(vaso2);
    }

    public void setTiemposCortos() {
        vaso0.setTiempoArriba(1);
        vaso1.setTiempoArriba(1);
        vaso2.setTiempoArriba(1);
    }
}
