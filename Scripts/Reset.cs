using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    [SerializeField] Button buttonReset;
    public void loadScene() 
    {
        SceneManager.LoadScene("P1");
    }
    
}
