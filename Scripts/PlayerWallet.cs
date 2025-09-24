using UnityEngine;
using TMPro;
public class PlayerWallet : MonoBehaviour
{
    [SerializeField] int pontos; //Guarda o número variável de pontos
    [SerializeField] TMP_Text contagemPontos; //Referencia visual dos pontos
    [SerializeField] TMP_Text pontosGanhar; //Mudar texto de acordo com a condição de vitória
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            pontos++;
            Destroy(other.gameObject);
            contagemPontos.SetText(pontos.ToString()); //Método para transformar INT em String
        }
        if(pontos >= 10)
        {
            pontosGanhar.SetText("Ganhou!");
            pontosGanhar.color = Color.green;
            pontosGanhar.fontSize = 28;
        }
    }
}
