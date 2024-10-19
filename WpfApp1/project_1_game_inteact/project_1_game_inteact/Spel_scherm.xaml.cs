﻿using System;
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
using System.Windows.Threading;
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

            Game left = new Game();
            Game right = new Game();
            left.Game_loop(LeftCanvas, true);
            right.Game_loop(RightCanvas, false);
            //string currentDirectory = Environment.CurrentDirectory;
            //MessageBox.Show($"Current Directory: {currentDirectory}");


            //this.Hide();
            //Upgrades upgradesWindow = new Upgrades();
            //upgradesWindow.Show();
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

    private RotateTransform car_rotation = new RotateTransform();

    //private double car_rotation = 0;
    private Canvas inner_canvas = new Canvas
    {
    Width = 80,
    Height = 50,
        #if DEBUG
        Background = Brushes.BlueViolet
#else
        Background = Brushes.Transparent 
#endif
    };
    private Image carImage;
    private Polygon terrain = new Polygon
    {
        Fill = Brushes.LawnGreen,
        Stroke = Brushes.Black,
        StrokeThickness = 1,
    };
    private Ellipse wheel_back = new Ellipse
        {
            Width = 3,
            Height = 3,
#if DEBUG
        Fill = Brushes.Red
#else
    Fill = Brushes.Transparent
#endif

    };
    private Ellipse wheel_front = new Ellipse
        {
            Width = 3,
            Height = 3,
#if DEBUG
        Fill = Brushes.Red
#else
    Fill = Brushes.Transparent
#endif
    };




    private double acceleration = 0.1;
    private double deceleration = 0.07;
    private double max_speed = 5;
    private double gravity = 0.00051; //0.01 is natural ish
    private bool is_touching_ground = false;
    private double terminal_velocity_car = 0.0015;

    private Vector wheel_front_position = new Vector(0, 0);
    private Vector wheel_back_position = new Vector(0, 0);



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
            Height = 40,
            Width = 80,
            Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
        };

        //Rectangle rectangle = new Rectangle();
        carImage.Height = 40;
        carImage.Width = 80;
        //rectangle.Fill = Brushes.Purple;



        inner_canvas.Children.Add(carImage);
        inner_canvas.Children.Add(wheel_back);
        inner_canvas.Children.Add(wheel_front);


        Canvas.SetLeft(wheel_back, 12);
        Canvas.SetTop(wheel_back, 33);
        Canvas.SetLeft(wheel_front, 80 - 12);
        Canvas.SetTop(wheel_front, 33);
        my_canvas.Children.Add(inner_canvas);

        //inner_canvas.RenderTransform = new RotateTransform(90, 0.2, 0.2);

        Canvas.SetLeft(inner_canvas, 125);
        Canvas.SetTop(inner_canvas, 250);

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
        //Console.WriteLine(X);
        X *= 0.02;
        double large_terrain = (Math.Sin(X * 0.3) + Math.Sin(X * 0.75 + 10) + Math.Sin(X * 1 + 486) + Math.Sin(X * 1.3 + 123) + Math.Sin(X * 1.5 + 7846)) / 5;
        double bumbs_terrain = 1 + 0.1 * (Math.Sin(X * 3 + 14416) * Math.Sin(X * 4 + 32));
        double result = 1.6 * large_terrain * bumbs_terrain;



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
            
            Gravity();

            //inner_canvas.RenderTransform = new RotateTransform(0, 0.5, 0.5);
            Update_canvas(The_canvas_being_used);
            collision(The_canvas_being_used );
            await Task.Delay(10);

        }
    }

    private void Update_canvas(Canvas The_canvas_being_used)
    {
        // Update the car's position on the canvas
        Canvas.SetTop(inner_canvas, car_position.Y);
        //Canvas.SetLeft(carImage, car_position.X);

        // Update the terrain's position on the canvas
        Point back_wheel_position = absolute_position_inside_canvas(The_canvas_being_used, wheel_back);


        Point front_wheel_position = absolute_position_inside_canvas(The_canvas_being_used, wheel_front);
        Canvas.SetLeft(terrain, -(car_position.X));
    }

    private Point absolute_position_inside_canvas(Canvas The_canvas_being_used, UIElement reference_object)
    {
        var transform = inner_canvas.RenderTransform;

        Point relative_point = new Point(Canvas.GetLeft(reference_object), Canvas.GetTop(reference_object));

        if (transform != null)
        {
            relative_point = transform.Transform(relative_point);
        }

        Point absolute_point = new Point(relative_point.X + Canvas.GetLeft(inner_canvas), relative_point.Y + Canvas.GetTop(inner_canvas));

        return absolute_point;
    }

    public void car_rotation_calc()
    {
   
    }
    public void collision(Canvas The_canvas_being_used)
    {
        
        Point gamma = absolute_position_inside_canvas(The_canvas_being_used, wheel_back);
        Point gamma2 = absolute_position_inside_canvas(The_canvas_being_used, wheel_front);

        bool back_wheel_collision = gamma.Y >= terrain_gen_function(gamma.X + car_position.X);
        bool front_wheel_collision = gamma2.Y >= terrain_gen_function(gamma2.X + car_position.X);

        if (back_wheel_collision || front_wheel_collision)
        {    
            
            is_touching_ground = true;
            car_position.Y = Math.Min(terrain_gen_function(gamma.X + car_position.X), terrain_gen_function(gamma2.X + car_position.X)) - carImage.Height;
            //carImage.RenderTransformOrigin = new Point(angle_gamma, angle_gamma2);
            
            double angle = Math.Tan(Math.Min(terrain_gen_function(gamma.X + car_position.X), terrain_gen_function(gamma2.X + car_position.X))) / 2;

            Console.WriteLine(angle);

            RotateTransform rotation_inner_canvas = new RotateTransform(angle / 2);
            carImage.RenderTransform = rotation_inner_canvas;
            inner_canvas.RenderTransform = rotation_inner_canvas;
                 
            
        }
        else
        {
            is_touching_ground = false;
           
        }
    }



    public void movement()
    {
        car_position += car_velocity;  
    }
    public void Gravity()
    {
        if (!is_touching_ground)
        {
            if (car_velocity.Y < terminal_velocity_car)
    {

            }
            car_velocity.Y += gravity;
        }
        else
        {
            car_velocity.Y = 0;
        }
    }
         
    private void forward_movement()
    {
        if (car_velocity.X < max_speed)
        {
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
