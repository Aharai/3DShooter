using UnityEngine;

namespace Geekbrains
{
    public sealed class BulletUMP : Ammunition
    {
        private void OnCollisionEnter(Collision collision)
        {
            var tempObj = collision.gameObject.GetComponent<ICollision>();

            if (tempObj != null)
            {
                tempObj.OnCollision(new InfoCollision(_curDamage, collision.contacts[0], collision.transform,
                    Rigidbody.velocity));

                if (collision.gameObject.CompareTag("Wood"))
                {
                    _curDamage -= _declineDamage;
                    DestroyAmmunition();
                }

                if (collision.gameObject.CompareTag("Rock"))
                {
                    DestroyAmmunition();
                }

                else
                {
                    DestroyAmmunition();
                }
            }


        }
    }
}
