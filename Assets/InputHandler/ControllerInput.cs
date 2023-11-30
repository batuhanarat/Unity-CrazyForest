using UnityEngine;

namespace DefaultNamespace.InputHandler
{
    public class ControllerInput: IResponsive
    {
        public void ReadInput()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
    }
}