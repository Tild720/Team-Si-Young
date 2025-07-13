using Core.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Works.KWJ._01_Scripts
{   
    public class GameTitle : MonoSingleton<GameTitle>
    {
        public void GameRestart()
        {
            SceneManager.LoadScene("Tild");
        }
        
        public void GameExit()
        {
            Application.Quit();
        }
    }
}