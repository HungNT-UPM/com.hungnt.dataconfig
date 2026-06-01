using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HungNT.Database.Demo
{
    [ContentAsset]
    [CreateAssetMenu(fileName = "CustomerTable", menuName = "Game/Database/CustomerTable")]
    public class CustomerTable : BaseDataTable
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
