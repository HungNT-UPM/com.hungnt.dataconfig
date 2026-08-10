# com.hungnt.dataconfig

Bảng dữ liệu cấu hình dạng ScriptableObject, kèm công cụ import từ Google Sheet.

## Yêu cầu

`com.hungnt.core` 2.0.0 và **VContainer** (cài thủ công qua Git URL — xem README của core).

## Cài đặt vào container

```csharp
builder.InstallDataConfig();
```

Service load toàn bộ table từ `Resources/DataConfigs/` ngay khi được tạo, nên nơi nào inject được `IDataConfigService` thì nơi đó chắc chắn có registry đã sẵn sàng.

## Khai báo table

```csharp
[ContentAsset]
[CreateAssetMenu(menuName = "Game/DataConfig/ItemTable")]
public class ItemTable : BaseDataConfigTable
{
    [ArrayContent("ItemTable")]
    public ItemData[] Items = Array.Empty<ItemData>();
}
```

Đặt asset vào `Resources/DataConfigs/`.

## Sử dụng

```csharp
public class Shop : MonoBehaviour
{
    [Inject] private IDataConfigService _dataConfig;

    private void Start()
    {
        if (_dataConfig.TryGetTable<ItemTable>(out var table))
        {
            // ...
        }
    }
}
```

`GetTable<T>()` ném exception nếu chưa load, `TryGetTable<T>()` trả về false. `Reload()` nạp lại từ Resources khi cần hot-reload data lúc phát triển.

## Import từ Google Sheet

Menu **`HungNT/Sheet DataConfig`**. Cần attribute `GGSheet` trên model và một `DataConfigSettings` ScriptableObject cấu hình sheet nguồn.
