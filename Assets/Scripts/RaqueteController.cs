using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //Criando o Vector 3
    private Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 6f;
    public float meuLimite = 3.5f;


    //Identificando se eu sou o playert 1
    public bool player1;

    //Váriavel para checar se ele deve ser controlado pela AI
    public bool automatico = false;

    //pegando a posição da bola
    public Transform transformBola;


    void Start()
    {
        //Pegando a posição inicial da raqyete e aplicando a minha posição
        minhaPosicao.x = transform.position.x;
    }


    void Update()
    {
        //Passando meuY para o eixo Y da minhaPosicao
        minhaPosicao.y = meuY;

        //Modificar a posição da raquete
        transform.position = minhaPosicao;

        //Velocidade multiplicada pelo deltatime

        float deltaVelocidade = velocidade * Time.deltaTime;

        //Se o automático for falso
        if (!automatico)
        {
            //Pegando a seta para cima
            //Se eu apertar a setinha para cima ele vai subir a raquete
            //Controlando a raquete como player 1
            if (player1)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //Checar se meuY é menor do que o meu limite


                    //Alterar valor do Y
                    meuY = meuY + deltaVelocidade;

                }
                if (Input.GetKey(KeyCode.S))
                {
                    //Checar se meuY é menor do que o meu limite


                    //Ação para quando a setinha for pressionada
                    meuY = meuY - deltaVelocidade;

                }
            }
            else
            {

                //meu código para colocar ele no automático 
                if (Input.GetKey(KeyCode.Return))
                {
                    automatico = true;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //Checar se meuY é menor do que o meu limite


                    //Alterar valor do Y
                    meuY = meuY + deltaVelocidade;

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {


                    //Ação para quando a setinha for pressionada
                    meuY = meuY - deltaVelocidade;

                }

            }

          
        }
        else
        {

            //Tirando do automático
            //Checando se a setinha para cima ou pra baixo foi pressionada
            if(Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }

            //Se a raquete esta no automático
            //meuY = transformBola.position.y;
            //para acessar funções matemáticas, é usado a classe Mathf
            meuY = Mathf.Lerp(meuY, transformBola.position.y, 0.02f);




        }

        //Impedindo que eu saia por baixo da tela
        if (meuY < -meuLimite)
        {

            meuY = -meuLimite;

        }

        if (meuY > meuLimite)
        {
            meuY = meuLimite;
        }


    }
}
