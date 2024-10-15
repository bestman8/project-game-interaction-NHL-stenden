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
    private Vector car_position = new Vector(0, 250); // Relative position of the car
    private Vector car_velocity = new Vector(0, 0);
    private Vector background_position = new Vector();
    private double car_rotation = 0;
    private Image carImage;
    private Polygon terrain = new Polygon
    {
        Fill = Brushes.LawnGreen,
        Stroke = Brushes.Black,
        StrokeThickness = 1,
    };

    private double acceleration = 0.1;
    private double deceleration = 0.07;
    private double max_speed = 5;
    private double gravity = 0;

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
            Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
        };

        //Rectangle rectangle = new Rectangle();
        carImage.Height = 80;
        carImage.Width = 80;
        //rectangle.Fill = Brushes.Purple;

        my_canvas.Children.Add(carImage);
        terrain_gen();
        my_canvas.Children.Add(terrain);

    }
    /// <summary>
    /// this is a function and what it returns is the Y value for the x at that location
    /// </summary>
    /// <param name="X">a value between 0 left and 500 right</param>
    /// <returns>y 0 assume 0 is the bottom and 250 is the max range it should be</returns>
    private double terrain_gen_function(double X)
    {
        X *= 0.02;
        double large_terrain = (Math.Sin(X* 0.3)+Math.Sin(X*0.75+10)+Math.Sin(X*1 +486)+ Math.Sin(X*1.3+123) + Math.Sin(X*1.5 +7846))/5;
        double bumbs_terrain = 1+0.1*(Math.Sin(X*3+14416)*Math.Sin(X*4+32));
        double result = 1.6*large_terrain*bumbs_terrain;

        return 50 * result + 400;
    }

    private void terrain_gen()
    {
        PointCollection terrain_points = new PointCollection();

        terrain_points.Add(new Point(-500, 1200));
        for (int x = -500; x < 2000; x++)
        {
            //terrain_points.Add(new Point(x, 50 * terrain_gen_function(x * 0.02) + 350));
            terrain_points.Add(new Point(x, terrain_gen_function(x)));

        }
        terrain_points.Add(new Point(2000, 1200));

        terrain.Points = terrain_points;

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
            gravity_func();
            await Task.Delay(10);

        }
    }

    private void Update_canvas(Canvas The_canvas_being_used)
    {
        // Update the car's position on the canvas
        Canvas.SetTop(carImage, car_position.Y);
        //Canvas.SetLeft(carImage, car_position.X);

        // Update the terrain's position on the canvas
        Canvas.SetLeft(terrain, -(car_position.X - background_position.X));
    }

    public void collision(double X)
    {
        Rect imageBounds = new Rect(Canvas.GetLeft(carImage), Canvas.GetTop(carImage), carImage.ActualWidth, carImage.ActualHeight);
        // Collision logic can be added here

    }
    public void movement()
    {
        car_position += car_velocity;
      
   
    }
    public void gravity_func()
    {
        car_position.Y += gravity;
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
