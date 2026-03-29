using TestWins.Controller;

namespace TestWins;

public partial class Form1 : Form
{
    private readonly StudentController controller = new StudentController();

    public Form1()
    {
        InitializeComponent();
        loadData();
    }

    private void loadData()
    {
        dataGridView1.DataSource = controller.getAll();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        controller.add(txtName.Text, txtCourse.Text);
        loadData();
        clearFields();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        int id = int.Parse(txtId.Text);
        controller.update(id, txtName.Text, txtCourse.Text);
        loadData();
        clearFields();
    }


    private void btnDelete_Click(object sender, EventArgs e)
    {
        int id = int.Parse(txtId.Text);
        controller.delete(id);
        loadData();
        clearFields();
    }

   
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            txtId.Text = row.Cells["id"].Value.ToString();
            txtName.Text = row.Cells["name"].Value.ToString();
            txtCourse.Text = row.Cells["course"].Value.ToString();
        }
    }

  
    private void clearFields()
    {
        txtId.Clear();
        txtName.Clear();
        txtCourse.Clear();
    }
}
