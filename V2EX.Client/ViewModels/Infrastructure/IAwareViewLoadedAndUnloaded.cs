namespace V2EX.Client.ViewModels.Infrastructure
{
    public interface IAwareViewLoadedAndUnloaded
    {
        void OnViewLoaded(object view);
        void OnViewUnloaded(object view);
    }
}