using VContainer;

namespace HungNT.DataConfig
{
    /// <summary>Đăng ký <see cref="IDataConfigService"/>. Gọi ở scope gốc — data config dùng chung toàn game.</summary>
    public static class DataConfigInstaller
    {
        public static IContainerBuilder InstallDataConfig(this IContainerBuilder builder)
        {
            builder.Register<DataConfigService>(Lifetime.Singleton).As<IDataConfigService>();
            return builder;
        }
    }
}
