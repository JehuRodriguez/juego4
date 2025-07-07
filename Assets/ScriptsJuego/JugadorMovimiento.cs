using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMovimiento : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 7f;
    private Rigidbody rb;
    private bool enSuelo = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(horizontal, 0, vertical) * velocidad;
        rb.velocity = new Vector3(movimiento.x, rb.velocity.y, movimiento.z);

        if (Input.GetKey(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            enSuelo = false;
        }

        Debug.Log("Velocidad: " + rb.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground") || collision.contacts[0].normal.y > 0.5f)
        {
            enSuelo = true;
        }
    }
}
