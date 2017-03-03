using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace AStar
{
    class ClosedSet : IDictionary<Point,Spot>
    {

        protected IDictionary<Point, Spot> _InternalDIct;

        private Color _Color; 

        public ClosedSet(Color Color)
        {

            _Color = Color;

            _InternalDIct = new Dictionary<Point, Spot>();

        }

        public Spot this[Point key]
        {
            get
            {
                return _InternalDIct[key];
            }

            set
            {
                _InternalDIct[key] = value;
            }
        }

        public int Count
        {
            get
            {
                return _InternalDIct.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return _InternalDIct.IsReadOnly;
            }
        }

        public ICollection<Point> Keys
        {
            get
            {
                return _InternalDIct.Keys;
            }
        }

        public ICollection<Spot> Values
        {
            get
            {
                return _InternalDIct.Values;
            }
        }

        public void Add(KeyValuePair<Point, Spot> item)
        {

            item.Value.Color = _Color;

            _InternalDIct.Add(item);

        }

        public void Add(Point key, Spot value)
        {
            
            value.Color = _Color;

            _InternalDIct.Add(key, value);

        }

        public void Clear()
        {
            _InternalDIct.Clear();
        }

        public bool Contains(KeyValuePair<Point, Spot> item)
        {
            return _InternalDIct.Contains(item);
        }

        public bool ContainsKey(Point key)
        {
            return _InternalDIct.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<Point, Spot>[] array, int arrayIndex)
        {
            _InternalDIct.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<Point, Spot>> GetEnumerator()
        {
            return _InternalDIct.GetEnumerator();
        }

        public bool Remove(KeyValuePair<Point, Spot> item)
        {
            return _InternalDIct.Remove(item);
        }

        public bool Remove(Point key)
        {
            return _InternalDIct.Remove(key);
        }

        public bool TryGetValue(Point key, out Spot value)
        {
            return _InternalDIct.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _InternalDIct.GetEnumerator();
        }
    }


}

