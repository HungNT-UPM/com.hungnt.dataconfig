# HungNT Database (`com.hungnt.database`)

Service truy vấn dữ liệu game từ **ScriptableObject tables** (`BaseDataTable`), tích hợp **Service Locator**, import **Google Sheet** trong Editor (GGSheet).

## Tính năng

- **`IDatabaseService` / `DatabaseService`** — lấy table theo kiểu, `TryGetTable<T>()`
- **`BaseDataTable`** — SO chứa danh sách row, query helper (filter, find by id, …)
- **GGSheet (Editor)** — attribute cột/dòng, import CSV từ Google Sheet vào table
- **`DatabaseConfigWindow`** — menu editor cấu hình import

## Demo

Assembly **`HungNT.Database.Demo`** — `Demo/DatabaseDemo.cs`, `ItemTable`, `CustomerTable`:

1. Tạo asset `ItemTable` tại `Assets/Resources/Database/ItemTable.asset` (hoặc path bạn cấu hình trong `DatabaseService`).
2. Scene có `DatabaseService` + `ServiceRegister` đã register `IDatabaseService`.
3. Gắn `DatabaseDemo` → Play Mode → nút Odin *Show All Items*, *Filter: Free Items*, *Find By Id*, …

```csharp
private void Start()
{
    var db = this.GetService<IDatabaseService>();
    if (db.TryGetTable<ItemTable>(out var table))
    {
        var all = table.GetAll();
        table.TryGetById("item_001", out var item);
    }
}
```

## Google Sheet import (Editor)

1. Khai báo class table kế thừa `BaseDataTable` với attribute GGSheet.
2. Mở cửa sổ import GGSheet (menu HungNT / Database tùy cấu hình project).
3. Import → ghi đè hoặc merge data vào ScriptableObject.
