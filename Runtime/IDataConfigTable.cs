namespace HungNT.DataConfig
{
    /// <summary>
    /// Interface cho một data config table (ScriptableObject chứa config data).
    /// </summary>
    public interface IDataConfigTable
    {
        /// <summary>Tên table (dùng cho debug / log).</summary>
        string TableName { get; }

        /// <summary>Gọi sau khi load — khởi tạo lookup, validate data, v.v.</summary>
        void Initialize();
    }
}