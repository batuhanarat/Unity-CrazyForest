using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace _Scripts
{
    public class RegisterManagerScript : MonoBehaviour
    {
        [SerializeField] private TMP_InputField usernameField;
        [SerializeField] private TMP_InputField passwordField;

        private readonly string baseUrl = "http://localhost:5100"; // Replace with your server URL

        private async Task<string> RegisterUser(AuthenticationRequest request)
        {
            var url = $"{baseUrl}/authentication/register";

            try
            {
                var response = await ApiClient.Post<AuthenticationResponse>(url, request);
                return response?.Token;
            }
            catch (System.Exception e)
            {
                Debug.Log($"Error registering user: {e.Message}");
                return null;
            }
        }

        public async Task HandleRegister()
        {
            var username = usernameField.text;
            var password = passwordField.text;

            var authenticationRequest = new AuthenticationRequest
            {
                Username = username,
                Password = password
            };

            var token = await RegisterUser(authenticationRequest);

            if (!string.IsNullOrEmpty(token))
            {
                Debug.Log("User created successfully. Token: " + token);
            
                
                // Store the authentication token for subsequent requests
                // You can use this token in the Authorization header of future requests to the server
            }
            else
            {
                Debug.Log("Failed to create user.");
            }
        }
    }
}