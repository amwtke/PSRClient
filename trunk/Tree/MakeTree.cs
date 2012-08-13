using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using Db4objects.Db4o;
using Db4objects.Db4o.Query;

namespace APP
{
    /// <summary>
    /// 负责根据ITreeNodeRoot类型展现TreeView
    /// </summary>
    /// <typeparam name="Root"></typeparam>
    /// <typeparam name="Node"></typeparam>
    public class PaintTreeView<Root,Node> 
        where Root:ITreeNodeRoot,new()
        where Node:ITreeNode,new()
    {
        Root _root;
        IObjectContainer _db;
        System.Windows.Forms.TreeView _treeView;
        TreeInforAttribute[] _atts;
        bool _showPrefix = false;
        public PaintTreeView(System.Windows.Forms.TreeView treeView)
        {
            //TestXML();
            _atts = DBHelper.GetTreeInfoAttribute(typeof(Root));
            if (_atts != null && _atts.Length >= 0)
                _db = DBHelper.InitDB4O(_atts[0].DBName, typeof(Root));
            else
                throw new Exception("找不到DB！"+ typeof(Root)+"没有TreeInfor属性？");

            _treeView = treeView;
        }

        public PaintTreeView(System.Windows.Forms.TreeView treeView,bool showPrefix)
        {
            //TestXML();
            _atts = DBHelper.GetTreeInfoAttribute(typeof(Root));
            if (_atts != null && _atts.Length >= 0)
                _db = DBHelper.InitDB4O(_atts[0].DBName, typeof(Root));
            else
                throw new Exception("找不到DB！" + typeof(Root) + "没有TreeInfor属性？");

            _treeView = treeView;
            _showPrefix = showPrefix;
        }

        public void ShowTreeView(System.Windows.Forms.TreeView treeView, Root root)
        {
            if (_root != null)
            {
                AddNode(treeView, root);
            }
        }

        private string GetRealName(string no,int level)
        {
            string facilityNo = FacilityName.GetFacilityNameByNO(no);
            string zhuantiNo = ZhuanTiManager.GetSubjectNameByNO(no);
            string yaosuNo = YaoSuManager.GetElementNameByNO(no);
            string str = "";
            if (facilityNo != "" && level==1)
            {
                str = facilityNo;
            }
            if (zhuantiNo != ""&& level==3)
                str = zhuantiNo;
            if (yaosuNo != "" && level==2)
                str = yaosuNo;
            return str;
        }

        public Root ShowTreeView(string user)
        {
            try
            {
                
                if (LoadTreeInfo(_db, _atts[0].TreeName, user))
                {
                    AddNode(_treeView, _root);
                }
                return _root;
                //else
                //    MainForm.ShowMessage("没有找到记录：TreeName=" + treeName + " user:" + user, new object());
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                _db.Close(); 
            }
        }

        void AddNode(System.Windows.Forms.TreeView treeView, Root root)
        {
            treeView.CheckBoxes = root.CheckBox;
            if (root.ChildNodes != null && root.ChildNodes.Length > 0)
            {
                foreach (Node n in root.ChildNodes)
                {
                    MakeNode(treeView, n);
                }
            }
        }

        int level = 1;
        void MakeChild(System.Windows.Forms.TreeNode fatherNode, Node node)
        {
            
            if (node != null)
            {
                level++;
                System.Windows.Forms.TreeNode _TreeNode =null;
                if (!_showPrefix)
                    _TreeNode = new System.Windows.Forms.TreeNode(GetRealName(GetRidOfIndexPrefix(node.NodeName),level));
                else
                    _TreeNode = new System.Windows.Forms.TreeNode(node.NodeName);

                #region 加入单击显示的窗口。
                object _treeNodeObj = null;
                if (!string.IsNullOrEmpty(node.ControlType))
                {
                    try
                    {
                        _treeNodeObj = DBHelper.GetObjectFromString<ITreeNodeAction>(node.ControlType);
                        if (_treeNodeObj != null)
                            _TreeNode.Tag = _treeNodeObj;
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
                #endregion

                #region 设置节点的显示属性
                if (node.BackColor != null)
                    _TreeNode.BackColor = node.BackColor;


                _TreeNode.Checked = node.Checked;

                #endregion

                fatherNode.Nodes.Add(_TreeNode);
                if (node.ChildNodes != null && node.ChildNodes.Length > 0)
                {
                    foreach (Node n in node.ChildNodes)
                    {
                        MakeChild(_TreeNode, n);
                    }
                }
                level--;
            }
        }

        void MakeNode(System.Windows.Forms.TreeView treeView, Node node)
        {
            if(node!=null)
            {
                try
                {

                    System.Windows.Forms.TreeNode _TreeNode =null;
                    if (_showPrefix)
                        _TreeNode = new System.Windows.Forms.TreeNode(node.NodeName);
                    else
                        _TreeNode = new System.Windows.Forms.TreeNode(GetRealName(GetRidOfIndexPrefix(node.NodeName),1));

                    #region 加入单击显示的窗口。
                    object _treeNodeObj=null;
                    if (!string.IsNullOrEmpty(node.ControlType))
                    {
                        try
                        {
                            _treeNodeObj = DBHelper.GetObjectFromString<ITreeNodeAction>(node.ControlType);
                            if (_treeNodeObj != null)
                                _TreeNode.Tag = _treeNodeObj;
                        }
                        catch (System.Exception ex)
                        {
                            throw ex;
                        }
                    }
                    #endregion

                    #region 设置节点的显示属性
                    if (node.BackColor != null)
                        _TreeNode.BackColor = node.BackColor;

                    if (node.Checked != null)
                        _TreeNode.Checked = node.Checked;
                    else
                        _TreeNode.Checked = false;
                    #endregion

                    treeView.Nodes.Add(_TreeNode);
                    if (node.ChildNodes != null && node.ChildNodes.Length > 0)
                    {
                        foreach (Node n in node.ChildNodes)
                        {
                            MakeChild(_TreeNode, n);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        bool LoadTreeInfo(IObjectContainer db,string TreeName,string user)
        {
            Root example = new Root();
            example.RootValue = user;

            Root[] re = DBHelper.FindByExample<Root>(_db, example);
            if (re != null && re.Length > 0)
            {
                _root = re[0];
                return true;
            }
            return false;
        }

        public static string GetRidOfIndexPrefix(string nodename)
        {
            int index = nodename.LastIndexOf('.');
            if(index!=-1)
                return nodename.Remove(0, index+1);
            return nodename;
        }
    }

    /// <summary>
    /// 负责生成Root对象 并存入数据库
    /// </summary>
    /// <typeparam name="Root"></typeparam>
    /// <typeparam name="Node"></typeparam>
    public class GenViewToDB<Root, Node>
        where Root : ITreeNodeRoot, new()
        where Node : ITreeNode, new()
    {
        IObjectContainer _db;
        Root _root;
        string _dbname;
        TreeInforAttribute[] _atts;
        public Root root
        {
            get { return _root; }
        }
        public Dictionary<string, List<ITreeNode>> ParentAndMe
        {
            get { return _parentAndNode; }
        }
        /// <summary>`
        /// ROOT的key值一定要赋值!!!!!!!!!!!
        /// ROOT=New Root()对于从根节点录入数据构建树；
        /// 如果传入的Root有值则是更新。
        /// </summary>
        /// <param name="root"></param>
        public GenViewToDB(Root root)
        {
            _atts = DBHelper.GetTreeInfoAttribute(typeof(Root));
            if (_atts != null && _atts.Length >= 0)
                _dbname = _atts[0].DBName;
            else
                throw new Exception("找不到DB！" + typeof(Root) + "没有TreeInfor属性？");
            LoadRoot(root);
        }
        private Dictionary<string, List<ITreeNode>> _parentAndNode = new Dictionary<string,List< ITreeNode>>();
        void LoadRoot(Root root)
        {
            _root = root;
            //已经有数据了
            if (_root != null)
            {
                if (_root.ChildNodes != null && _root.ChildNodes.Length > 0)
                {
                    _rootNodeList.AddRange(_root.ChildNodes);
                    foreach (Node n in _root.ChildNodes)
                    {
                        LoadChildNode(n);
                    }

                    //清空一下_root的子节点，这些信息是多余的
                    foreach (Node node in _root.ChildNodes)
                    {
                        node.ChildNodes = null;
                    }
                }
            }
            if (!DBHelper.IsKeysHaveValue(typeof(Root), _root))
            {
                throw new Exception("Root的Key值没有填写完整！");
            }
        }

        void LoadChildNode(Node node)
        {
            if (node.ChildNodes != null && node.ChildNodes.Length > 0)
            {
                foreach (Node n in node.ChildNodes)
                {
                    AddNode(node.NodeName, n);
                    LoadChildNode(n);
                }
            }
        }
       
        List<ITreeNode> _rootNodeList = new List<ITreeNode>();

        /// <summary>
        ///规定 如果是根节点，ParentNodename 等于null或者""
        /// </summary>
        /// <param name="parentNodeName"></param>
        /// <param name="node"></param>
        public void AddNode(string parentNodeName, Node node)
        {
            if (string.IsNullOrEmpty(parentNodeName))
            {
                _rootNodeList.Add(node);
            }
            else
            {
                if (_parentAndNode.ContainsKey(parentNodeName))
                    _parentAndNode[parentNodeName].Add(node);
                else
                {
                    _parentAndNode[parentNodeName] = new List<ITreeNode>();
                    _parentAndNode[parentNodeName].Add(node);
                }
            }
        }

        bool SaveToDB(Root root)
        {
            try
            {
                _db = DBHelper.InitDB4O(_dbname, typeof(Root));
                if (!DBHelper.SaveToDB(_db, _root, true))//true))
                {
                    DBHelper.UpdateFromDB(_db, _root);
                }
                return true;
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

        /// <summary>
        /// 确保TreView的Checked字段跟内部数据结构一致
        /// </summary>
        /// <param name="treeview"></param>
        /// <returns></returns>
        public bool SaveToDb(System.Windows.Forms.TreeView treeview)
        {
            //第一遍先生成根节点s
            if (_rootNodeList != null && _rootNodeList.Count>0)
            {
                _root.ChildNodes = _rootNodeList.ToArray();
                foreach (ITreeNode node in _root.ChildNodes)
                {
                    AppendNode(node);
                }
                //确保check字段跟TreView控件的一致
                if (treeview != null)
                {
                    //TreeNodeHelper.ValidateCheckedBeforeSave(treeview, _root);
                }
                return SaveToDB(_root);
            }
            return false;
        }

        public bool SaveToDb()
        {
            //第一遍先生成根节点s
            if (_rootNodeList != null && _rootNodeList.Count > 0)
            {

                _root.ChildNodes = _rootNodeList.ToArray();
                foreach (ITreeNode node in _root.ChildNodes)
                {
                    AppendNode(node);
                }
               
                return SaveToDB(_root);
            }
            return false;
        }


        void AppendNode(ITreeNode node)
        {
            if (_parentAndNode.ContainsKey(node.NodeName)&&_parentAndNode[node.NodeName] != null)
            {
                node.ChildNodes = _parentAndNode[node.NodeName].ToArray();
                foreach (ITreeNode n in node.ChildNodes)
                {
                    AppendNode(n);
                }
            }
        }

        public void DeleteNode(string parentNode,string nodeName)
        {
            Node node = GetNodeByParentAddingTimeOnly(parentNode, nodeName);
            if ( node!=null && !string.IsNullOrEmpty(node.NodeName))
            {
                if (string.IsNullOrEmpty(parentNode))
                {
                    _rootNodeList.Remove(node);
                }
                else
                {
                    if (_parentAndNode.ContainsKey(parentNode))
                    {
                        _parentAndNode[parentNode].Remove(node);
                        _parentAndNode.Remove(node.NodeName);
                    }
                }
            }
        }
        

        /// <summary>
        /// 只检查NodeName字段的值。如果有则放回。
        /// </summary>
        /// <param name="parentNodeName"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node GetNodeByParentAddingTimeOnly(string parentNodeName,string nodeName)
        {
            if (string.IsNullOrEmpty(parentNodeName))
            {
                foreach (Node n in _rootNodeList)
                {
                    if (nodeName == n.NodeName)
                        return n;
                }
                return default(Node);
            }
            else
            {
                if (_parentAndNode.ContainsKey(parentNodeName))
                {
                    foreach (Node n in _parentAndNode[parentNodeName])
                    {
                        if (nodeName == n.NodeName)
                            return n;
                    }
                }
                return default(Node);
            }
        }
    }
}
