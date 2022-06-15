using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase1 : MonoBehaviour
{
    [SerializeField]
    private GameObject estanteria;

    [SerializeField]
    private GameObject libro;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.ambientLight = new Color(0.2f, 0.2f, 0.2f, 1f);
        Laberinto laberinto;
        do {
            laberinto = new Laberinto(14, 24);
            laberinto.setPared(6, 0, false);
			laberinto.setPared(7, 0, false);
			laberinto.setPared(8, 0, false);
			laberinto.setPared(6, 23, false);
			laberinto.setPared(7, 23, false);
			laberinto.setPared(8, 23, false);
        } while (!laberinto.hayCamino(7, 0, 7, 23));
        for (int i = 0; i < 14; i++) {
            for (int j = 0; j < 24; j++) {
                if (laberinto.getPared(i, j)) {
                    GameObject ins = Instantiate(estanteria);
                    float a = 0.785f * i - 5.1f;
		            float b = 0.79f * j - 9.1f;
                    ins.transform.position = new Vector3(a*2, -0.2f, b*2);
                }
            }
        }
        for (int i = 0; i < 3; i++) {
            int x = 0, y = 0;
            do {
				x = Random.Range(0, 13);
				y = Random.Range(0, 23);
			} while(!laberinto.getPared(x, y) && (
						laberinto.hayCamino(7, 0, x+1, y) ||
						laberinto.hayCamino(7, 0, x-1, y) ||
						laberinto.hayCamino(7, 0, x, y+1) ||
						laberinto.hayCamino(7, 0, x, y-1)
			));
            Vector3 pos = new Vector3(2 * (0.785f * x - 5.1f), 0.75f, 2 * (0.79f * y - 9.1f));
            GameObject inst = Instantiate(libro);
            inst.transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
