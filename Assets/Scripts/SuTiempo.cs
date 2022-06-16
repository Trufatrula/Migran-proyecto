using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SuTiempo : MonoBehaviour
{
    public TextMeshProUGUI tiempoTime;
    // Start is called before the first frame update
    void Start()
    {
        float minutes = Mathf.FloorToInt(GuardarTiempo.tiempo / 60); 
        float seconds = Mathf.FloorToInt(GuardarTiempo.tiempo % 60);
        tiempoTime.text = string.Format("Su tiempo es {0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
