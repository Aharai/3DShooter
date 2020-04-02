namespace Geekbrains
{
	public sealed class Wall : BaseObjectScene, ISelectObj
	{
		public string GetMessage()
		{
			return Name;
		}
	}
}