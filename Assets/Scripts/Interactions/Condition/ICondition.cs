namespace Conditions {
	public interface ICondition
	{
		bool Check();
		void OnGUI();
	}
}