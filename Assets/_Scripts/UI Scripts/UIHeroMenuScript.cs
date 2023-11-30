using System.Collections;
using System.Collections.Generic;
using _Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIHeroMenuScript : MonoBehaviour
{
    
    [SerializeField]  Button _logoutButton;

    // Start is called before the first frame update
    void Start()
    {
        _logoutButton.onClick.AddListener(LogOut);

    }

    // Update is called once per frame
    void LogOut()
    {
        ScenesManager.Instance.LoadMainMenu();
    }
}
