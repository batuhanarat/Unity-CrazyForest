using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public bool JumpPressed { get; private set; }
    public bool JumpHeld { get; private set; }
    public bool DashPressed { get; private set; }
    public float Horizontal { get; private set; }

    void Update()
    {
        JumpPressed = Input.GetButtonDown("Jump");
        JumpHeld = Input.GetButton("Jump");
        DashPressed = Input.GetButtonDown("Dash");
        Horizontal = Input.GetAxis("Horizontal");
    }
}