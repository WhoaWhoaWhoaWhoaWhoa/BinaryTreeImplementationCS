internal class TreeRealization
{
    private static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();

        tree.Add(8);

        tree.Add(4);

        tree.Add(2);
        tree.Add(1);
        tree.Add(3);

        tree.Add(6);
        tree.Add(5);
        tree.Add(7);

        tree.Add(12);

        tree.Add(10);
        tree.Add(9);
        tree.Add(11);

        tree.Add(14);
        tree.Add(13);
        tree.Add(15);

        tree.SimpleTreePrint();
        System.Console.WriteLine(tree.GetDepth());
    }
    class Node
    {
        public Node LeftNode { get; set; }
        public Node RightNode { get; set; }
        public int Data { get; set; }
    }

    class BinaryTree
    {
        public Node Root { get; set; }

        public int GetDepth()
        {
            return  f(Root, 0, 0);
        }

        public int f(Node n, int depth, int maxDepth)
        {
            if (n.LeftNode != null) f(n.LeftNode, depth++, maxDepth);
            if (n.RightNode != null) f(n.RightNode, depth++, maxDepth);
            if (maxDepth < depth) maxDepth = depth;
            return depth;
        }

        public bool Add(int value)
        {
            Node before = null, after = this.Root;

            while (after != null)
            {
                before = after;
                if (value < after.Data)
                    after = after.LeftNode;
                else if (value > after.Data)
                    after = after.RightNode;
                else
                {
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = value;

            if (this.Root == null)
                this.Root = newNode;
            else
            {
                if (value < before.Data)
                    before.LeftNode = newNode;
                else
                    before.RightNode = newNode;
            }

            return true;
        }
        public void SimpleTreePrint()
        {
            int depth = 4;
            int currentDepth;
            int initialIndent;
            for (int i = depth; i > 0; i--)
            {
                initialIndent = 0;
                currentDepth = i;
                for (; currentDepth > 0; currentDepth--)
                {
                    initialIndent += (int)Math.Pow(2, currentDepth - 2);
                }
                for (int j = 0; j < initialIndent; j++)
                {
                    System.Console.Write(" ");
                }
                fun(Root, i, depth);
                System.Console.WriteLine();
            }
        }

        public void fun(Node parent, int i, int depth)
        {
            if (parent != null)
            {
                if (i == depth)
                {
                    Console.Write(parent.Data);
                    int intermidiateIndent = (int)Math.Pow(2, depth) - 1;
                    for (int k = 0; k < intermidiateIndent; k++)
                    {
                        System.Console.Write(" ");
                    }
                    return;
                }
                depth--;
                fun(parent.LeftNode, i, depth);
                fun(parent.RightNode, i, depth);
            }
        }
    }
}
