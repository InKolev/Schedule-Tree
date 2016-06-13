namespace ScheduleInsertionTree.Test
{
    using ScheduleInsertionTree;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            var tree = new ScheduleTree();
            var node1 = new ScheduleTreeNode() { Start = new TimeSpan(7, 0, 0), End = new TimeSpan(9, 0, 0) };
            var node2 = new ScheduleTreeNode() { Start = new TimeSpan(15, 0, 0), End = new TimeSpan(17, 0, 0) };
            var node4 = new ScheduleTreeNode() { Start = new TimeSpan(13, 0, 0), End = new TimeSpan(14, 0, 0) };
            var node3 = new ScheduleTreeNode() { Start = new TimeSpan(4, 0, 0), End = new TimeSpan(6, 0, 0) };
            var node5 = new ScheduleTreeNode() { Start = new TimeSpan(10, 0, 0), End = new TimeSpan(12, 0, 0) };
            var node6 = new ScheduleTreeNode() { Start = new TimeSpan(12, 0, 0), End = new TimeSpan(14, 0, 0) };

            Console.WriteLine(tree.Insert(tree.Root, node1));
            Console.WriteLine(tree.Insert(tree.Root, node2));
            Console.WriteLine(tree.Insert(tree.Root, node3));
            Console.WriteLine(tree.Insert(tree.Root, node4));
            Console.WriteLine(tree.Insert(tree.Root, node5));
            Console.WriteLine(tree.Insert(tree.Root, node6));

            tree.Print(tree.Root);

            tree.BuildList(tree.Root);
            var treeAsList = tree.GetAsList.OrderBy(x => x.Weight).ToList();

            foreach (var node in treeAsList)
            {
                Console.WriteLine($"{node.Start} {node.End}");
            }
        }
    }
}
