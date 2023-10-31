namespace End_Group_Analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool IsGruppoid;
        bool IsPoluGruppa;
        bool IsKvasiGruppa;
        bool IsMonoid;
        bool IsLupa;
        bool IsGruppa;
        bool IsAbelevaGruppa;
        int[,] mass;
        List<int> univ = new List<int>();

        private void button1_Click(object sender, EventArgs e)
        {
            univ.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            try
            {
                int n = Convert.ToInt32(textBox1.Text);
                if (n >= 6) { MessageBox.Show("�������� ��������� �� ������ 5"); return; }
                mass = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    univ.Add(i);
                    dataGridView1.Columns.Add($"{i}", "");
                    dataGridView1.Columns[i].HeaderText = $"{i}";
                    dataGridView1.Columns[i].Width = 70;
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
                }
                button2.Enabled = true;
            }
            catch (Exception) { MessageBox.Show("������� ������ ������� ����!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if ((string)dataGridView1[j, i].Value != null) { mass[i, j] = Convert.ToInt32(dataGridView1[j, i].Value); } else { MessageBox.Show("�� ��� ������ ������� ���������!"); return; }
                }
            }
            PropertiesFe fp = new(mass, univ);

            if (fp.Isolation()) { label10.Text = "��"; IsGruppoid = true; }
            else { label10.Text = "���"; IsGruppoid = false; }

            if (fp.Associativity()) { label11.Text = "��"; IsPoluGruppa = true; IsLupa = true; }
            else { label11.Text = "���"; IsPoluGruppa = false; IsLupa = false; }

            if (fp.Associativity()) { label12.Text = "��"; IsAbelevaGruppa = true; }
            else { label12.Text = "���"; IsAbelevaGruppa = false; }

            if (fp.Idempotency()) { label13.Text = "��"; }
            else { label13.Text = "���"; }

            if (fp.NE() < univ.Count) { label14.Text = $"{fp.NE()}"; IsMonoid = true; IsLupa = true; }
            else { label14.Text = "���"; IsMonoid = false; IsLupa = false; }

            if (fp.Solvability()) { label15.Text = "��"; IsKvasiGruppa = true; IsGruppa = true; }
            else { label15.Text = "���"; IsKvasiGruppa = false; IsGruppa = false; }

            if (fp.Reversibility(fp.NE())) { label16.Text = "��"; }
            else { label16.Text = "���"; }

            //�������� �� ������
            if (IsGruppoid == true) 
            { 
                label17.Text = "��������"; 
            }
            
            //�������� �� ����������
            if ((IsPoluGruppa == true) && (IsGruppoid == true))
            {
                label17.Text = "��������, ����������";
            }
            else
            {
                IsPoluGruppa = false;
            }
            //�������� �� �����������
            if ((IsKvasiGruppa == true) && (IsGruppoid == true))
            {
                label17.Text = "��������, �����������";
            }
            else
            {
                IsKvasiGruppa = false;
            }
            //�������� �� ������
            if ((IsMonoid == true) && (IsPoluGruppa == true) && (fp.NE() < univ.Count))
            {
                label17.Text = "��������, ����������, ������";
            }
            else
            {
                IsMonoid = false;
            }
            //�������� �� ����
            if ((IsLupa == true) && (IsKvasiGruppa == true) && (fp.NE() < univ.Count))
            {
                label17.Text = "��������, �����������, ����";
            }
            else
            {
                IsLupa = false;
            }
            //�������� �� ������
            if (IsGruppa == true)
            {
                if (IsMonoid == true)
                {
                    label17.Text = "��������, ����������, ������, ������";
                }
                if (IsLupa == true)
                {
                    label17.Text = "��������, �����������, ����, ������";
                }
                else
                {
                    IsGruppa = false;
                }
            }
            else
            {
                IsGruppa = false;
            }
            //�������� �� ������� ������
            if ((IsAbelevaGruppa == true) && (IsGruppa == true))
            {
                if (IsMonoid == true)
                {
                    label17.Text = "��������, ����������, ������, ������, ������� ������";
                }
                if (IsLupa == true)
                {
                    label17.Text = "��������, �����������, ����, ������, ������� ������";
                }

            }
            else
            {
                IsAbelevaGruppa = false;
            }
        }
    }
}