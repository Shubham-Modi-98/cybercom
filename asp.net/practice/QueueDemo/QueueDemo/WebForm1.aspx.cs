﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QueueDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tokenQueue"] == null)
                {
                    Queue<int> queueToken = new Queue<int>();
                    Session["tokenQueue"] = queueToken;
                }
                else
                {
                    Queue<int> tokenQueue = (Queue<int>)Session["tokenQueue"];
                    //lblStatus.Text = "There are " + tokenQueue.Count + " customers before you";
                    //listNames.Items.Clear();
                    //foreach (int token in tokenQueue)
                    //{
                    //    listNames.Items.Add(token.ToString());
                    //}
                    checkCustomer();
                }
            }
        }

        protected void btnPrintToken_Click(object sender, EventArgs e)
        {
            Queue<int> tokenQueue = (Queue<int>)Session["tokenQueue"];
            lblStatus.Text = "There are " + tokenQueue.Count + " customers before you in the queue";
            if(Session["lastToken"] == null)
            {
                Session["lastToken"] = 0;
            }
            int nextNumber = (int)Session["lastToken"] + 1;
            Session["lastToken"] = nextNumber;
            tokenQueue.Enqueue(nextNumber);
            listNames.Items.Clear();
            foreach (int token in tokenQueue)
            {
                listNames.Items.Add(token.ToString());
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Button btnName = (Button)sender;
            if (btnName.ID == "btnNext1")
            {
                moveToCounter(txtCounter1, 1);
            }
            else if (btnName.ID == "btnNext2")
            {
                moveToCounter(txtCounter2, 2);
            }
            else
            {
                moveToCounter(txtCounter3, 3);
            }
        }

        private void moveToCounter(TextBox textBox, int counter)
        {
            Queue<int> tokenQueue = (Queue<int>)Session["tokenQueue"];
            if (tokenQueue.Count == 0)
            {
                txtMessage.Text = "There are no coustomer in Queue";
                textBox.Text = "No Customer";
            }
            else
            {
                int dequeu = tokenQueue.Dequeue();
                txtMessage.Text = "Customer " + dequeu + " go to Counter no." + counter;
                textBox.Text = dequeu.ToString();
                checkCustomer();
            }
        }

        private void checkCustomer()
        {
            Queue<int> tokenQueue = (Queue<int>)Session["tokenQueue"];
            listNames.Items.Clear();
            foreach (int token in tokenQueue)
            {
                listNames.Items.Add(token.ToString());
            }
            if ((tokenQueue.Count - 1) == -1)
            {
                lblStatus.Text = "There are no customers before you in the queue";
            }
            else
            {
                lblStatus.Text = "There are " + (tokenQueue.Count - 1).ToString() + " customers before you in the queue";
            }
        }
    }
}