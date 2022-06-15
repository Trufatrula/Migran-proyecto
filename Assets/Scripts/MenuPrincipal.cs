using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public string migran;

    public GameObject puntuaciones;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciarJuego() 
    {
        SceneManager.LoadScene(migran);
    } 

    public void AbrirPunto()
    {
        puntuaciones.SetActive(true);
    }

    public void CerrarPunto()
    {
        puntuaciones.SetActive(false);
    }

    public void CerrarTodo()
    {
        Application.Quit();
        Debug.Log("Cerras");
    }


}
