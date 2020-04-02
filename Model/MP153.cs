using UnityEngine;

namespace Geekbrains
{
    public sealed class MP153 : Weapon
    {
        public override void Fire()
        {
            if (!_isReady) return;
            if (Clip.CountAmmunition <= 0) return;


            for (int i = 0; i < _pelletCount; i++)
            {
                pellets[i] = Random.rotation;
                var temAmmunition = Instantiate(_pellet, _barrel.position, _barrel.rotation);
                temAmmunition.transform.rotation = Quaternion.RotateTowards(temAmmunition.transform.rotation, pellets[i], _spreadAngle);
                temAmmunition.GetComponent<Rigidbody>().AddForce(temAmmunition.transform.right * _force);
            }

            _isReady = false;
            _timeRemaining.AddTimeRemaining();
        }
    }
}
