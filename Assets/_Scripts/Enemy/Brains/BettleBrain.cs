using UnityEngine;

namespace _Scripts.Enemy.Brains
{
    
    [CreateAssetMenu( menuName = "Brain/Bettle")]
    public class BettleBrain: Brain
    {
        public override void Think(EnemyThinker thinker)
        {
            
            
            var movement = thinker.gameObject.GetComponent<Movement>();
            movement.MoveBeetle();


        }
        
        
        
        
    }
}