using Zenject;
public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<DataManager>().To<DataManager>().AsSingle().NonLazy();
    }
}
