namespace ScheduleInsertionTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ScheduleTree
    {
        public ScheduleTree()
        {
            this.GetAsList = new List<ScheduleTreeNode>();
        }

        public ScheduleTreeNode Root { get; set; }

        public List<ScheduleTreeNode> GetAsList { get; set; }

        public bool Insert(ScheduleTreeNode nodeToInsert)
        {
            return this.Insert(this.Root, nodeToInsert);
        }

        public bool Insert(ScheduleTreeNode currentNode, ScheduleTreeNode nodeToInsert)
        {
            if (currentNode == null)
            {
                this.Root = nodeToInsert;
                return true;
            }
            if (nodeToInsert == null)
            {
                return false;
            }

            if (nodeToInsert.End <= currentNode.Start)
            {
                if (currentNode.LeftChild == null)
                {
                    // Directly insert nodeToInsert as left child
                    currentNode.LeftChild = nodeToInsert;
                    return true;
                }
                else
                {
                    // Go left
                    return this.Insert(currentNode.LeftChild, nodeToInsert);
                }
            }
            else if (currentNode.End <= nodeToInsert.Start)
            {
                if (currentNode.RightChild == null)
                {
                    // Directly insert nodeToInsert as left child
                    currentNode.RightChild = nodeToInsert;
                    return true;
                }
                else
                {
                    // Go right
                    return this.Insert(currentNode.RightChild, nodeToInsert);
                }
            }
            else
            {
                return false;
            }
        }

        public void Print(ScheduleTreeNode startNode, int level = 1)
        {
            if(startNode != null)
            {
                Console.WriteLine($"Level: {level} - {startNode.Start} - {startNode.End}");
            }
            else
            {
                Console.WriteLine("No elements in the tree");
            }

            if (startNode.LeftChild != null)
            {
                var nextLevel = level + 1;
                this.Print(startNode.LeftChild, nextLevel);
            }

            if(startNode.RightChild != null)
            {
                var nextLevel = level + 1;
                this.Print(startNode.RightChild, nextLevel);
            }
        }

        public void BuildList(ScheduleTreeNode startNode)
        {
            if (startNode != null)
            {
                this.GetAsList.Add(startNode);
            }
            else
            {
                return;
            }

            if (startNode.LeftChild != null)
            {
                this.BuildList(startNode.LeftChild);
            }

            if (startNode.RightChild != null)
            {
                this.BuildList(startNode.RightChild);
            }
        }
    }
}
