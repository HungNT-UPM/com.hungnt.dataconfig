namespace HungNT.DataConfig
{
    /// <summary>
    /// Service quản lý và cung cấp truy cập vào các <see cref="BaseDataConfigTable"/>.
    /// Table được load từ <c>Resources/DataConfigs/</c> ngay khi service được tạo.
    /// </summary>
    public interface IDataConfigService
    {
        /// <summary>Lấy table theo type. Throw nếu không tìm thấy.</summary>
        T GetTable<T>() where T : BaseDataConfigTable;

        /// <summary>Thử lấy table. Trả về false nếu chưa load.</summary>
        bool TryGetTable<T>(out T table) where T : BaseDataConfigTable;

        /// <summary>Kiểm tra table đã được load chưa.</summary>
        bool HasTable<T>() where T : BaseDataConfigTable;

        /// <summary>Load lại toàn bộ table từ Resources (công cụ Editor / hot-reload data).</summary>
        void Reload();
    }
}
