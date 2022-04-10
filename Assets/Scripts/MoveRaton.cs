using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRaton : MonoBehaviour {
    public float Sensibilidad = 1;
    public Transform Jugador;

    private float x = 0;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * this.Sensibilidad;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * this.Sensibilidad;

        this.Jugador.Rotate(Vector3.up * mouseX);

        this.x -= mouseY;
        this.x = Mathf.Clamp(this.x, -90, 90);
        transform.localRotation = Quaternion.Euler(this.x, 0, 0);
    }
}
