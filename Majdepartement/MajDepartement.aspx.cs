using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Majdepartement
{
    public partial class MajDepartement : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-6003F0OI\SQLEXPRESS01;Initial Catalog=fadilizakaria;Integrated Security=True");
        DataTable d = new DataTable();
        static int index;
        static SqlDataAdapter dataadapter;
        static DataSet ds;
        SqlCommandBuilder builder;
        static SortedList<string, string> list = new SortedList<string, string>();

        public void remplirdata()
        {
            ds = new DataSet();
            d = new DataTable();
            dataadapter = new SqlDataAdapter("select deptno as [Numero departement] ,ndep as [Nom departement] ,location as [Location Département] from dept ", con);
            dataadapter.Fill(ds, "tabledept");
            d = ds.Tables["tabledept"];
            gridDepartement.DataSource = d;
            gridDepartement.DataBind();
            if(d.Rows.Count>0)
            {
                naviguer(0);
            }
        }
        private void naviguer(int index)
        {
            txtNoDepartmenet.Enabled = false;
            txtNomDept.Enabled = false;
            txtLocation.Enabled = false;
          txtNoDepartmenet.Text = d.Rows[index][0].ToString();
            txtNomDept.Text = d.Rows[index][1].ToString();
            txtLocation.Text = d.Rows[2].ToString();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                remplirdata();
                if (list.Count == 0)
                {
                    list.Add("Numero departement", "Desc");
                    list.Add("Nom departement", "Desc");
                    list.Add("Location", "Desc");
                }
            }
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            if(d.Rows.Count>0)
            {
                index = 0;
                naviguer(index);
            }
        }

        protected void btnPrevous_Click(object sender, EventArgs e)
        {
           
            if(d.Rows.Count>0)
            {
                if(index>0)
                {
                    index--;
                }
                else
                {
                    index = 0;
                }
                naviguer(index);
            }

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if(d.Rows.Count > 0)
            {
                if (index < d.Rows.Count - 1)
                    index++;
                naviguer(index);
            }

        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            if(d.Rows.Count>0)
            {
                index = d.Rows.Count - 1;
                naviguer(index);
            }
        }
         private int gridview(int deptno)
        {
            foreach(DataRow r in d.Rows)
            {
                if (int.Parse(r[0].ToString())==deptno)
                {
                    return d.Rows.IndexOf(r);
                }
            }
            return -1;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(btnAdd.Text.Equals("Ajouter"))
            {
                txtNoDepartmenet.Text = "";
                txtNomDept.Text = "";
                txtLocation.Text = "";
                txtNoDepartmenet.Enabled = true;
                txtNomDept.Enabled = true;
                txtLocation.Enabled = true;
                btnAdd.Text = "valider";
            }
            else
            {
                Page.Validate();
                if(Page.IsValid)
                {
                    if(gridview(int.Parse(txtNoDepartmenet.Text.ToString()))==-1)
                        {
                        d.Rows.Add(int.Parse(txtNoDepartmenet.Text), txtNomDept.Text, txtLocation.Text);
                        btnAdd.Text = "Ajouter";
                        txtNoDepartmenet.Text = "";
                        txtNomDept.Text = "";
                        txtLocation.Text = "";
                        naviguer(0);
                        gridDepartement.DataSource = d;
                        gridDepartement.DataBind();
                    }
                    else
                    {
                        Response.Write("le numero est déja existe");
                        btnAdd.Text = "Ajouter";
                        naviguer(0);
                    }


                }
            }
        }

        protected void btnModifier_Click(object sender, EventArgs e)
        {
            if(btnModifier.Text.Equals("Modifier"))
            {
                txtNoDepartmenet.Enabled = false;
                txtNomDept.Enabled = true;
                txtLocation.Enabled = true;
                btnModifier.Text = "valider";
            }
            else
            {
                Page.Validate();
                if(Page.IsValid)
                {
                    d.Rows[index][1] = txtNomDept.Text;
                    d.Rows[index][2] = txtLocation.Text;
                    btnModifier.Text = "Modifier";
                    gridDepartement.DataSource = d;
                    gridDepartement.DataBind();
                    naviguer(0);

                }

            }

        }

        protected void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(btnSupprimer.Text.Equals("Supprimer"))
            {
                txtNoDepartmenet.Enabled = false;
                txtNomDept.Enabled = false;
                txtLocation.Enabled = false;
                btnSupprimer.Text = "valider";

            }else

            {
                Page.Validate();
                if(Page.IsValid)
                {
                    d.Rows[index].Delete();
                    btnSupprimer.Text = "Supprimer";
                    gridDepartement.DataSource = d;
                    gridDepartement.DataBind();

                    naviguer(0);
                }
            }

        }

        protected void btnEnregistrer_Click(object sender, EventArgs e)
        {
            builder = new SqlCommandBuilder(dataadapter);
            dataadapter.Update(d);
            remplirdata();
            gridDepartement.DataSource = d;

        }

        protected void gridDepartement_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridDepartement.SelectedRow;
            index = gridview(int.Parse(row.Cells[1].Text));
            naviguer(index);
        }

        protected void gridDepartement_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDepartement.PageIndex = e.NewPageIndex;
            gridDepartement.DataSource = d;
            gridDepartement.DataBind();

        }

        protected void gridDepartement_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (list[e.SortExpression].ToString().Trim().Equals("Asc"))
                list[e.SortExpression] = "Desc";
            else
                list[e.SortExpression] = "Asc";
            DataView view = new DataView(d);
            view.Sort = e.SortExpression + " " + list[e.SortExpression].ToString();
            gridDepartement.DataSource = view;
            gridDepartement.DataBind();
        }
    }
}