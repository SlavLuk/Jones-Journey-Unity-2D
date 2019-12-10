using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{



   public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

        if (sceneName.Equals("Game") && FindObjectOfType<GameSession>()!=null)
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
    }


    
}
