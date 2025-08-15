using UnityEngine;

public class VisaoPlayer : MonoBehaviour
{
    private RaycastHit hitAlvo; //Vari�vel para armazenar os dados do alvo "visto"
    private GameObject alvo;// Objeto do alvo visto
    public float distancia;//Distancia at� ver algo
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastCamera();
    }

    private void RaycastCamera()
    {
        //Criar um raio que vai partir da camera do player
        Ray raio = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

        //Criar uma variavel que vai armazenar os dados do objeto "visto" temporariamente
        RaycastHit hit;

        //Emitir o raio e verificar se "viu" algum objeto
        if(Physics.Raycast(raio,out hit, distancia))
        {
            //Desenhar o raio que est� sendo emitido
            Debug.DrawRay(
                transform.position,
                transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.red
            );

            //Armazenar o alvo visto na vari�vel global
            hitAlvo = hit;

            //Armazenar os dados do objeto visto
            alvo = hit.transform.gameObject;

            //Escrever o nome do objeto visto
            Debug.Log($"Estou vendo: {hit.transform.gameObject.name}");
        }
        else
        {
            //Remover o alvo do objeto
            alvo = null;

            Debug.Log("N�o estou vendo nada!");
        }
    }

    public GameObject AlvoVisto()
    {
        return alvo;
    }
}
