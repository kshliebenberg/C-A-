using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace AStar
{
    class OpenSet : IDictionary<Point,Spot>
    {

        protected IDictionary<Point,Spot> _InternalDict;

        private Color _Color;

        public OpenSet(Color Color)
        {

            _Color = Color;

            _InternalDict = new Dictionary<Point, Spot>();

        }

        public Spot this[Point key]
        {
            get
            {
                return _InternalDict[key];
            }

            set
            {
                _InternalDict[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return _InternalDict.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _InternalDict.IsReadOnly;
            }
        }

        public ICollection<Point> Keys
        {
            get
            {
                return _InternalDict.Keys;
            }
        }

        public ICollection<Spot> Values
        {
            get
            {
                return _InternalDict.Values;
            }
        }

        public void Add(KeyValuePair<Point, Spot> item)
        {
            item.Value.Color = _Color;

            _InternalDict.Add(item);
        }

        public void Add(Point key, Spot value)
        {
            value.Color = _Color;

            _InternalDict.Add(key, value);
        }

        public void Clear()
        {
            _InternalDict.Clear();
        }

        public bool Contains(KeyValuePair<Point, Spot> item)
        {
            return _InternalDict.Contains(item);
        }

        public bool ContainsKey(Point key)
        {
            return _InternalDict.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<Point, Spot>[] array, int arrayIndex)
        {
            _InternalDict.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<Point, Spot>> GetEnumerator()
        {
            return _InternalDict.GetEnumerator();
        }

        public bool Remove(KeyValuePair<Point, Spot> item)
        {

           // item.Value.Color = Color.White;

            return _InternalDict.Remove(item);

        }

        public bool Remove(Point key)
        {

           // _InternalDict[key].Color = Color.White;

            return _InternalDict.Remove(key);
        }

        public bool TryGetValue(Point key, out Spot value)
        {
            return _InternalDict.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _InternalDict.GetEnumerator();
        }
    }
}
