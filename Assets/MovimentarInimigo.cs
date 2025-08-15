using UnityEngine;
using UnityEngine.AI;

public class MovimentarInimigo : MonoBehaviour
{
    private NavMeshAgent agent; //IA do Inimigo
    public float velocidade; //velocidade da movimenta��o
    public float distanciaMinimaDoPlayer; //Definir a distancia min�ma que o inimigo ter� do player
    public bool estaVendoPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referenciar a IA do inimigo
        agent = GetComponent<NavMeshAgent>();

        //Definir a velocidade de movimenta��o do inimigo
        agent.speed = velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        PerseguirPlayer();
    }

    private void PerseguirPlayer()
    {
        //Definir a distancia entre o inimigo e o player
        float distancia = Vector3.Distance(
            transform.position,
            PlayerMng.Instance.transform.position
        );

        //Verificar se a distancia chegou no limite
        if (distancia < distanciaMinimaDoPlayer) { 
            //Fazer com que o inimigo fique parado onde ele est�
            agent.destination = transform.position;

            OlharParaPlayer();
        }
        else
        {
            //Fazer o inimigo ir at� o player
            agent.destination = PlayerMng.Instance.transform.position;

            estaVendoPlayer = false;
        }        
    }

    private void OlharParaPlayer()
    {
        //Definir para onde o inimigo deve olhar
        Vector3 posicaoJogador = new Vector3(
            PlayerMng.Instance.transform.position.x,
            transform.position.y,
            PlayerMng.Instance.transform.position.z
        );

        //Fazer o inimigo olhar para o jogador
        transform.LookAt(posicaoJogador);

        //Definir que o inimigo est� vendo o player 
        estaVendoPlayer = true;
    }
}
