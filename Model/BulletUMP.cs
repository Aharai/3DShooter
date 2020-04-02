using UnityEngine;

namespace Geekbrains
{
    public sealed class BulletUMP : Ammunition
    {
        private void OnTriggerEnter(Collider collision)
        {
            var setDamage = collision.gameObject.GetComponent<ICollision>();

            if (setDamage != null)
            {
                setDamage.CollisionEnter(new InfoCollision(_curDamage, Rigidbody.velocity));

                if (collision.gameObject.CompareTag("Wood"))
                {
                    _curDamage -= _declineDamage;
                }

                if (collision.gameObject.CompareTag("Rock"))
                {
                    DestroyAmmunition();
                }
            }
        }
    }
}
