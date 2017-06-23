using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgos
{
    public class TreeNode
    {
        public int value;
        public TreeNode Right;
        public TreeNode Left;

        public string name;
    }

    public class LowestCommonAncestorFinder
    {
        public static TreeNode LCA(TreeNode tree, TreeNode n1, TreeNode n2)
        {
            List<TreeNode> ancestorsOfN1 = new List<TreeNode>();
            List<TreeNode> ancestorsOfN2 = new List<TreeNode>();

            tryFindNode(tree, n1, ancestorsOfN1);
            tryFindNode(tree, n2, ancestorsOfN2);

            TreeNode LCANode = null;
            bool found = false;

            // Lists are ordered w/ furthest from the root first
            // if we traverse in order, the first match will be lowest in the tree
            foreach(TreeNode node in ancestorsOfN1)
            {
                if (found)
                    break;
                foreach(TreeNode node2 in ancestorsOfN2)
                {
                    if (node == node2)
                    {
                        LCANode = node;
                        found = true;
                        break;
                    }                        
                }
            }

            return LCANode;
        }

        private static bool tryFindNode(TreeNode current, TreeNode searchNode, List<TreeNode> ancestorPath)
        {
            if (current != null && current == searchNode)
            {
                ancestorPath.Add(current);
                return true;
            }

            else if ((current.Left == null && current.Right == null) || current == null)
                return false;

            if (current.Left != null)
            {
                if (tryFindNode(current.Left, searchNode, ancestorPath))
                {
                    ancestorPath.Add(current);
                    return true;
                }                    
            }

            if (current.Right != null)
            {
                if (tryFindNode(current.Right, searchNode, ancestorPath))
                {
                    ancestorPath.Add(current);
                    return true;
                }                    
            }

            return false;

        } 
    }
}
