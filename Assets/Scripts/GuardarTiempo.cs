using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuardarTiempo : MonoBehaviour
{
    public static int tiempo = -1;

    public static void Guardar(int t)
    {
        if(t == -1){
            SceneManager.LoadScene(1);
        } else {
            tiempo = 600 - (int) t;
            SceneManager.LoadScene(1);
        }
    }
}
