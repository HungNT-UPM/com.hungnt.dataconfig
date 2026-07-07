using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using HungNT;

namespace HungNT.DataConfig
{
    /// <summary>
    /// Implementation của <see cref="IDataConfigService"/>.
    /// Load tất cả <see cref="BaseDataConfigTable"/> ScriptableObject từ <c>Resources/Database/</c>
    /// rồi Initialize và đăng ký vào registry.
    /// </summary>
    public class DataConfigService : MonoBehaviour, IDataConfigService
    {
        private const string ResourcesPath = "DataConfigs";

        [ShowInInspector]
        private Dictionary<Type, BaseDataConfigTable> _registry = new();

        // ── IService ─────────────────────────────────────────────────────────

        public void Initialize()
        {
            LoadAllFromResources();
        }

        public void LateInitialize()
        {
        }

        // ── IDataConfigService ─────────────────────────────────────────────────

        public T GetTable<T>() where T : BaseDataConfigTable
        {
            var type = typeof(T);
            if (_registry.TryGetValue(type, out var table))
                return (T)table;

            throw new InvalidOperationException(
                $"[DataConfigService] Table '{type.Name}' not found. " +
                $"Make sure a ScriptableObject of this type is placed under Resources/{ResourcesPath}/");
        }

        public bool TryGetTable<T>(out T table) where T : BaseDataConfigTable
        {
            if (_registry.TryGetValue(typeof(T), out var raw))
            {
                table = (T)raw;
                return true;
            }
            table = null;
            return false;
        }

        public bool HasTable<T>() where T : BaseDataConfigTable =>
            _registry.ContainsKey(typeof(T));

        // ── Internal ─────────────────────────────────────────────────────────

        private void LoadAllFromResources()
        {
            var assets = Resources.LoadAll<BaseDataConfigTable>(ResourcesPath);

            if (assets == null || assets.Length == 0)
            {
                this.Log($"No BaseDataConfigTable assets found at Resources/{ResourcesPath}/");
                return;
            }

            foreach (var asset in assets)
            {
                var type = asset.GetType();
                if (_registry.ContainsKey(type))
                {
                    this.LogWarning($"Duplicate table type '{type.Name}' — skipping second asset '{asset.name.Color("red")}'.");
                    continue;
                }

                asset.Initialize();
                _registry[type] = asset;
                this.Log($"Loaded table: {type.Name.Color("cyan")} (name: {asset.name})");
            }

            this.Log($"DataConfig ready. {_registry.Count} table(s) loaded.".Color("lime"));
        }

#if UNITY_EDITOR
        [Button("Reload (Editor Only)"), PropertyOrder(-1)]
        private void ReloadInEditor()
        {
            _registry.Clear();
            LoadAllFromResources();
        }
#endif
    }
}