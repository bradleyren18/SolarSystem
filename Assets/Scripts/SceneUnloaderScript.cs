using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneUnloaderScript : MonoBehaviour
{
    
    [SerializeField] private Button btn;

    private void Awake()
    {
        btn.onClick.AddListener(btnOnClick);
    }
    
    void btnOnClick()
    {
        SceneManager.LoadScene("Scenes/StartingScene");
    }
}
