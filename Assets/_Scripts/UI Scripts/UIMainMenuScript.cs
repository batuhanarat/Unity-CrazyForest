using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI_Scripts
{
    public class UIMainMenuScript : MonoBehaviour
    {
        [SerializeField]  Button _loginButton;
        [SerializeField]  Button _registerButton;
        [SerializeField]  Button _helpButton;
        [SerializeField]  Button _exitButton;

    
        // Start is called before the first frame update
        void Start()
        {
            _loginButton.onClick.AddListener(OpenLoginMenu);
            _registerButton.onClick.AddListener(OpenRegisterMenu);
            _helpButton.onClick.AddListener(OpenGame);
            _exitButton.onClick.AddListener(ExitGame);

        }

        void Test()
        {
            Debug.Log("clicked to the login button");
        }

        public void OpenLoginMenu()
        {
            Debug.Log("OpenLoginMenu() called");

            ScenesManager.Instance.LoadLoginMenu();   
        }
        public void OpenRegisterMenu()
        {
            ScenesManager.Instance.LoadRegisterMenu();   
        }
        public void OpenGame()
        {
            ScenesManager.Instance.LoadGameScene();   
        }

      

        public void ExitGame()
        {
            Application.Quit();
            
        }

    
    

    }
}
