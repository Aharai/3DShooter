namespace Geekbrains
{
	public sealed class UMP : Weapon
	{
		public override void Fire()
		{
			if (!_isReady) return;
			if (Clip.CountAmmunition <= 0) return;
			var temAmmunition = Instantiate(Ammunition, _barrel.position, _barrel.rotation);
			temAmmunition.AddForce(_barrel.forward * _force);
			Clip.CountAmmunition--;
			_isReady = false;
			_timeRemaining.AddTimeRemaining();
		}
	}
}