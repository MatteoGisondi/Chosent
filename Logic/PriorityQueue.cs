using System.Runtime;
using System.Collections.Generic;

namespace Chosent.Logic
{
    class PriorityQueue
    {
        private readonly List<Node> _nodes = new List<Node>();

        public void Enqueue(Node item)
        {
            _nodes.Add(item);
            var childIndex = _nodes.Count - 1;
            while (childIndex > 0)
            {
                var parentIndex = (childIndex - 1) / 2;
                if (_nodes[childIndex].CompareTo(_nodes[parentIndex]) >= 0 ) break;
                var temp = _nodes[childIndex];
                _nodes[childIndex] = _nodes[parentIndex];
                _nodes[parentIndex] = temp;
                childIndex = parentIndex;
            }
        }

        public Node Dequeue()
        {
            var lastIndex = _nodes.Count - 1;
            var frontItem = _nodes[0];
            _nodes[0] = _nodes[lastIndex];
            _nodes.RemoveAt(lastIndex);

            --lastIndex;
            var parentIndex = 0;
            while (true)
            {
                var leftChildIndex = parentIndex * 2 + 1;
                if (leftChildIndex > lastIndex) break;
                var rightChildIndex = leftChildIndex + 1;
                if (rightChildIndex <= lastIndex && (_nodes[rightChildIndex].CompareTo(_nodes[leftChildIndex]) < 0 ))
                    leftChildIndex = rightChildIndex;
                if (_nodes[parentIndex].CompareTo(_nodes[leftChildIndex]) <= 0 ) break;
                var temp = _nodes[parentIndex];
                _nodes[parentIndex] = _nodes[leftChildIndex];
                _nodes[leftChildIndex] = temp;
                parentIndex = leftChildIndex;
            }

            return frontItem;
        }

        public Node Peek()
        {
            return _nodes[0];
        }

        public int Count => _nodes.Count;

        public bool IsEmpty => _nodes.Count == 0;
    }
}