using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{    
    // Variaveis pra movimentação Player
    public float velocidade = 4;
    Vector3 mousePosition;

    // Variaveis da vida do jogador
    public Text textVida;
    private int life = 3;

    // Variaveis escudo
    public GameObject escudo;
    private bool ativarEscudo;

    void Start()
    {
        ativarEscudo = false;
        escudo.SetActive(false);
       
    }

    void Update()
     {        
         // Movimentação Jogador com o mouse
         if (Input.GetMouseButton(1))
         {
             mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
             mousePosition.y = transform.position.y;
             mousePosition.z = 0;
             var playerPosition = Vector3.MoveTowards(transform.position, mousePosition, velocidade * Time.deltaTime);
            
            // Aplicar limites na fase / Parede invisível
            if (playerPosition.x < -47)
            {
                playerPosition.x = -47;
            }

            if (playerPosition.x > 310)
            {
                playerPosition.x = 310;
            }

            transform.position = playerPosition;

            // Animação do player andando
           
            if (mousePosition.x > transform.position.x || mousePosition.x < transform.position.x)
            {
                GetComponent<Animator>().SetBool("Walking", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("Walking", false);
            }
          

        }

        // Gerando Escudo 
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!ativarEscudo)
            {
                escudo.SetActive(true);
                ativarEscudo = true;
            }

            else
            {
                escudo.SetActive(false);
                ativarEscudo = false;
            }
        }

     }
  
    // Contagem de vida
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meleca" && life > 0)
        {
            GetComponent<AudioSource>().Play();
            life--;
            textVida.text = life.ToString();

            Destroy(collision.gameObject);

            if (life == 0)
            {
                SceneManager.LoadScene("GameOver");
                npc_action.numberNpc = 12;
            }
        }
    }

    
}
