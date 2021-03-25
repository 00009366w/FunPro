using System;
using System.Windows.Forms;
using FunPro.CW2._9366.DAL; 

namespace FunPro.CW2._9366
{
    public partial class ApplicantListForm : Form
    {
        public ApplicantListForm()
        {
            InitializeComponent();
        }

        private void ApplicantListForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new ApplicantList().GetAllApplicants();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
                if (cbxSort.SelectedIndex < 0)
                    MessageBox.Show("Select an attribute to sort by");
                else
                {
                ByAttribute selectedAttribute = ByAttribute.Score;
                    dgv.DataMember = "";
                    dgv.DataSource = null;
                    dgv.DataSource = new ApplicantList().Sort(selectedAttribute);
                }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (nudId.Value <= 0)
MessageBox.Show("Select a correct ID");
else
{

               
                var id = Convert.ToInt32(nudId.Value);
dgv.DataMember = "";
dgv.DataSource = null;
dgv.DataSource = new ApplicantList().Search(id);
}

        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new ApplicantEditForm().CreateNewApplicant();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant");
            else
            {
                var c = (Applicant)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantEditForm().UpdateApplicant(c);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select an applicant");
            else
            {
                var c = (Applicant)dgv.SelectedRows[0].DataBoundItem;
                new ApplicantManager().Delete(c.Id);
                LoadData();
            }

        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }
    }
}
