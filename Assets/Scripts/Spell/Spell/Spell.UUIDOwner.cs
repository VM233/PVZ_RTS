using System;
using FishNet.Connection;
using VMFramework.Network;

namespace TH.Spells
{
    public partial class Spell
    {
        string IUUIDOwner.uuid
        {
            get => uuid;
            set => uuid = value;
        }

        bool IUUIDOwner.isDirty
        {
            get => true;
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