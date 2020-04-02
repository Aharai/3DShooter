using System;
using UnityEngine;
using static UnityEngine.Random;

namespace Geekbrains
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        [SerializeField] private float _speed = 11.0f;
        [SerializeField] private float _batteryChargeMax;
        [SerializeField] private float _intensity = 1.5f;
        private Light _light;
        private Transform _goFollow;
        private Vector3 _vecOffset;
        private float _share;
        private float _takeAwayTheIntensity;

        public float Charge => BatteryChargeCurrent / _batteryChargeMax;
        public float BatteryChargeCurrent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
            _light.intensity = _intensity;
            _share = _batteryChargeMax / 4.0f;
            _takeAwayTheIntensity = _intensity / (_batteryChargeMax * 100.0f);
        }

        public void Switch(FlashLightActiveType value)
        {
            switch (value)
            {
                case FlashLightActiveType.On:
                    _light.enabled = true;
                    transform.position = _goFollow.position + _vecOffset;
                    transform.rotation = _goFollow.rotation;
                    break;
                case FlashLightActiveType.None:
                    break;
                case FlashLightActiveType.Off:
                    _light.enabled = false;
                    BatteryRecharge();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void Rotation()
        {
            transform.position = _goFollow.position + _vecOffset;
            transform.rotation = Quaternion.Lerp(transform.rotation,
                _goFollow.rotation, _speed * Time.deltaTime);
        }
        
        public bool EditBatteryCharge()
        {
            if (BatteryChargeCurrent > 0)
            {
                BatteryChargeCurrent -= Time.deltaTime;

                if (BatteryChargeCurrent < _share)
                {
                    _light.enabled = Range(0, 100) >= Range(0, 10);
                }
                else
                {
                    _light.intensity -= _takeAwayTheIntensity;
                }
                return true;
            }

            return false;
        }

        public bool LowBattery()
        {
            return BatteryChargeCurrent <= _batteryChargeMax / 2.0f;
        }

        public bool BatteryRecharge()
        {
            if (BatteryChargeCurrent < _batteryChargeMax)
            {
                BatteryChargeCurrent = _batteryChargeMax;
                return true;
            }
            return false;
        }
    }
}
