using HungNT;

namespace HungNT.DataConfig
{
    /// <summary>
    /// Service quản lý và cung cấp truy cập vào các <see cref="IDataConfigTable"/>.
    /// </summary>
    public interface IDataConfigService : IService
    {
        /// <summary>Lấy table theo type. Throw nếu không tìm thấy.</summary>
        T GetTable<T>() where T : BaseDataConfigTable;

        /// <summary>Thử lấy table. Trả về false nếu chưa load.</summary>
        bool TryGetTable<T>(out T table) where T : BaseDataConfigTable;

        /// <summary>Kiểm tra table đã được load chưa.</summary>
        bool HasTable<T>() where T : BaseDataConfigTable;
    }
}
