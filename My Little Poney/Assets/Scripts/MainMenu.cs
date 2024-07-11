
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.Space)) 
        {
            SceneManager.LoadScene(1);
        }*/
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitThisApp()
    {
        Application.Quit();
    }
}
