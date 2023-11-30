using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroButtonScript : MonoBehaviour
{
    [SerializeField] private Button buttonComponent;
    [SerializeField] private TMP_Text buttonTextComponent;

    private void Start()
    {
        buttonTextComponent = buttonComponent.GetComponentInChildren<TMP_Text>();
        if (buttonTextComponent == null)
        {
            Debug.LogError("ButtonTextComponent is null!");
        }
    }

    public void ChangeHeroButtonName(string name)
    {
        if (buttonTextComponent != null)
        {
            buttonTextComponent.text = name;
        }
        else
        {
            Debug.LogError("ButtonTextComponent is null in ChangeHeroButtonName!");
        }
        }
}