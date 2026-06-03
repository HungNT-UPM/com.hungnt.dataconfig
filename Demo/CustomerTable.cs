using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HungNT.DataConfig.Demo
{
    [ContentAsset]
    [CreateAssetMenu(fileName = "CustomerTable", menuName = "Game/DataConfig/CustomerTable")]
    public class CustomerTable : BaseDataConfigTable
    {
        [ArrayContent("CustomerTable")]
        [TableList(ShowIndexLabels = true)]
        public CustomerData[] Customers = { };
    }

    [Serializable]
    public struct CustomerData
    {
        [ColumnName("name")]
        public string Name;

        [ColumnName("avatar")]
        public string AvatarSprite;
    }
}
