using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using System.Collections;

namespace APP
{
    public class TreeNodeHelper
    {
        private static Dictionary<string, RootNode> _rootNodeCache = new Dictionary<string, RootNode>();
        private static Dictionary<string, ITreeNodeRoot> _rootAuthorCache = new Dictionary<string, ITreeNodeRoot>();
        private static Dictionary<string, ITreeNodeRoot> _rootFormTreeCache = new Dictionary<string, ITreeNodeRoot>();

        public static void XMLSerialize(string fileName, object sourceObject)
        {
            try
            {
                if (File.Exists(fileName))
                    File.Delete(fileName);

                XmlSerializer serializer = new XmlSerializer(sourceObject.GetType());
                TextWriter writer = new StreamWriter(fileName);
                serializer.Serialize(writer, sourceObject);
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T XMLDeSerialize<T>(string fileName) //where T : new()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    return (T)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度
            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }
            return _FolderPath;
        }

        /// <summary>
        /// 在MainForm中显示的Tab
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static Form ShowFormInPanel<T>() where T:Form,new()
        {
            T form = new T();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            MainForm.AddForm(form);
            return form;
        }

        public static T[] GetRootNodeFromDB<T>(string dbFileName, string treeName, string user) where T : ITreeNodeRoot,new()
        {
            IObjectContainer db = null;
            try
            {
                db = DBHelper.InitDB4O(dbFileName, typeof(T));
                T t = new T();
                
                t.RootValue = user;
                return DBHelper.FindByExample<T>(db, t); 
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Close();
            }
        }

        /// <summary>
        /// Root类型必须要有Key
        /// </summary>
        /// <typeparam name="Root"></typeparam>
        /// <typeparam name="Node"></typeparam>
        /// <param name="dbFileName"></param>
        /// <param name="treeName"></param>
        /// <param name="user"></param>
        /// <param name="parentName"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static bool GetNodeFromDB<Root,Node>(string user,string parentName, string nodeName, out Node retNode) where Root : ITreeNodeRoot,new() where Node:ITreeNode,new()
        {
            TreeInforAttribute[] _atts;
            string dbFileName = null;
            string treeName = null;

            _atts = DBHelper.GetTreeInfoAttribute(typeof(Root));
            if (_atts != null && _atts.Length >= 0)
            {
                dbFileName = _atts[0].DBName;
                treeName = _atts[0].TreeName;
            }
            else
            {
                throw new Exception("找不到Class属性！");
            }

            Root _root=new Root();
            if (_root is AuthorizationTree)
            {
                if (!_rootAuthorCache.ContainsKey(user))//缓存中读取
                {
                    _root = GetRootNodeFromDB<Root>(dbFileName, treeName, user)[0];
                    _rootAuthorCache.Add(user, (ITreeNodeRoot)_root);
                }
                else
                {
                    _root = (Root)_rootAuthorCache[user];
                }
            }
            else if (_root is TreeOfForms)
            {
                if (!_rootFormTreeCache.ContainsKey(user))//缓存中读取
                {
                    _root = GetRootNodeFromDB<Root>(dbFileName, treeName, user)[0];
                    _rootFormTreeCache.Add(user, _root);
                }
                else
                {
                    _root = (Root)_rootFormTreeCache[user];
                }
            }
            
            if (_root != null)
            {
                return GetNodeFromRootObject<Root, Node>(_root, parentName, nodeName, out retNode);
            }
            retNode = new Node();
            return false;
        }

        public static bool GetNodeFromRootObject<Root,Node>(Root root,string parentName,string nodeName,out Node retNode)
            where Root : ITreeNodeRoot, new()
            where Node : ITreeNode, new()
        {
            Node _retnode =new Node();
            Node _parentNode = new Node();
            if (root != null)//顶级
            {
                if (string.IsNullOrEmpty(parentName))
                {
                    foreach (Node node in root.ChildNodes)
                    {
                        if (node.NodeName == nodeName)
                        {
                            retNode = node;
                            return true;
                        }
                    }
                }
                else
                {
                    if (root.ChildNodes != null && root.ChildNodes.Length > 0)
                    {
                        foreach (Node n in root.ChildNodes)
                        {
                            if (GetChildNodeByName<Node>(n, parentName, out _parentNode))
                            {
                                if (!string.IsNullOrEmpty(_parentNode.NodeName))
                                {
                                    foreach (Node nn in _parentNode.ChildNodes)
                                    {
                                        if (GetChildNodeByName<Node>(nn, nodeName, out _retnode))
                                        {
                                            retNode = _retnode;
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            retNode = _retnode;
            return false;
        }

        /// <summary>
        /// 匹配第一个Node.NodeName相等的对象
        /// </summary>
        /// <typeparam name="Node"></typeparam>
        /// <param name="node"></param>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public static bool GetChildNodeByName<Node>(Node node, string nodeName,out Node retNode) where Node : ITreeNode, new()
        {
            Node _retNode = new Node();
            if (node != null)
            {
                if (node.NodeName == nodeName)
                {
                    retNode = node;
                    return true;
                }
                else if (node.ChildNodes != null && node.ChildNodes.Length > 0)
                {
                    foreach (Node n in node.ChildNodes)
                    {
                        if (GetChildNodeByName<Node>(n, nodeName, out _retNode))
                        {
                            retNode = _retNode;
                            return true;
                        }
                    }
                }
            }
            retNode = _retNode;
            return false;
        }

        public static RootNode GetRootNodeByUserName(String user)
        {
            IObjectContainer _db = null;
            try
            {
                if (_rootNodeCache.ContainsKey(user))
                {
                    return (RootNode)_rootNodeCache[user];
                }

                TreeInforAttribute[] _atts = DBHelper.GetTreeInfoAttribute(typeof(RootNode));
                _db = DBHelper.InitDB4O(_atts[0].DBName, typeof(RootNode));
                RootNode example = new RootNode();
                example.RootValue = user;
                RootNode[] re = DBHelper.FindByExample<RootNode>(_db, example);
                if (re != null && re.Length > 0)
                {
                    _rootNodeCache.Add(user, re[0]);
                    return re[0];
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (_db != null)
                    _db.Close();
            }
        }

        public static string GetRidOfIndexPrefix(string nodename)
        {
            int index = nodename.LastIndexOf('.');
            if (index != -1)
                return nodename.Remove(0, index + 1);
            return nodename;
        }

        #region UI
        public static void AddNodeSameLevel<Root, Node>(TreeView treeView, Node addNode, GenViewToDB<Root, Node> saver) 
            where Root:ITreeNodeRoot,new()
            where Node:ITreeNode,new()
        {
            if (treeView.SelectedNode == null)
            {
                TreeNode tn = new TreeNode(addNode.NodeName);
                tn.BackColor = addNode.BackColor;
                treeView.Nodes.Add(tn);

                saver.AddNode(null, addNode);
            }
            else
            {
                if (treeView.SelectedNode.Level == 0)
                {
                    TreeNode tn = new TreeNode(addNode.NodeName);
                    tn.BackColor = addNode.BackColor;
                    treeView.Nodes.Add(tn);
                    saver.AddNode(null, addNode);
                }
                else
                {
                    TreeNode tn = new TreeNode(addNode.NodeName);
                    tn.BackColor = addNode.BackColor;
                    treeView.SelectedNode.Parent.Nodes.Add(tn);
                    saver.AddNode(treeView.SelectedNode.Parent.Text, addNode);
                }
            }
            treeView.ExpandAll();
        }

        public static void AddNodeSameLevel<Root, Node>(MWControls.MWTreeView treeView, Node addNode, GenViewToDB<Root, Node> saver)
            where Root : ITreeNodeRoot, new()
            where Node : ITreeNode, new()
        {
            if (treeView.SelNode == null)
            {
                TreeNode tn = new TreeNode(addNode.NodeName);
                tn.BackColor = addNode.BackColor;
                treeView.Nodes.Add(tn);

                saver.AddNode(null, addNode);
            }
            else
            {
                if (treeView.SelNode.Level == 0)
                {
                    TreeNode tn = new TreeNode(addNode.NodeName);
                    tn.BackColor = addNode.BackColor;
                    treeView.Nodes.Add(tn);
                    saver.AddNode(null, addNode);
                }
                else
                {
                    TreeNode tn = new TreeNode(addNode.NodeName);
                    tn.BackColor = addNode.BackColor;
                    treeView.SelNode.Parent.Nodes.Add(tn);
                    saver.AddNode(treeView.SelNode.Parent.Text, addNode);
                }
            }
            treeView.ExpandAll();
        }


        public static void AddNodeNextLevel<Root, Node>(TreeView treeView, Node addNode, GenViewToDB<Root, Node> saver)
            where Root : ITreeNodeRoot, new()
            where Node : ITreeNode, new()
        {
            if (treeView.SelectedNode == null)
            {
                TreeNode tn = new TreeNode(addNode.NodeName);
                tn.BackColor = addNode.BackColor;
                treeView.Nodes.Add(tn);
                saver.AddNode(null, addNode);
            }
            else
            {
                TreeNode tn = new TreeNode(addNode.NodeName);
                tn.BackColor = addNode.BackColor;
                treeView.SelectedNode.Nodes.Add(tn);
                saver.AddNode(treeView.SelectedNode.Text, addNode);
            }

            treeView.ExpandAll();
        }

        public static void AddNodeNextLevel<Root, Node>(MWControls.MWTreeView treeView, Node addNode, GenViewToDB<Root, Node> saver)
            where Root : ITreeNodeRoot, new()
            where Node : ITreeNode, new()
        {
            if (treeView.SelNode == null)
            {
                TreeNode tn = new TreeNode(addNode.NodeName);
                tn.BackColor = addNode.BackColor;
                treeView.Nodes.Add(tn);
                saver.AddNode(null, addNode);
            }
            else
            {
                TreeNode tn = new TreeNode(addNode.NodeName);
                tn.BackColor = addNode.BackColor;
                treeView.SelNode.Nodes.Add(tn);
                saver.AddNode(treeView.SelNode.Text, addNode);
            }

            treeView.ExpandAll();
        }

        public static void UpdateNodeDictionaryKeyName(Dictionary<String, List<ITreeNode>> dic, string oldName, string newName)
        {
            if (!oldName.Equals(newName))
            {
                if (dic.ContainsKey(oldName))
                {
                    dic[newName] = dic[oldName];
                    dic.Remove(oldName);
                }
            }
        }

        public static void DeleteSelectedNode<Root,Node>(TreeView treeView,GenViewToDB<Root, Node> saver)
            where Root : ITreeNodeRoot, new()
            where Node : ITreeNode, new()
        {
            if (treeView.Nodes != null && treeView.Nodes.Count == 0)
            {
                MessageBox.Show("无节点！");
            }
            else if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Level == 0)
                {

                    saver.DeleteNode(null, treeView.SelectedNode.Text);
                }
                else
                {
                    saver.DeleteNode(treeView.SelectedNode.Parent.Text, treeView.SelectedNode.Text);
                }
                treeView.SelectedNode.Remove();
            }
            treeView.ExpandAll();
        }

        public static void DeleteSelectedNode<Root, Node>(MWControls.MWTreeView treeView, GenViewToDB<Root, Node> saver)
            where Root : ITreeNodeRoot, new()
            where Node : ITreeNode, new()
        {
            if (treeView.Nodes != null && treeView.Nodes.Count == 0)
            {
                MessageBox.Show("无节点！");
            }
            else if (treeView.SelNodes != null && treeView.SelNodes.Count>0)
            {
                Hashtable _hashtable = treeView.SelNodes.Clone() as Hashtable;

                foreach (MWCommon.MWTreeNodeWrapper treenode in _hashtable.Values)
                {
                    if (treenode.Node.Level == 0)
                    {
                        saver.DeleteNode(null, treenode.Node.Text);
                    }
                    else
                    {
                        saver.DeleteNode(treenode.Node.Parent.Text, treenode.Node.Text);
                    }
                    treenode.Node.Remove();
                }
            }
            treeView.ExpandAll();
        }


        public static void ValidateCheckedBeforeSave(TreeView treeview, ITreeNodeRoot root)
        {
            if (treeview != null && root != null)
            {
                for (int i = 0; i < treeview.Nodes.Count; i++)
                {
                    root.ChildNodes[i].Checked = treeview.Nodes[i].Checked;
                    CheckChildNode(treeview.Nodes[i], root.ChildNodes[i]);
                }
            }
        }

        static void CheckChildNode(TreeNode treenode, ITreeNode node)
        {
            if (treenode != null && node != null)
            {
                node.Checked = treenode.Checked;
                if (treenode.Nodes != null && treenode.Nodes.Count > 0)
                {
                    for (int i = 0; i < treenode.Nodes.Count; i++)
                    {
                        CheckChildNode(treenode.Nodes[i], node.ChildNodes[i]);
                    }
                }
            }
        }

        public static void RefreshTreeView<Root,Node>(TreeView tree,ref GenViewToDB<Root,Node> saver,string user) where Root:ITreeNodeRoot,new()
            where Node:ITreeNode,new()
        {
            Root root = new Root();
            root.CheckBox = false;
            root.RootValue = user;
            root.CheckBox = true;
            PaintTreeView<Root, Node> ptv = new PaintTreeView<Root, Node>(tree,true);
            Root _root = ptv.ShowTreeView(user);
            if (_root == null) { _root = root; }
            saver = new GenViewToDB<Root, Node>(_root);
        }
        #endregion
    }
}
