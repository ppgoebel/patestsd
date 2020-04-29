using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pa6_ppgoebel
{
    public partial class frmMain : Form
    {
        string cwid;
        List<Book> myBooks;
        public frmMain(string cwid)
        {
            this.cwid = cwid;
            InitializeComponent();
            pbCover.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadList();
        }
        private void LoadList()
        {
            myBooks = BookDatabase.GetAllBooks(cwid);
            lstBooks.DataSource = myBooks;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies--;
            BookDatabase.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;
            frmEdit myForm = new frmEdit(myBook,cwid,"edit");
            if(myForm.ShowDialog()==DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }

        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            myBook.copies++;
            BookDatabase.SaveBook(myBook, cwid, "edit");
            LoadList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            txtTitleData.Text = myBook.title;
            txtAuthorData.Text = myBook.author;
            txtGenreData.Text = myBook.genre;
            txtCopiesData.Text = myBook.copies.ToString();
            txtLengthData.Text = myBook.length.ToString();
            txtISBNData.Text = myBook.isbn;

            try
            {
                pbCover.Load(myBook.cover);
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Book myBook = (Book)lstBooks.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete?","Delete",MessageBoxButtons.YesNo);

            if(dialogResult==DialogResult.Yes)
            {
                BookDatabase.DeleteBook(myBook, cwid);
            }

            LoadList();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Book myBook = new Book();
            frmEdit myForm = new frmEdit(myBook, cwid, "new");
            if (myForm.ShowDialog() == DialogResult.OK)
            {

            }
            else
            {
                LoadList();
            }
        }
    }
}
