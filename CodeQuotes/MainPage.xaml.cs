
namespace CodeQuotes
{
    public partial class MainPage : ContentPage
    {
        Random random = new Random();                                                  // to generate random
        List<string> quotes = new List<string>();                                   // to read quotes 1 by 1

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            LoadMauiAsset();
        }
        async Task LoadMauiAsset()                                          // to load quotes.txt
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

           while(reader.Peek() != -1)
            {
                quotes.Add(reader.ReadLine());
            }
        }
        private void Btngetquotes_Clicked(object sender, EventArgs e)
        {
            var startpoint = System.Drawing.Color.FromArgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            var endpoint = System.Drawing.Color.FromArgb(
                random.Next(0, 256),
                random.Next(0, 256),
                random.Next(0, 256));

            var color = ColorUtility.ColorControls.GetColorGradient(startpoint,endpoint,6);             // to make gradient

            float stopoffset = .0f;
            var stops = new GradientStopCollection();
            foreach(var c in color) 
            {
                stops.Add(new GradientStop(Color.FromArgb(c.Name), stopoffset));
                stopoffset += 0.2f;
            }
            
            var gradient = new LinearGradientBrush(stops , new Point(0,0), new Point(1,1));
            background.Background = gradient;                                                       // to change background color

            int index = random.Next(stops.Count);
            quote.Text = quotes[index];                                                             // to generate random quotes
        }
    }
}