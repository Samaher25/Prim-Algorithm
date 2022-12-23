using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prim_Sort
{
    internal class Program
    {
        static int V = 5;
        static int minKey(int[] key, bool[] mstSet)
        {
            int min = int.MaxValue, min_index = -1;

            for (int v = 0; v < V; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    min_index = v;
                }
            return min_index;
        }
        static void printMST(int[] parent, int[,] graph)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < V; i++)
                Console.WriteLine(parent[i] + " - " + i + "\t"   + graph[i, parent[i]]);
        }

        static void primMST(int[,] graph)
        {
            int[] parent = new int[V];
            int[] key = new int[V];
            bool[] mstSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < V - 1; count++)
            {
                int u = minKey(key, mstSet);
                mstSet[u] = true;

                for (int v = 0; v < V; v++)

                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            printMST(parent, graph);
        }
        static int getMinCost(int Vertices)
        {
            int cost = 0;

            // Calculating cost of MST
            cost = (Vertices * Vertices) - Vertices + 1;

            return cost;
        }


        static void Main(string[] args)
        {
            int[,] graph = new int[,] { { 0, 2, 0, 6, 0 },
                                      { 2, 0, 3, 8, 5 },
                                      { 0, 3, 0, 0, 7 },
                                      { 6, 8, 0, 0, 9 },
                                      { 0, 5, 7, 9, 0 } };

            primMST(graph);
            Console.WriteLine(getMinCost(V));

        }
    }
}
