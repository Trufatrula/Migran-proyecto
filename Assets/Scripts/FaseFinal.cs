using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaseFinal : MonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float minPos;
    [SerializeField]
    private float maxPos;
    [SerializeField]
    private Timer timer;

    private bool activado = false;

    public void iniciarFaseFinal() {
        activado = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (activado) {
            Vector3 p = transform.position;
            if (p.y < maxPos && p.y > minPos) {
                float fov = playerCamera.fieldOfView;
                if (fov >= 179) {
                    GuardarTiempo.Guardar((int) timer.timeRemaining);
                } else {
                    fov += 45 * Time.deltaTime;
                    playerCamera.fieldOfView = fov;
                }
            }
        }
    }
}
