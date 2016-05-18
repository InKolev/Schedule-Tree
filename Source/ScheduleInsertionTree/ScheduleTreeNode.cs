namespace ScheduleInsertionTree
{
    using System;

    public class ScheduleTreeNode
    {
        public ScheduleTreeNode Parent { get; set; }

        public ScheduleTreeNode LeftChild { get; set; }

        public ScheduleTreeNode RightChild { get; set; }
        
        public TimeSpan Start { get; set; }

        public TimeSpan End { get; set; }

        public double Weight
        {
            get
            {
                return this.Start.TotalSeconds + this.End.TotalSeconds;
            }
        }
    }
}
