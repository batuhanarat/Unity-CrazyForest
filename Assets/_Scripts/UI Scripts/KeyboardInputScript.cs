using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.UI_Scripts
{
    public class KeyboardInputScript : MonoBehaviour
    {
        private EventSystem _system;
        [SerializeField] private Selectable usernameInputField;

        // Start is called before the first frame update
        void Start()
        {
            _system = EventSystem.current;
            usernameInputField.Select();

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
            {
                Selectable previous = _system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
                if (previous != null)
                {
                    previous.Select();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Tab) )
            {
                Selectable next = _system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
                if (next != null)
                {
                    next.Select();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Button pressed!");

                // loginButton.onClick.Invoke();
            }
        }


   
    }
}
