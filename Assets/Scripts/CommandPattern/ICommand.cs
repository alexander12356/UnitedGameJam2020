namespace CommandPattern
{
	public enum CommandType
	{
		None,
		Move
	}
	
	public interface ICommand
	{
		CommandType CommandType { get; }
		void Execute(IActor actor);
		void Undo(IActor actor);
	}
}
