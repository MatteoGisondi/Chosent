using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Chosent.Logic
{
	class AStar
	{
		private readonly int[,] _map;

		private int[,] _heuristicCost;

		private int[,] _movementCost;

		private readonly PriorityQueue _openList;
		// ReSharper disable once CollectionNeverQueried.Local
		private readonly HashSet<Node> _openSet;

		private readonly HashSet<(int, int)> _closedList;

		private readonly Stack<Node> _nodePool;

		public AStar(int[,] map)
		{
			_map = map;
			_openList = new PriorityQueue();
			_openSet = new HashSet<Node>();
			_closedList = new HashSet<(int, int)>();
			_nodePool = new Stack<Node>();
			_heuristicCost = new int[map.GetLength(0), map.GetLength(1)];
			_movementCost = new int[map.GetLength(0), map.GetLength(1)];
		}

		public List<Node> FindPath((int Y, int X) start, (int Y, int X) end)
		{
			PrecomputeCost(end);
			var startNode = GetNodeFromPool(start.X, start.Y);
			var endNode = GetNodeFromPool(end.X, end.Y);
			if (startNode == null) throw new Exception("IndexOutofRange");
			startNode.G = 0;
			startNode.H = _heuristicCost[startNode.X, startNode.Y];
			startNode.F = startNode.G + startNode.H;

			_openList.Enqueue(startNode);
			_openSet.Add(startNode);

			while (_openList.Count > 0)
			{
				// Get the node with the lowest F score
				var currentNode = _openList.Dequeue() ?? throw new Exception("InvalidOperation");
				Debug.WriteLine($"Current node: {currentNode}");

				if (IsEndNode(currentNode, endNode))
				{
					var path = GeneratePath(startNode, currentNode);
					Debug.WriteLine("Path found");
					return path;
				}

				if (IsBlocked(currentNode))
				{
					Debug.WriteLine("Current node is blocked");
					return null;
				}

				if (_closedList.Contains((currentNode.X, currentNode.Y)))
				{
					Debug.WriteLine("Current node is already in the closed list");
					continue;
				}

				_closedList.Add((currentNode.X, currentNode.Y));
				var neighbors = GenerateNeighbors(currentNode);

				foreach (var neighbor in neighbors)
				{
					if (IsVisited(neighbor)) continue;
					var gScore = currentNode.G + _movementCost[neighbor.X, neighbor.Y];
					neighbor.G = gScore;
					neighbor.H = _heuristicCost[neighbor.X, neighbor.Y];
					neighbor.F = neighbor.G + neighbor.H;
					neighbor.Parent = currentNode;
					_openList.Enqueue(neighbor);
					_openSet.Add(neighbor);
				}
			}

			Debug.WriteLine("No path found");
			return null;
		}

		private static bool IsEndNode(Node currentNode, Node endNode)
		{
			return currentNode.X == endNode.X && currentNode.Y == endNode.Y;
		}

		private bool IsBlocked(Node currentNode)
		{
			return _map[currentNode.X, currentNode.Y] == 1;
		}

		private List<Node> GenerateNeighbors(Node currentNode)
		{
			var neighbors = new List<Node>();
			for (var i = -1; i <= 1; i++)
			{
				for (var j = -1; j <= 1; j++)
				{
					if (i == 0 && j == 0) continue; // current
					if (i + j == 0 || i + j == 2 || i + j == -2) continue; // diagonal
					if (!IsValidCoordinate(currentNode.X + i, currentNode.Y + j)) continue; // illegal
					var neighbor = GetNodeFromPool(currentNode.X + i, currentNode.Y + j);
					if (IsVisited(neighbor)) continue; // visited
					neighbors.Add(neighbor);
				}
			}

			return neighbors;
		}

		private bool IsVisited(Node neighbor)
		{
			return _closedList.Contains((neighbor.X, neighbor.Y));
		}

		private bool IsValidCoordinate(int x, int y)
		{
			// Check if the coordinate is outside the map bounds
			if (x < 0 || x >= _map.GetLength(0) || y < 0 || y >= _map.GetLength(1))
			{
				return false;
			}

			// Check if the coordinate is blocked
			return _map[x, y] != 1;
		}

		private void PrecomputeCost((int X, int Y) end)
		{
			for (var i = 0; i < _map.GetLength(0); i++)
			{
				for (var j = 0; j < _map.GetLength(1); j++)
				{
					// Compute the Manhattan distance between the current coordinate and the end
					int h1 = i - end.X;
					int h2 = j - end.Y;
					if (h1 > 0) h1 = 0 - h1;
					if (h2 > 0) h2 = 0 - h2;
					_heuristicCost[i, j] = h1 + h2;
					// Set the movement cost to 1 for all coordinates
					_movementCost[i, j] = 1;
				}
			}
		}

		private Node GetNodeFromPool(int x, int y)
		{
			if (_nodePool.Count == 0)
			{
				return new Node(x, y, null);
			}

			var node = _nodePool.Pop();
			if (node == null) return null;
			{
				node.X = x;
				node.Y = y;
				node.Parent = null;
				return node;
			}
		}

		private static List<Node> GeneratePath(Node startNode, Node endNode)
		{
			var path = new List<Node>();
			var currentNode = endNode;
			while (currentNode != startNode)
			{
				if (currentNode == null) continue;
				path.Add(currentNode);
				// Console.WriteLine($"Path Node:{currentNode.ToString()}");
				currentNode = currentNode.Parent;
			}

			path.Reverse();
			return path;
		}
	}
}
