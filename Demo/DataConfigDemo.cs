using HungNT;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HungNT.DataConfig.Demo
{
    /// <summary>
    /// Demo IDataConfigService với ItemTable.
    /// <para>Điều kiện:</para>
    /// <list type="bullet">
    ///   <item>Tạo ScriptableObject ItemTable tại <c>Assets/Resources/DataConfig/ItemTable.asset</c></item>
    ///   <item>Có GameObject trong scene với DataConfigService + ServiceRegister đã register IDataConfigService</item>
    /// </list>
    /// </summary>
    public class DataConfigDemo : MonoBehaviour
    {
        [ShowInInspector, ReadOnly, TableList]
        private IReadOnlyList<ItemData> _displayedItems;

        private IDataConfigService _db;

        private void Start()
        {
            _db = ServiceLocator.Instance.Get<IDataConfigService>();
            ShowAll();
        }

        // ── Buttons ───────────────────────────────────────────────────────────

        [Button("Show All Items"), FoldoutGroup("Query")]
        private void ShowAll()
        {
            if (!_db.TryGetTable<ItemTable>(out var table)) return;
            _displayedItems = table.GetAll();
        }

        [Button("Filter: Free Items"), FoldoutGroup("Query")]
        private void ShowFree()
        {
            if (!_db.TryGetTable<ItemTable>(out var table)) return;
            _displayedItems = table.GetByUnlockType(UnlockType.Free);
        }

        [Button("Filter: Coin Items"), FoldoutGroup("Query")]
        private void ShowCoin()
        {
            if (!_db.TryGetTable<ItemTable>(out var table)) return;
            _displayedItems = table.GetByUnlockType(UnlockType.Coin);
        }

        [Button("Filter: Ads Items"), FoldoutGroup("Query")]
        private void ShowAds()
        {
            if (!_db.TryGetTable<ItemTable>(out var table)) return;
            _displayedItems = table.GetByUnlockType(UnlockType.Ads);
        }

        [Button("Filter: Category Ao"), FoldoutGroup("Query")]
        private void ShowAo()
        {
            if (!_db.TryGetTable<ItemTable>(out var table)) return;
            _displayedItems = table.GetByCategory(ItemCategory.Armor);
        }

        [SerializeField, FoldoutGroup("Query")] private string _findId = "item_001";

        [Button("Find By Id"), FoldoutGroup("Query")]
        private void FindById()
        {
            if (!_db.TryGetTable<ItemTable>(out var table)) return;
            if (table.TryGetById(_findId, out var item))
            {
                Debug.Log($"[Demo] Found: {item.Name} | {item.Category} | {item.UnlockType}");
            }
        }
    }
}