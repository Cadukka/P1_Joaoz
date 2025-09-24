using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    float timer; //Variavel para usar em um timer
    [SerializeField]float valorTimer = 4f; //Definir no Inspector o timer

    [SerializeField] GameObject prefabMoeda; //Colocar prafab para ser instanciado

    float randomX, randomZ; //Variavel para posição randômica
    private void Start()
    {
        timer = valorTimer;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //Quando der o timer, escolher um valor aleatório para X e Z, em um valor entre 5 e -5
            randomX = Random.Range(5,-5);
            randomZ = Random.Range(5, -5);

            SpawnCoin(); //Chamar método

            timer = valorTimer; //Reseta o Timer
        }
    }
    void SpawnCoin()
    {//Método para Instanciar as moedas

        //Novo vetor que atualiza conforme às posições escolhidas, depois instancia a moeda
        Vector3 posicaoAleatoria = 
            new Vector3(transform.position.x + randomX, 
            transform.position.y,
            transform.position.z + randomZ);
        //Devemos colocar a posição + o valor randomico pois:
            ///Somente a posição instancia no local do spawner
            ///Somente o random evocaria de acordo com o 0,0,0 do mundo
            
        Instantiate(prefabMoeda,posicaoAleatoria,Quaternion.identity); 
        //Instancia (moeda, na posicao aleatoria, com a rotação original
    }
}
