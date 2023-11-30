using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using _Scripts;
using _Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginManagerScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    private readonly string baseUrl = "http://localhost:5100";

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async Task<string> LoginUser(AuthenticationRequest request)
    {
        var url = $"{baseUrl}/authentication/login";

        try
        {
            var response = await ApiClient.Post<AuthenticationResponse>(url, request);
            return response?.Token;
        }
        catch (System.Exception e)
        {
            Debug.Log($"Error login user: {e.Message}");
            return null;
        }
    }
    public async void  HandleLogin()
    {
        var username = usernameField.text;
        var password = passwordField.text;

        var authenticationRequest = new AuthenticationRequest
        {
            Username = username,
            Password = password
        };
        var token = await LoginUser(authenticationRequest);

        if (!string.IsNullOrEmpty(token))
        {
            Debug.Log("User logged in successfully. Token: " + token);
            // Store the authentication token for subsequent requests
            // You can use this token in the Authorization header of future requests to the server
            
            ScenesManager.Instance.LoadHeroMenu();
        }
        else
        {
            Debug.Log("Failed to log in user.");
        }
        
    }
    
    
}
