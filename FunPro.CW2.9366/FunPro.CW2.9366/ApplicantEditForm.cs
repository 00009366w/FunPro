using System;
using System.Windows.Forms;
using FunPro.CW2._9366.DAL;

namespace FunPro.CW2._9366
{
    public partial class ApplicantEditForm : Form
    {
        public ApplicantEditForm()
        {
            InitializeComponent();
        }
        public Applicant Applicant { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewApplicant()
        {
            Mode = FormMode.CreateNew;
            Applicant = new Applicant();
            InitializeControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        public void UpdateApplicant(Applicant applicant)
        {
            Mode = FormMode.Update;
            Applicant = applicant;
            InitializeControls();
            ShowApplicantInControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        private void InitializeControls()
        {
            
        }

        private void ShowApplicantInControls()
        {
            tbxName.Text = Applicant.Name;
            nudScore.DecimalPlaces = Applicant.Score;
            tbxTests.Text = Applicant.Tests_taken;
        }

        private void GrabUserInput()
        {
            Applicant.Name = tbxName.Text;
            Applicant.Score = nudScore.DecimalPlaces;
            Applicant.Tests_taken = tbxTests.Text;
        }
        private void ApplicantEditForm_Load(object sender, EventArgs e)
        {
            tbxName.Text = Applicant.Name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new ApplicantManager();
                if (Mode == FormMode.CreateNew)
                    manager.Create(Applicant);
                else
                    manager.Update(Applicant);
                MyForms.GetForm<ApplicantListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}


