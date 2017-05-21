namespace Log.Horst.Model
{
    public enum ApplicationLifeCycleEvent
    {
        Other = 0,
        Created,
        Started,
        Resumed,
        Suspended,
        Closed,
        Crashed,
        LowMemory,
        Obscured
    }
}