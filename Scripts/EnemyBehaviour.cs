using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    //Variaveis para identificar o Player e suas propriedades;
    [SerializeField] LayerMask playerlayer;
    [SerializeField] GameObject player;
    [SerializeField] Transform localPlayer;
    
    //Variaveis para mexer com o Inimigo (dono do código)
    [SerializeField] Rigidbody enemyRB;
    [SerializeField] float speed;

    //Moeda para ser instanciada na morte do inimigo (não funcionou mas acontece)
    [SerializeField] GameObject coin;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Acha o GameObject do Player (deve ter uma maneira melhor)
    }
    private void FixedUpdate()
    {
        //Calcula a direção do inimigo e do player. Normalized faz o movimento diagonal ser corrigido
        Vector3 direction = (localPlayer.position - transform.position).normalized;

        //Faz o movimento em direção ao Player
        enemyRB.linearVelocity = 
            new Vector3(direction.x * speed, enemyRB.linearVelocity.y, direction.z * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
            if (Physics.CheckBox(new Vector3(transform.position.x, transform.position.y+ 1f, transform.position.z),
                new Vector3(0, 2f, 1f),
                Quaternion.identity,
                playerlayer))
            //CheckBox(posicao que cria, tamanho da caixa, rotação da caixa, layer que interage)

            {
                Instantiate(coin); //Evoca moeda (atualmente evoca no local original do inimigo)
                Destroy(this.gameObject);
            }
            else if (collision.gameObject.layer == playerlayer)
            {
                Destroy(collision.gameObject);
                //Se a colisão foi feita de outra maneira sem ser por cima, destrói o player (nao funciona?)
            }
    }
}
