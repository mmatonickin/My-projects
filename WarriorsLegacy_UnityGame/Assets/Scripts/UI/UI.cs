using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Header("End Screen")]
    [SerializeField] private UI_FadeScreen fadeScreen;
    [SerializeField] private GameObject endText;
    [SerializeField] private GameObject restartButton;

    [SerializeField] private GameObject characterUI;
    [SerializeField] private GameObject craftUI;
    [SerializeField] private GameObject optionsUI;

    public UI_CraftWindow craftWindow;
    void Start()
    {
        SwitchTo(null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            SwitchWithKeyTo(characterUI);

        if(Input.GetKeyDown(KeyCode.Tab))
            SwitchWithKeyTo(craftUI);

       if(Input.GetKeyDown(KeyCode.Escape))
            SwitchWithKeyTo(optionsUI);
    }
    public void SwitchTo(GameObject _menu)
    {

        for(int i =0; i < transform.childCount; i++)
        {
            bool fadeScreen = transform.GetChild(i).GetComponent<UI_FadeScreen>() != null;
            
            if(!fadeScreen)
            transform.GetChild(i).gameObject.SetActive(false);
        }
        if(_menu != null)
            _menu.SetActive(true);
    }

    public void SwitchWithKeyTo(GameObject _menu)
    {
        if(_menu != null && _menu.activeSelf)
        {
            _menu.SetActive(false);
            return;
        }
        
        SwitchTo(_menu);
    }

    public void SwitchOnEndScreen()
    {
        
        fadeScreen.FadeOut();
        StartCoroutine(EndScreenCorotine());    
    }

    IEnumerator EndScreenCorotine()
    {
        yield return new WaitForSeconds(1);
        endText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        restartButton.SetActive(true);
    }
   
    public void RestartGameButton() => GameManager.instance.RestartScene();

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
