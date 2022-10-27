using System.Collections.Generic;
using System.Threading;
using GetcuReone.ComboPatterns.Facade;

namespace GetcuReone.Cdo.Settings.Facades
{
    internal sealed class LockerFacade : FacadeBase
    {
        private static readonly Dictionary<string, object> _lockers = new Dictionary<string, object>();
        private static readonly List<string> _blockKeys = new List<string>();

        public object GetLocker(string key)
        {
            if (!_lockers.ContainsKey(key))
                _lockers.Add(key, new object());

            return _lockers[key];
        }

        public void Block(string key)
        {
            _blockKeys.Add(key);
        }

        public void Unblock(string key)
        {
            _blockKeys.Remove(key);
        }

        public void WaitUnblock(string key, int step = 100)
        {
            if (!_blockKeys.Contains(key))
                return;

            while (true)
            {
                if (!_blockKeys.Contains(key))
                    return;

                Thread.Sleep(step);
            }
        }

        public void ClearLockers()
        {
            _lockers.Clear();
        }
    }
}
