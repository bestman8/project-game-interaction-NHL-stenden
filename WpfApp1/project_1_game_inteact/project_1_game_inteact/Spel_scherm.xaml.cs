using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//using static System.Net.Mime.MediaTypeNames;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for Spel_scherm.xaml
    /// </summary>
    public partial class Spel_scherm : Window
    {
        public Spel_scherm()
        {
            InitializeComponent();
            //[System.Runtime.InteropServices.DllImport("kernel32.dll")]
            #if DEBUG
            AllocConsole();
            #endif
            //AllocConsole();
        }
        #if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        #endif
        private async void Upgrades_button_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide();
            //Upgrades upgradesWindow = new Upgrades();
            //upgradesWindow.Show();

            Game left = new Game();
            Game right = new Game();
            left.Game_loop(LeftCanvas, true);
            right.Game_loop(RightCanvas, false);
            string currentDirectory = Environment.CurrentDirectory;
            MessageBox.Show($"Current Directory: {currentDirectory}");
        }

        private void Startscherm_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UItest.MainWindow secondWindow = new UItest.MainWindow();
            secondWindow.Show();
            this.Close();

        }

        private void Levels_button_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();


            UItest.levels secondWindow = new UItest.levels();
            secondWindow.Show();
            this.Close();

        }


    }


}
public class Game
{
    private Vector car_position = new Vector(25, 250); // Relative position of the car
    private Vector car_velocity = new Vector(0, 0);
    private Vector background_position = new Vector();
    private double car_rotation = 0;
    private Image carImage;
    private double acceleration = 0.1;
    private double deceleration = 0.07;
    private double max_speed = 5;

    /// <summary>
    /// Initialize the game
    /// </summary>
    /// <param name="my_canvas">this is the canvas you input to the function</param>
    void game_init_state(Canvas my_canvas)
    {
        my_canvas.Children.Clear(); //clear the canvas from everything

        string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, "resources", "images", "car-full.png");
        carImage = new Image
        {
            Height = 80,
            Width = 80,
            Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)) // Absolute path constructed from current directory
        };

        //Rectangle rectangle = new Rectangle();
        carImage.Height = 80;
        carImage.Width = 80;
        //rectangle.Fill = Brushes.Purple;

        my_canvas.Children.Add(carImage);
        //Canvas.SetTop(carImage, 500);
        //Canvas.SetLeft(carImage, 200);
    }

    private int terrain_gen_function(int X)
    {
        return X;
    }
    private void terrain_gen()
    {

    }
    public async Task Game_loop(Canvas The_canvas_being_used, bool WASDorARROW)
    {
        game_init_state(The_canvas_being_used);

        while (true)
        {
            keyboard_input(WASDorARROW);
            movement();
            slow_down();
            Update_canvas(The_canvas_being_used);
            await Task.Delay(10);
        }
    }

    private void Update_canvas(Canvas The_canvas_being_used)
    {
        Canvas.SetTop(carImage, car_position.Y);
        Canvas.SetLeft(carImage, car_position.X);
        // update car position
    }

    public void collision()
    {
        // Collision logic can be added here
    }

    public void movement()
    {
        car_position += car_velocity;
    }

    public void gravity()
    {

    }

    private void forward_movement()
    {
        if (car_velocity.X < max_speed){
        car_velocity.X += acceleration;

        }
    }
    private void backward_movement()
    {
        if (car_velocity.X > -max_speed)
        {
            car_velocity.X -= acceleration;
        }

    }
    private void up_ward_movement()
    {

    }
    private void down_ward_movement()
    {

    }
    private void slow_down()
    { 
        if (car_velocity.X > 0)
        {
            car_velocity.X -= deceleration;
            if (car_velocity.X < 0) car_velocity.X = 0;
        }
        else if (car_velocity.X < 0)
        {
            car_velocity.X += deceleration;
            if (car_velocity.X > 0) car_velocity.X = 0; 
        }
    }

    /// <summary>
    /// does the keyboard_input 
    /// </summary>
    /// <param name="WASDorARROW">true does WASD False does Arrow</param>
    private void keyboard_input(bool WASDorARROW)
    {
        if (WASDorARROW)
        {

            if (Keyboard.IsKeyDown(Key.Up))
            {
                up_ward_movement();
            }
            if (Keyboard.IsKeyDown(Key.Down))
            {
                down_ward_movement();

            } 
            if (Keyboard.IsKeyDown(Key.Right))
                forward_movement();
            {
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                backward_movement();
            }
        }
         else
        {
            if (Keyboard.IsKeyDown(Key.W))
            {
                up_ward_movement();
            }
            if (Keyboard.IsKeyDown(Key.S))
            {
                down_ward_movement();
            }
            if (Keyboard.IsKeyDown(Key.A))
            {
                backward_movement();
            }
            if (Keyboard.IsKeyDown(Key.D))
            {
                forward_movement();
            }
            }


            // Movement logic can be added here if needed
        }
    }
