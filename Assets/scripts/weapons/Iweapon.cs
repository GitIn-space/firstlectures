using System;

namespace FG
{
    public interface Iweapon
    {
        void Startshooting(Action<int> onhitcallback);
        void Stopshooting();

        public bool isshooting { get; }
    }
}