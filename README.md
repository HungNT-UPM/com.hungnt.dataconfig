# com.hungnt.dataconfig

Service truy vấn dữ liệu game tĩnh từ **ScriptableObject tables** (`BaseDataConfigTable`), tích hợp **Service Locator**, import **Google Sheet** trong Editor (GGSheet).

## Tính năng

- **`IDataConfigService` / `DataConfigService`** — lấy table theo kiểu, `TryGetTable<T>()`
- **`BaseDataConfigTable`** — SO chứa danh sách row, query helper (filter, find by id, …)
- **GGSheet (Editor)** — attribute cột/dòng, import CSV từ Google Sheet vào table
- **`DataConfigSettingsWindow`** — menu editor **HungNT > Sheet DataConfig** để cấu hình import

## Setup

1. Đặt `DataConfigService` + `ServiceRegister` trên một GameObject trong scene.
2. Tạo `BaseDataConfigTable` ScriptableObjects tại `Assets/Resources/DataConfig/`.
3. Kết nối trong Inspector qua `ServiceRegister`.

## Demo

Assembly **`HungNT.DataConfig.Demo`** — `Demo/DataConfigDemo.cs`, `ItemTable`, `CustomerTable`:

```csharp
var svc = ServiceLocator.Instance.Get<IDataConfigService>();
if (svc.TryGetTable<ItemTable>(out var table))
{
    var all = table.GetAll();
    table.TryGetById("item_001", out var item);
}
```

## Google Sheet import (Editor)

1. Khai báo class table kế thừa `BaseDataConfigTable` với GGSheet attributes.
2. Mở **HungNT > Sheet DataConfig** trong menu.
3. Assign `DataConfigSettings` asset → Import All Tables.
