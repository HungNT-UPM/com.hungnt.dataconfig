using Sirenix.OdinInspector;
using UnityEngine;

namespace HungNT.DataConfig
{
    /// <summary>
    /// Abstract ScriptableObject base cho data config table.
    /// </summary>
    [InlineEditor]
    public class BaseDataConfigTable : ScriptableObject, IDataConfigTable
    {
        public virtual string TableName => GetType().Name;

        public virtual void Initialize()
        {
        }
    }
}