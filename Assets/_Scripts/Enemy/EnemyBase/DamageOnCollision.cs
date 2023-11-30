// DamageOnCollision.cs
using System;
using System.Collections;
using _Scripts.Pool;
using UnityEngine;

namespace _Scripts.Enemy
{
    public class DamageOnCollision: MonoBehaviour
    {
        private LevelGenerator levelGenerator;

        [SerializeField] private VoidEventChannelSO gameOverEvent;
        private void Start()
        {
            levelGenerator = FindObjectOfType<LevelGenerator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Hero"))
            {
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(new Vector2(0f, 1000f));

                // Notify LevelGenerator that this object has been returned to the pool
                if (levelGenerator != null)
                {
                    if (gameObject.tag == "Vulture")
                    {
                        levelGenerator.vultureSpawned = false;
                    }
                    else if (gameObject.tag == "Bettle")
                    {
                        levelGenerator.beetleSpawned = false;
                    }
                }

                // Before returning to pool, check if the ObjectPooler is initialized
                if (ObjectPooler.Instance.IsInitialized)
                {
                    ObjectPooler.Instance.ReturnToPool(gameObject.tag, gameObject);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Hero"))
            {
                other.GetComponent<CharacterController2D>().isAlive = false;
                gameOverEvent.OnEventRaised();
            }
        }

        private IEnumerator EnemyDie()
        {
            yield return new WaitForSeconds(1f);
        }
    }
}