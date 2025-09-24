using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer; //Verificar se a colisão vem do Player

    Rigidbody otherRB; //Usado para impulsionar o player

    private void OnCollisionEnter(Collision collision)
    { //Método que verifica Colisão no momento em que ocorre

        //Função que verifica se a colisão foi feita na posição escolhida,
        //no caso, uma caixa "imaginária" é calculada na parte de cima e baixo, permitindo a colisão
        if (Physics.CheckBox(transform.position,new Vector3(0.5f,2,0.5f),Quaternion.identity,playerLayer))
        {
            GameObject other = collision.gameObject; //Define o "outro" como agente da ação

            otherRB = other.GetComponent<Rigidbody>(); //Pega o RigidBody do "outro"
            otherRB.linearVelocity = new Vector3(0, otherRB.linearVelocity.y + 10, 0); //Impulsiona "outro"

            Destroy(this.gameObject); //Destrói a caixa
        }
    }
}
