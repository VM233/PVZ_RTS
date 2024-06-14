using System;
using FishNet.Connection;
using VMFramework.Network;

namespace PVZRTS.Entities
{
    public partial class Entity
    {
        public string uuid { get; private set; }

        string IUUIDOwner.uuid
        {
            get => uuid;
            set => uuid = value;
        }

        bool IUUIDOwner.isDirty
        {
            get => false;
            set { }
        }

        public event Action<IUUIDOwner, bool, NetworkConnection> OnObservedEvent;
        public event Action<IUUIDOwner, NetworkConnection> OnUnobservedEvent;

        void IUUIDOwner.OnObserved(bool isDirty, NetworkConnection connection)
        {
            OnObservedEvent?.Invoke(this, isDirty, connection);
        }

        void IUUIDOwner.OnUnobserved(NetworkConnection connection)
        {
            OnUnobservedEvent?.Invoke(this, connection);
        }
    }
}