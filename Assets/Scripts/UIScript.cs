using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    
    [SerializeField] private Button solarSystemBtn;
    [SerializeField] private Button threeBodyBtn;
    
    // Start is called before the first frame update
    private void Awake()
    {
        solarSystemBtn.onClick.AddListener(solarSystemBtnOnClick);
        threeBodyBtn.onClick.AddListener(threeBodyBtnOnClick);
    }

    void solarSystemBtnOnClick()
    {
        SceneManager.LoadScene("Scenes/SolarSystemScene");
    }

    void threeBodyBtnOnClick()
    {
        SceneManager.LoadScene("Scenes/3body");
    }
}
