using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody playerRB;  //Movimentar por Rigidbody

    //Layers
    [SerializeField] LayerMask groundLayer; //Identificar ch�o
    [SerializeField] LayerMask blocosLayer; //Identificar objetos quebr�veis

    float moveX, moveZ; //Vari�veis para identificar movimentos em X e Z (frente e lados)
    float jumpForce = 10f; //Vari�vel de for�a do pulo (movimento em Y, cima ou baixo)
    float speed = 5f; //Vari�vel para definir a for�a da velocidade

    void Update()
    {
        //Inputs movimenta��o b�sica
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            if(Physics.Raycast(transform.position, Vector3.down, 2f, groundLayer)) //Projeta colisor invis�vel (pra baixo,no caso)
            {
                //movimenta��o para cima (conhecida como pulo) e baixo (gravidade faz automaticamente)
                playerRB.linearVelocity = new Vector3
                    (playerRB.linearVelocity.x, jumpForce, playerRB.linearVelocity.z);
            }
        }
    }
    private void FixedUpdate()
    {
        //Movimenta��o para os lados
        playerRB.linearVelocity = new Vector3
            (moveX, playerRB.linearVelocity.y, moveZ);
    }
}
