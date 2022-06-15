using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VasoMover : InteractConObjeto
{
    [SerializeField]
    private int position;
    [SerializeField]
    private int id;
    [SerializeField]
    private GameObject cono;
    [SerializeField]
    private Fase3 fase3;

    private int[] moves = null;
    private double tiempoAnimacion = 0;
	private bool arriba = false;
	private bool haInteractuado = false;
	private double tiempoArriba = 0;

    private static Vector3[] posiciones;
	private static Vector3[] posicionesArriba;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        ((InteractConObjeto)this).Update();
        if (posiciones == null) return;
        Vector3 pos = transform.position;
        float posY = pos.y;
        float posIrY = 0;
        if (arriba) {
            posIrY = posicionesArriba[position].y;
        } else {
            posIrY = posiciones[position].y;
        }
        float dir = posIrY - posY;
        if (arriba && dir < 0) dir = 0;
		if (!arriba && dir > 0) dir = 0;
        if (dir != 0) {
			dir /= Mathf.Abs(dir);
			dir *= Time.deltaTime * 4;
			pos.y += dir;
		}
        if (moves != null) {
            int paso = (int) tiempoAnimacion - 1;
            float porcentaje = (float) (tiempoAnimacion % 1f);
            tiempoAnimacion += Time.deltaTime;
            if (paso >= 0) {
                if (paso >= moves.Length - 1) {
                    position = moves[moves.Length - 1];
                    moves = null;
                } else {
                    Vector3 posAntes = posiciones[moves[paso]];
                    Vector3 posDespues = posiciones[moves[paso + 1]];
                    float x = (posDespues.x - posAntes.x) * porcentaje;
                    float z = 3 * Mathf.Sin(porcentaje * Mathf.PI);
                    if (x < 0) {
                        z *= -1;
                    } else if (x == 0) {
                        z = 0;
                    }
                    z += posAntes.z;
                    x += posAntes.x;
                    pos.x = x;
                    pos.z = z;
                    if (cono != null) {
                        Vector3 conoPos = cono.transform.position;
                        conoPos.x = x;
                        conoPos.z = z;
                        cono.transform.position = conoPos;
                    }
                }
            }
        }
        if (arriba) {
            tiempoArriba -= Time.deltaTime;
            if (tiempoArriba <= 0) {
                arriba = false;
                if (cono != null) {
                    if (haInteractuado) {
                        fase3.completado();
                        cono.GetComponent<TpFinal>().activar();
                    } else {
                        fase3.moverVasos();
                    }
                }
            }
        }
        transform.position = pos;
    }

    public int getPosition() {
        return position;
    }

    public void setArriba(bool a) {
        arriba = a;
    }

    public void setTiempoArriba(double t) {
        tiempoArriba = t;
    }

    override public void interact() {
        if (arriba || moves != null) return;
        this.haInteractuado = true;
        fase3.subirVasos();
        if (cono != null) {
            fase3.setTiemposCortos();
        }
    }

    public void animar(int[] m) {
        moves = m;
        tiempoAnimacion = 0;
    }

    public static void setPosiciones(Vector3[] p) {
        posiciones = p;
        if (posicionesArriba == null) {
            posicionesArriba = new Vector3[3];
        }
        for (int i = 0; i < 3; i++) {
            Vector3 v = new Vector3(p[i].x, p[i].y, p[i].z);
            v.y += 2;
            posicionesArriba[i] = v;
        }
    }
}
