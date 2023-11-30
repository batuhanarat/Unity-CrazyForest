using UnityEngine;

namespace _Scripts.UI_Scripts
{
    public class HeroSelectionContainerScript : MonoBehaviour
    {
       
         private HeroManagerScript _heroManagerScript;
        [SerializeField] private Transform _heroContainer; // Reference to the container for hero buttons

        // Start is called before the first frame update
        void Awake()
        {
            int ownedHeroCount = 0;
            _heroManagerScript = GameObject.FindGameObjectWithTag("HeroManager3").GetComponent<HeroManagerScript>();
            _heroManagerScript.CreateMenu(ownedHeroCount, _heroContainer); // Pass the hero container as a parameter

        }

        
    }
}