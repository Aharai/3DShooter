using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public abstract class Weapon : BaseObjectScene
    {
        private int _maxCountAmmunition = 40;
        private int _minCountAmmunition = 20;
        private int _countClip = 5;

        public int _pelletCount = 100;
        public float _spreadAngle = 20;

        public Ammunition Ammunition;
        public Clip Clip;

        public AmmunitionType[] AmmunitionTypes;

        [SerializeField] protected Transform _barrel;
        [SerializeField] protected GameObject _pellet;
        [SerializeField] protected float _force = 999;
        [SerializeField] protected float _rechergeTime = 0.2f;

        [HideInInspector] protected List<Quaternion> pellets;

        private Queue<Clip> _clips = new Queue<Clip>();

        protected bool _isReady = true;
        protected ITimeRemaining _timeRemaining;

        public int CountClip => _clips.Count;

        private void Start()
        {
            _timeRemaining = new TimeRemaining(ReadyShoot, _rechergeTime);
            for (var i = 0; i <= _countClip; i++)
            {
                AddClip(new Clip { CountAmmunition = Random.Range(_minCountAmmunition, _maxCountAmmunition) });
            }

            ReloadClip();

            pellets = new List<Quaternion>(_pelletCount);
            for (int i = 0; i < _pelletCount; i++)
            {
                pellets.Add(Quaternion.Euler(Vector3.zero));
            }
        }

        public abstract void Fire();

        protected void ReadyShoot()
        {
            _isReady = true;
        }
        protected void AddClip(Clip clip)
        {
            _clips.Enqueue(clip);
        }

        public void ReloadClip()
        {
            if (CountClip <= 0) return;
            Clip = _clips.Dequeue();
        }
    }
}