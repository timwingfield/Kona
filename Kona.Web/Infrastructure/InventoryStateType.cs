using System;
using System.Data;
using Kona.Model.Supply.Inventory;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace Kona.Infrastructure {
    public enum InventoryStatus {
        InStock = 1,
        BackOrder = 2,
        PreOrder = 3,
        SpecialOrder = 4,
        Discontinued = 5,
        CurrentlyUnavailable = 6
    }
    
    public class InventoryStateType:IUserType {


        public object Assemble(object cached, object owner) {
            return InventoryState.Create((InventoryStatus)cached);
        }
        public object Disassemble(object value) {
            return ((InventoryState)value).Status;
        }
        public object DeepCopy(object value) {
            return InventoryState.Create(((InventoryState)value).Status);
        }

        public int GetHashCode(object x) {
            return ((InventoryState)x).Status.GetHashCode();
        }

        public bool IsMutable {
            get { return false; }
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner) {
            return InventoryState.Create((InventoryStatus)rs[names[0]]);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index) {
            ((IDataParameter)cmd.Parameters[index]).Value = ((InventoryState)value).Status;
        }

        public object Replace(object original, object target, object owner) {
            return DeepCopy(original);
        }

        public Type ReturnedType {
            get { return typeof(InventoryState); }
        }

        public SqlType[] SqlTypes {
            get { return new[] { new SqlType(DbType.Int32) }; }
        }
        public bool Equals(object x, object y) {
            return ((InventoryState)x).Status.Equals(((InventoryState)y).Status);
        }
    }
}
