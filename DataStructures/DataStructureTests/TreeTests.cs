using System;
using NUnit.Framework;
using TreeAlgos;

namespace DataStructureTests
{
    [TestFixture]
    public class TreeTests
    {
        [Test]
        public void LCA_Returns_ProperAncestorNode()
        {
            TreeNode root = new TreeNode() { name = "root" };
            TreeNode n1 = new TreeNode() { name = "n1" };
            TreeNode n2 = new TreeNode() { name = "n2" };
            TreeNode LCANode = new TreeNode() { name = "Ancestor" };

            root.Left = LCANode;
            LCANode.Left = n1;
            n1.Left = new TreeNode();

            LCANode.Right = new TreeNode();
            LCANode.Right.Right = n2;
            LCANode.Right.Left = new TreeNode();

            root.Right = new TreeNode();
            root.Right.Left = new TreeNode();
            root.Right.Right = new TreeNode();
            /*
             *      r
             *    A  -
             *  n1 -  - -
             * -  - n2 
             */

            var output = LowestCommonAncestorFinder.LCA(root, n1, n2);

            Assert.AreEqual(n2, LCANode.Right.Right);
            Assert.AreEqual(LCANode, output);
        }
    }
}
