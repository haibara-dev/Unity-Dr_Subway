using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class npc_action : MonoBehaviour
{
    // Variaveis espirro
    double tempo = 0;
    public float melecaSpeed = 20.0f;
    public GameObject melecaPrefab;
    public Transform target;
    int tempoEspirro;
    public Transform inicioMeleca;
    bool atchim = true;

    public float tempoVidaMeleca = 3f;

    // Adicionar mascara NPC
    public Sprite mascarado;

    Collider2D npc;

    public static int numberNpc = 12;

    void Start()
    {
        tempoEspirro = Random.Range(2, 5);
        print(tempoEspirro);
    }

    void Update()
    {
        tempo += Time.deltaTime;
   
        if (tempo > tempoEspirro && atchim == true)
        {
            Atchim();
            tempo = 0;

        }
       

    }

    // Função para tornar o espirro em um projétil
    bool Atchim()
    {
        Vector3 difference = target.position - inicioMeleca.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        float distance = difference.magnitude;
        Vector2 direction = difference / distance;
        direction.Normalize();

        GameObject b = Instantiate(melecaPrefab) as GameObject; // Inicia objeto
        b.transform.position = inicioMeleca.position; // Local
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ); // Direção
        b.GetComponent<Rigidbody2D>().velocity = direction * melecaSpeed; // Velocidade

        return true;

    }

    // Testes de colisões
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mask" && this.tag == "npc")
        {
            // Altera sprite do NPC - Deixar NPC com mascara, assim ele não pode atirar espirros.
            this.GetComponent<SpriteRenderer>().sprite = mascarado;            
            atchim = false;
           
            numberNpc--;
            this.tag = "Mascarado";
            


            Destroy(collision.gameObject);

            if (numberNpc == 0)
            {
                SceneManager.LoadScene("Parabens");
            }
        }

        
    }
}
