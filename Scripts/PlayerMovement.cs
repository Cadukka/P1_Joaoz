using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody playerRB;  //Movimentar por Rigidbody

    //Layers
    [SerializeField] LayerMask groundLayer; //Identificar chão
    [SerializeField] LayerMask blocosLayer; //Identificar objetos quebráveis

    float moveX, moveZ; //Variáveis para identificar movimentos em X e Z (frente e lados)
    float jumpForce = 10f; //Variável de força do pulo (movimento em Y, cima ou baixo)
    float speed = 5f; //Variável para definir a força da velocidade

    void Update()
    {
        //Inputs movimentação básica
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            if(Physics.Raycast(transform.position, Vector3.down, 2f, groundLayer)) //Projeta colisor invisível (pra baixo,no caso)
            {
                //movimentação para cima (conhecida como pulo) e baixo (gravidade faz automaticamente)
                playerRB.linearVelocity = new Vector3
                    (playerRB.linearVelocity.x, jumpForce, playerRB.linearVelocity.z);
            }
        }
    }
    private void FixedUpdate()
    {
        //Movimentação para os lados
        playerRB.linearVelocity = new Vector3
            (moveX, playerRB.linearVelocity.y, moveZ);
    }
}
