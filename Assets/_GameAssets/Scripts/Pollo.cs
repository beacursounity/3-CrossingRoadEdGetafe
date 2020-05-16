using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollo : MonoBehaviour
{

    private Rigidbody rb;
    [SerializeField] float distanciaDeteccion = 0.1f;
    [SerializeField] int fuerza = 100; // Y ASI LO PODEMOS VARIAR EN EL EDITOR

    // PARA SABER SI ESTAMOS EN EL SUELO
    [SerializeField] Transform posPies;

    // Use this for initialization
    void Start()
    {
        // LO OBTENEMOS SOLO UNA VEZ
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // CUANDO PULSEMOS ESPACIO HARA UNA FUERZA HACIA ARRIBA HACIA LA Y
        if (Input.GetKeyDown("space") && EstoyEnSuelo())
        {
            rb.AddForce(new Vector3(0, 1, 1) * fuerza);
        }

        // MOVIMIENTO HACIA LA IZQUIERDA
        else if (Input.GetKeyDown("left") && EstoyEnSuelo())
        {
            rb.AddForce(new Vector3(-1, 1, 0) * fuerza);
        }

        // MOVIMIENTO HACIA LA DERECHA
        else if (Input.GetKeyDown("right") && EstoyEnSuelo())
        {
            rb.AddForce(new Vector3(1, 1, 0) * fuerza);
        }

        // MOVIMIENTO HACIA ATRAS
        else if (Input.GetKeyDown("down") && EstoyEnSuelo())
        {
            rb.AddForce(new Vector3(0, 1, -1) * fuerza);
        }
        

    }

    // 
    private bool EstoyEnSuelo()
    {
        // Si mis pies estan tocando
        // PARA SABER SI ESTOY EN EL SUELO PARA QUE NO SALTE MAS
        int layerIndex = LayerMask.GetMask("Terreno");
        print(layerIndex);
        bool enSuelo = false;
        enSuelo = Physics.CheckSphere(
            posPies.position, distanciaDeteccion,
            layerIndex); 

        // TAMBIEN SE PUEDE HACER DE ESTA OTRA MANERA
        // COMPROBAMOS CON EL NOMBRE DEL LAYER DEL TERRENO 
        // todos los collider de objetos que hay en esa capa.
        /*Collider[] cols = Physics.OverlapSphere(
           posPies.position, distanciaDeteccion,
           layerIndex); // nos da un Array de colisionadores
        
        //Debug.Log("NUMERO DE COLLIDERS:" + cols.Length);
        if (cols.Length > 0 ) enSuelo = true;
        */
        return enSuelo;
    }
}