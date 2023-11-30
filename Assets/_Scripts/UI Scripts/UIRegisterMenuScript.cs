using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class UIRegisterMenuScript : MonoBehaviour
    {
        private RegisterManagerScript _registerManagerScript;
        [SerializeField]  Button _backButton;
        [SerializeField]  Button _registerButton;

        // Start is called before the first frame update
        void Start()
        {
            _registerManagerScript = GameObject.FindGameObjectWithTag("RegisterManager").GetComponent<RegisterManagerScript>();
            _registerButton.onClick.AddListener(RegisterUser);
            _backButton.onClick.AddListener(OpenMainMenu);

        }
        public void OpenMainMenu()
        {
            ScenesManager.Instance.LoadMainMenu();
        }

        public  void RegisterUser()
        {
        
            _registerManagerScript.HandleRegister();
        }

    }
}