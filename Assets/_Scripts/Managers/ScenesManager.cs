using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Managers
{
    public class ScenesManager: MonoBehaviour
    {
        public static ScenesManager Instance;

        private void Awake()
        {
            Instance = this;
           // DontDestroyOnLoad(this);
        }

        public enum Scene
        {
            MainMenu,
            LoginMenu,
            RegisterMenu,
            HeroMenu,
            GameScene
        }

        public void LoadScene(Scene scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }


        public void LoadMainMenu()
        {
            SceneManager.LoadScene(Scene.MainMenu.ToString());
        }
        public void LoadLoginMenu()
        {

            SceneManager.LoadScene(Scene.LoginMenu.ToString());

        }
        public void LoadRegisterMenu()
        {
            SceneManager.LoadScene(Scene.RegisterMenu.ToString());
        }
        
      
        
        
        public void LoadHeroMenu()
        {
            SceneManager.LoadScene(Scene.HeroMenu.ToString());
        }
        public void LoadGameScene()
        {
            SceneManager.LoadScene(Scene.GameScene.ToString());
            
        }


        public void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}