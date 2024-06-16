using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_14_06_dict_or_queue
{
    internal class Cafe
    {
        private string _cafeName;
        private Queue<Visitor> _queue;
        private int _maxTables;
        private int _takenTablesAmount;
        private List<Visitor> _visitorsAtTable;

        //private Queue<>

        public Cafe(string name ,int maxTables)
        {
            _cafeName = name;
            _queue = new Queue<Visitor>();
            _maxTables = maxTables;
            _takenTablesAmount = 0;
            _visitorsAtTable = new List<Visitor>();
        }

        public Queue<Visitor> Queue  { get { return _queue; }  set { _queue = value; } }

        public void AddVisitor(Visitor visitor)
        {
            if(_takenTablesAmount<_maxTables)
            { 
                //_queue.Enqueue(visitor); 
                _visitorsAtTable.Add(visitor);
                _takenTablesAmount++;
            }
            else
            {
                _queue.Enqueue(visitor);
            }
        }

        public void RemoveVisitor(Visitor visitor)
        {
            _visitorsAtTable.Remove(visitor);
            _takenTablesAmount--;
            if (_queue.Count > 0 && _takenTablesAmount < _maxTables)
            {
                _visitorsAtTable.Add(_queue.Dequeue());
            }
        }

        public void RemoveVisitor(int index)
        {
            if(index >0 && index < _visitorsAtTable.Count)
            {
                _visitorsAtTable.RemoveAt(index);
                _takenTablesAmount--;
                if (_queue.Count > 0 && _takenTablesAmount < _maxTables)
                {
                    _visitorsAtTable.Add(_queue.Dequeue());
                }
            }
        }

        public void ShowQueue()
        {
           foreach (var el in _queue)
            {
                Console.WriteLine(el);
            }
        }

        public void showTables()
        {
            foreach (var el in _visitorsAtTable)
            {
                Console.WriteLine(el);
            }
        }

    }
}
