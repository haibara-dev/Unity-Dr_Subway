using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirarAtirar : MonoBehaviour
{
    public GameObject mousePointer;
    public GameObject weapon;
    public GameObject balaPrefab;
    public GameObject inicioBala;
   
    public float balaSpeed = 50.0f;

    private Vector3 target;

    // Variavel pra audio
    private AudioSource gunShot;


    void Start()
    {
        // Deixar o cursor do mouse não visivel
        Cursor.visible = false;

        gunShot = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));

        
        Vector3 difference = target - weapon.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        // Limitar a rotação do braço segurando a arma

        
            if (rotationZ > 20)
            {
                rotationZ = 20;
            }
            if (rotationZ < -20)
            {
                rotationZ = -20;
            }
        
        

        weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        // Atirar objetos
        if (Input.GetMouseButtonDown(0))
        {
            // Som de tiro do player
            gunShot.Play();

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            atirarBala(direction, rotationZ);
        }
        
    }

    // Instanciar e atirar a mascara - Dr Subway
    void atirarBala(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(balaPrefab) as GameObject; // Inicia objeto
        b.transform.position = inicioBala.transform.position; // Local
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); // Direção
        b.GetComponent<Rigidbody2D>().velocity = direction * balaSpeed; // Velocidade

    }


}
