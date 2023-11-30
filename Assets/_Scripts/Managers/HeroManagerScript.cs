using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject _heroPrefab;
    [SerializeField] private int MAX_HERO_LIMIT = 5;


    private readonly string[] _lockMessages = new string[]
    {
        "Unlocked Level 10",
        "Unlocked Level 20",
        "Unlocked Level 50",
        "Unlocked Level 100"
    };
    
    public void CreateMenu(int ownedHeroCount, Transform parentContainer)
    {
        if (_heroPrefab == null)
        {
            Debug.LogError("_heroPrefab is null! Please assign the Hero prefab in the Inspector.");
            return;
        }

       
            if (ownedHeroCount == 0)
            {
                SpawnCreateHeroButton(parentContainer);
                Debug.Log("before for");

                for (int i = 0; i < MAX_HERO_LIMIT - 1; i++) // Start from 0 to match array index
                {
                    Debug.Log("inside for");

                    SpawnLockedButton(i, parentContainer);
                }
                Debug.Log("after for");

            }

        
    }




    private void SpawnCreateHeroButton(Transform parentContainer)
    {
        Debug.Log("Spawning Create Hero Button");
        GameObject heroButton = Instantiate(_heroPrefab, parentContainer);
        HeroButtonScript heroButtonScript = heroButton.GetComponent<HeroButtonScript>();
        heroButtonScript.ChangeHeroButtonName("Create Hero");
        heroButton.SetActive(true);
        Debug.Log("Spawning Create Hero Button finished");

    }

    private void SpawnLockedButton(int index, Transform parentContainer)
    {
        Debug.Log("Spawning Locked Button " + index);
        string message = _lockMessages[index];

        GameObject heroButton = Instantiate(_heroPrefab, parentContainer);
        HeroButtonScript heroButtonScript = heroButton.GetComponent<HeroButtonScript>();
        heroButtonScript.ChangeHeroButtonName(message);
        heroButton.SetActive(true);
    }

}