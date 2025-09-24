using UnityEngine;
using UnityEngine.UIElements;

public class CoinLife : MonoBehaviour
{
    //variaveis para o temporizador, contudo, ele contabiliza o tempo at� come�ar a piscar
    float timer;
    [SerializeField] float timeUntillBlink;

    //variaveis do tempo da moeda piscando
    float timerBlinking;
    [SerializeField] float timeBlink;

    //Fazer moeda Girar
    [SerializeField] GameObject CoinGO;
    [SerializeField] float forcaRotacao;

    [SerializeField] MeshRenderer CoinMR; //Pegar o MeshRender para deixar a moeda invis�vel
    private void Start()
    {
        timer = timeUntillBlink;  //Timer que deixa a moeda normal at� come�ar a piscar

        timerBlinking = timeBlink; //Timer Piscando

        CoinGO = GetComponent<GameObject>(); //Pegar o GameObject
        CoinMR = GetComponent<MeshRenderer>(); //Pegar o MeshRender (n�o d� para colocar direto no inspector)
    }
    private void FixedUpdate()
    {
        timer = timer - Time.deltaTime; //timer normal funcional

        transform.rotation *= Quaternion.Euler(0, forcaRotacao * Time.deltaTime, 0);

        if (timer <= 0) //Se o timer menor igual a 0
        {
            timerBlinking = timerBlinking - Time.deltaTime; //Timer Piscando (igual ao original, mas desativa o MeshRender)

            
            if (Mathf.PingPong(Time.time * 5f, 1f) > 0.5f)
                //Mathf.PingPong alterna entre dois valores, come�ando em 0
                  //O Primeiro, � o quanto vai adicionar em 0. No caso, Time.Time conta os segundos reais desde o play
                    ///Multiplicamos por 5 para incrementar 5 vezes mais r�pido.
                    ///Nesse caso, ele vai de 0 ao m�ximo (1) 5 vezes por segundo - teoricamente era para ser isso
                 //Ent�o, todas as vezes que o valor for maior que 0.5, pisca
                 //No caso, ele � 0 * 5 = 0 , 0.1 * 5 = 0.5 , 0.2 * 5 = 1 ; e a� volta
                        ///Talvez ele desligue mais do que ligue j� que desligado (0,0.5) acontece mais que ligado (1)
            {
                CoinMR.enabled = true;
            }
            else
            {
                CoinMR.enabled = false;
            }
            

            if (timerBlinking <= 0)  //Ap�s piscar, destruir o objeto
            {
                Destroy(this.gameObject);
            }
        }
    }
}
