using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laberinto 
{
    private int alto;
    private int ancho;
    private bool[] laberinto;

    public Laberinto(int ancho, int alto) {
		this.alto = alto;
		this.ancho = ancho;
		laberinto = new bool[alto*ancho];
		generarLaberinto(0, 0, ancho - 1, alto - 1);
	}

    private void generarLaberinto(int xInicio, int yInicio, int xFinal, int yFinal) {
        if(xFinal - xInicio <= 1 || yFinal - yInicio <= 1) {
			return;
		}

        int xCentro = Random.Range(xInicio + 1, xFinal);
        int yCentro = Random.Range(yInicio + 1, yFinal);

        int xAgujero1 = Random.Range(xInicio, xCentro);
        int xAgujero2 = Random.Range(xCentro + 1, xFinal + 1);

        int yAgujero1 = Random.Range(yInicio, yCentro);
        int yAgujero2 = Random.Range(yCentro + 1, yFinal + 1);
		
		for (int i = xInicio; i <= xFinal; i++) {
			setPared(i, yCentro, true);
		}
		
		for (int i = yInicio; i <= yFinal; i++) {
			setPared(xCentro, i, true);
		}
		
		setPared(xAgujero1, yCentro, false);
		setPared(xAgujero2, yCentro, false);
		setPared(xCentro, yAgujero1, false);
		setPared(xCentro, yAgujero2, false);
		
		generarLaberinto(xInicio, yInicio, xCentro - 1, yCentro - 1);
		generarLaberinto(xCentro + 1, yInicio, xFinal, yCentro - 1);
		generarLaberinto(xInicio, yCentro + 1, xCentro - 1, yFinal);
		generarLaberinto(xCentro + 1, yCentro + 1, xFinal, yFinal);
    }

    public int getAlto() {
		return alto;
	}

	public int getAncho() {
		return ancho;
	}
    
    public void setPared(int x, int y, bool pared) {
		laberinto[ancho*y+x] = pared;
	}
	
	public bool getPared(int x, int y) {
		return laberinto[ancho*y+x];
	}

    public bool hayCamino(int inicioX, int inicioY, int finX, int finY) {
        bool[][] b = new bool[alto][];
        for (int i = 0; i < alto; i++) {
            b[i] = new bool[ancho];
        }
		return hayCamino(inicioX, inicioY, finX, finY, b);
	}

    private bool hayCamino(int inicioX, int inicioY, int finX, int finY, bool[][] explorado) {
		if (inicioX == finX && inicioY == finY) return true;
		if (getPared(inicioX, inicioY) || explorado[inicioY][inicioX]) return false;
		explorado[inicioY][inicioX] = true;
		if (inicioX != 0) {
			if (this.hayCamino(inicioX - 1, inicioY, finX, finY, explorado)) {
				return true;
			}
		}
		if (inicioX != ancho - 1) {
			if (this.hayCamino(inicioX + 1, inicioY, finX, finY, explorado)) {
				return true;
			}
		}
		if (inicioY != 0) {
			if (this.hayCamino(inicioX, inicioY - 1, finX, finY, explorado)) {
				return true;
			}
		}
		if (inicioY != alto - 1) {
			if (this.hayCamino(inicioX, inicioY + 1, finX, finY, explorado)) {
				return true;
			}
		}
		return false;
	}


}
