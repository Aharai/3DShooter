using System;
using UnityEngine;


namespace Geekbrains
{
    public sealed class BodyBot : MonoBehaviour, ICollision
    {
        public event Action<InfoCollision> OnApplyDamageChange;
        public void OnCollision(InfoCollision info)
        {
            OnApplyDamageChange?.Invoke(info);
        }
    }
}
