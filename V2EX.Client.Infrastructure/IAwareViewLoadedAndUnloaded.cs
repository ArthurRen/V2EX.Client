namespace V2EX.Client.Infrastructure
{
    public interface IAwareViewLoadedAndUnloaded
    {
        void OnViewLoaded(object view);
        void OnViewUnloaded(object view);
    }
}