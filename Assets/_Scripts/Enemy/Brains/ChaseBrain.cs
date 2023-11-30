using UnityEngine;

namespace _Scripts.Enemy.Brains
{
    [CreateAssetMenu(menuName = "Brain/ChaseBrain")]
    public class ChaseBrain : Brain
    {
        public string targetTag;
        public override void Think(EnemyThinker thinker)
        {
            GameObject target = GameObject.FindGameObjectWithTag(targetTag);

            if (target)
            {
                var movement = thinker.gameObject.GetComponent<Movement>();
                if (movement)
                {
                    movement.MoveTowardsTarget(target.transform.position);
                }
            }
        }
    }
}