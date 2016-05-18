namespace ScheduleInsertionTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ScheduleTree
    {
        public ScheduleTreeNode Root { get; set; }

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
                // Go left
                var leftChild = currentNode.LeftChild;
                if (leftChild == null)
                {
                    // Directly insert nodeToInsert as left child
                    currentNode.LeftChild = nodeToInsert;
                }
                // Check if can be inserted in between
                else if (nodeToInsert.Start >= leftChild.End)
                {
                    var temp = currentNode.LeftChild;
                    currentNode.LeftChild = nodeToInsert;
                    nodeToInsert.LeftChild = temp;
                }
                // Else call Insert method again for the next element
                else
                {
                    this.Insert(currentNode.LeftChild, nodeToInsert);
                }
            }
            else if (currentNode.End <= nodeToInsert.Start)
            {
                // Go right
                var rightChild = currentNode.RightChild;
                if (rightChild == null)
                {
                    // Directly insert nodeToInsert as left child
                    currentNode.RightChild = nodeToInsert;
                }
                // Check if can be inserted in between
                else if (nodeToInsert.End <= rightChild.Start)
                {
                    var temp = currentNode.RightChild;
                    currentNode.RightChild = nodeToInsert;
                    nodeToInsert.RightChild = temp;
                }
                // Else call Insert method again for the next element
                else
                {
                    this.Insert(currentNode.RightChild, nodeToInsert);
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
