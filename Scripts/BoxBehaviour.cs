using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer; //Verificar se a colis�o vem do Player

    Rigidbody otherRB; //Usado para impulsionar o player

    private void OnCollisionEnter(Collision collision)
    { //M�todo que verifica Colis�o no momento em que ocorre

        //Fun��o que verifica se a colis�o foi feita na posi��o escolhida,
        //no caso, uma caixa "imagin�ria" � calculada na parte de cima e baixo, permitindo a colis�o
        if (Physics.CheckBox(transform.position,new Vector3(0.5f,2,0.5f),Quaternion.identity,playerLayer))
        {
            GameObject other = collision.gameObject; //Define o "outro" como agente da a��o

            otherRB = other.GetComponent<Rigidbody>(); //Pega o RigidBody do "outro"
            otherRB.linearVelocity = new Vector3(0, otherRB.linearVelocity.y + 10, 0); //Impulsiona "outro"

            Destroy(this.gameObject); //Destr�i a caixa
        }
    }
}
