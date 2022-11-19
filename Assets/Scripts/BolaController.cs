using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{
    //Criando variável para saber quem é o meu rigidbody
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;

    public float velocidae = 5f;

    public float limiteHorizontal = 12f;

    public AudioClip boing;

    public Transform transformCamera;

    public float delay = 2f;

    public bool jogoIniciado = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //iniciando o delay

        //diminuindo o valor do delay
        delay = delay - Time.deltaTime;


        //chegando se o delay chegou em 0 para então iniciar o jogo
        if (delay <= 0 && jogoIniciado == false)
        {
            //alterar o valor da variável de controle
            jogoIniciado = true;

            //iniciando o jogo
            //Passando a velocidade para minah velocidade
            minhaVelocidade.x = velocidae;
            minhaVelocidade.y = velocidae;

            int direcao = Random.Range(0, 4);

            if (direcao == 0)
            {
                minhaVelocidade.x = velocidae;
                minhaVelocidade.y = velocidae;
            }
            else if (direcao == 1)
            {
                minhaVelocidade.x = -velocidae;
                minhaVelocidade.y = -velocidae;
            }
            else if (direcao == 2)
            {
                minhaVelocidade.x = -velocidae;
                minhaVelocidade.y = +velocidae;
            }
            else
            {
                minhaVelocidade.x = +velocidae;
                minhaVelocidade.y = -velocidae;
            }

            //Adicionando uma velocidade para a esquerda
            meuRB.velocity = minhaVelocidade;
        }

        if(transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            //recarregando a cena
            SceneManager.LoadScene(0);
        }
    }

    //criando meu evento de colisão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, transformCamera.position);
    }
}
