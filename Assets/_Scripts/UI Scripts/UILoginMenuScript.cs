using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI_Scripts
{
    public class UILoginMenuScript : MonoBehaviour
    {
        private  LoginManagerScript _loginManagerScript;
        [SerializeField]  Button _backButton;
        [SerializeField]  Button _loginButton;

        // Start is called before the first frame update
        void Start()
        {
            _loginManagerScript = GameObject.FindGameObjectWithTag("LoginManager").GetComponent<LoginManagerScript>();
            _loginButton.onClick.AddListener(LoginUser);
            _backButton.onClick.AddListener(OpenMainMenu);
        }

   

        public void OpenMainMenu()
        {
            ScenesManager.Instance.LoadMainMenu();
        }

        public void LoginUser()
        {
        
            _loginManagerScript.HandleLogin();
        }

    }
}