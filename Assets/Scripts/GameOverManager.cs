using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);

    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
