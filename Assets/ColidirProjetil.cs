using UnityEngine;

public class ColidirProjetil : MonoBehaviour
{
    public float valorDano;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            CanvasGameMng.PnlStatusPlayer.ConsumirVida(valorDano);
        }
       Destroy(gameObject);
    }
}
