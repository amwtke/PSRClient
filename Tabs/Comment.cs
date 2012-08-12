using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APP
{
    public partial class Comment : Form
    {
        private string strComment = "";//审批意见
        private bool blCancelEdit = true;//是否取消了操作
        public Comment()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 审批意见
        /// </summary>
        public string CommentContent
        {
            get
            {
                return this.strComment;
            }
            set
            {
                strComment = value;
            }
        }
        /// <summary>
        /// 是否取消操作
        /// </summary>
        public bool CancelEdit
        {
            get
            {
                return this.blCancelEdit;
            }
            set
            {
                this.blCancelEdit = value;
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.CancelEdit = false;//未取消操作
            this.strComment = txtComment.Text.Trim();//获取审批意见
            this.Close();
        }

        private void Comment_Load(object sender, EventArgs e)
        {
            this.txtComment.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.CancelEdit = true;
            this.Close();
        }
    }
}
