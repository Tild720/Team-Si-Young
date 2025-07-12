using Core.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Works.KWJ._01_Scripts
{   
    public class GameTitle : MonoSingleton<GameTitle>
    {
        public void GameRestart()
        {
            SceneManager.LoadScene("KWJ");
        }
        
        public void GameExit()
        {
            Application.Quit();
        }
    }
}