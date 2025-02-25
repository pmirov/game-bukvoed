namespace WinFormsApp12
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game();
            foreach (var item in game.ListButton)
            {
                Controls.Add(item);
                item.Click += Item_Click;

            }
        }

        private Button firstButton = null;
        private void Item_Click(object? sender, EventArgs e)
        {

            Button? x = (Button?)sender;
            if (firstButton == null)
            {
                firstButton = x;
                return;
            }
            if (firstButton.Text != x.Text)
            {
                string temp = x.Text;
                x.Text = firstButton.Text;
                firstButton.Text = temp;
                game.Check(x.Text);
            }

            firstButton = null;
            
        }
    }
        
}

