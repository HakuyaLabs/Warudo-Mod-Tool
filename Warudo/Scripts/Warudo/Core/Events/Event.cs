namespace Warudo.Core.Events {
	public abstract class Event {
	}

	public delegate void OnEvent<in T>(T e) where T : Event;
}
