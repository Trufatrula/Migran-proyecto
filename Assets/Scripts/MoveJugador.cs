using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJugador : MonoBehaviour {
    public CharacterController Jugador;
    public float Velocidad = 1f;
    public float Gravedad = -9.81f;
    public Transform DetectarSuelo;
    public float DistanciaSuelo = 0.1f;
    public LayerMask Suelo;
    public float SaltoAltura = 3;

    private Vector3 v;
    private bool inGround;

    // Start is called before the first frame update
    void Start()  {
        
    }

    // Update is called once per frame
    void Update() {
        this.inGround = Physics.CheckSphere(this.DetectarSuelo.position, this.DistanciaSuelo, this.Suelo);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        this.v.y += this.Gravedad * Time.deltaTime;

        if (this.inGround) {
            if (this.v.y <= 0) this.v.y = -2;
            if (Input.GetButtonDown("Jump")) {
                this.v.y = Mathf.Sqrt(this.SaltoAltura * -2 * this.Gravedad);
            } 
        }

        Vector3 disp = transform.forward * z + transform.right * x;
        disp *= this.Velocidad;
        disp += this.v;

        this.Jugador.Move(disp * Time.deltaTime);

    }
}
