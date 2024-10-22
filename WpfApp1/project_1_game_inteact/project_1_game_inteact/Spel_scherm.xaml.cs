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
using static project_1_game_inteact.start;
using System.Windows.Threading;
using System.Diagnostics;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Net.Mime.MediaTypeNames;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for Spel_scherm.xaml
    /// </summary>
    public partial class Spel_scherm : Window
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private int tijd = 0;
        int Countdown = 5;
        bool Go = false;
        public Spel_scherm()
        {
            InitializeComponent();
            //[System.Runtime.InteropServices.DllImport("kernel32.dll")]
#if DEBUG
            AllocConsole();
#endif
            //AllocConsole();
            Speler_naam_1.Content = SharedData.Instance.Naam1;
            Speler_naam_2.Content = SharedData.Instance.Naam2;
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += Timer;
            gameTimer.Start();

        }
#if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        #endif
        private async void Upgrades_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Upgrades upgradesWindow = new Upgrades();
            upgradesWindow.Show();
        }
        //Klok voor de countdown en timer
        private void Timer(object sender, EventArgs e)
        {

            if (Countdown <= 0 && Go == true)
            {
                LabelCountdown.Visibility = Visibility.Hidden;
                Label2Countdown.Visibility = Visibility.Hidden;
                tijd++;
                int minuten = tijd / 60;
                int seconden = tijd % 60;
                string Minuten = Convert.ToString(minuten);
                string Seconden = Convert.ToString(seconden);
                GlobalTimer.Content = Minuten + ":" + Seconden;
            }
            else if (Go == true)
            {

                LabelCountdown.Content = Countdown.ToString();
                Label2Countdown.Content = Countdown.ToString();
                --Countdown;

            }
            
        }
        //knop om de countdown en timer te starten
        private async void StartCountdown_Click(object sender, RoutedEventArgs e)
        {
            StartCountdown.Visibility = Visibility.Hidden;

            Go = true;

            Game left = new Game();
            Game right = new Game();

            await left.Game_loop(LeftCanvas, true);
            await right.Game_loop(RightCanvas, false);

            Stopwatch leftsw = left.sw;
            Stopwatch rightsw = right.sw;

            if (!leftsw.IsRunning && !rightsw.IsRunning)
            {
                SharedData.Instance.time1 = new double[] { leftsw.Elapsed.Seconds };
                SharedData.Instance.time2 = new double[] { rightsw.Elapsed.Seconds };               
                project_1_game_inteact.endscreen test = new project_1_game_inteact.endscreen();
                test.Show();
            }
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
    private class game_state
    {
        /// <summary>
        /// the position of the car from the terrain
        /// </summary>
        public Point car_position = new Point(0, 250); // absolute position of the car
        /// <summary>
        /// current speed of the car X,Y relative to car
        /// </summary>
        public Vector car_velocity_rel = new Vector(0, 0);
        public Vector car_velocity_abs = new Vector(0, 0);

        //car rotation 
        //public double car_rotation_speed = 0;
        public double actual_rotation = 0;
        private Vector wheel_front_position = new Vector(0, 0);
        private Vector wheel_back_position = new Vector(0, 0);

        public bool is_touching_ground = false;


        public double acceleration = SharedData.Instance.max_Speed;
        public double deceleration = 0.07;
        public double max_speed = 5;
        public double gravity = SharedData.Instance.gravity; //0.01 is natural ish
        public double terminal_velocity_car = 10;
    }

    private class Game_objects
    {
        /// <summary>
        /// this is the max speed that the car can fall doww
        /// </summary>
        //the canvas from the car
        /// <summary>
        /// inner_canvas is the canvas that contains the car
        /// </summary>
        /// 
        public Canvas Main_canvas;

        public void init(Canvas main_canvas)
        {
            Main_canvas = main_canvas;

            string imagePath = System.IO.Path.Combine(Environment.CurrentDirectory, "resources", "images", "car-full.png");
            carImage = new Image
            {
                Height = 40,
                Width = 80,
                Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
            };
            carImage.Height = 40;
            carImage.Width = 80;


            // initing the inner_canvas with the elements like car_image and the collision points
            inner_canvas.Children.Add(carImage);
            inner_canvas.Children.Add(wheel_back);
            inner_canvas.Children.Add(wheel_front);

            Canvas.SetLeft(wheel_back, 12);
            Canvas.SetTop(wheel_back, 33);
            Canvas.SetLeft(wheel_front, 80 - 12);
            Canvas.SetTop(wheel_front, 33);
            Main_canvas.Children.Add(inner_canvas);

            Canvas.SetLeft(inner_canvas, 125);
            Canvas.SetTop(inner_canvas, 250);


        }
        public Canvas inner_canvas = new Canvas
        {
            Width = 80,
            Height = 50,
#if DEBUG
            Background = Brushes.BlueViolet
#else
            Background = Brushes.Transparent 
#endif
        };
        public Image carImage;
        public Polygon terrain = new Polygon
        {
            Fill = Brushes.LawnGreen,
            Stroke = Brushes.Black,
            StrokeThickness = 1,
        };
        /// <summary>
        /// the collision point for the back wheel
        /// </summary>
        public Ellipse wheel_back = new Ellipse
        {
            Width = 3,
            Height = 3,
#if DEBUG
            Fill = Brushes.Red
#else
        Fill = Brushes.Transparent
#endif

        };
        /// <summary>
        /// the collision point for the front wheel
        /// </summary>
        public Ellipse wheel_front = new Ellipse
        {
            Width = 3,
            Height = 3,
#if DEBUG
            Fill = Brushes.Red
#else
        Fill = Brushes.Transparent
#endif
        };


    }

    private static class Terrain_methods
    {
        public static double terrain_gen_function(double X)
        {
            //Console.WriteLine(X);
            X *= 0.02;
            double large_terrain = (Math.Sin(X * 0.3) + Math.Sin(X * 0.75 + 10) + Math.Sin(X * 1 + 486) + Math.Sin(X * 1.3 + 123) + Math.Sin(X * 1.5 + 7846)) / 5;
            double bumbs_terrain = 1 + 0.1 * (Math.Sin(X * 3 + 14416) * Math.Sin(X * 4 + 32));
            double result = 1.6 * large_terrain;



            return 50 * result + 400;
        }

        public static void terrain_gen(Game_objects game_object)
        {
            PointCollection terrain_points = new PointCollection();

            terrain_points.Add(new Point(-500, 1200));
            for (int x = -500; x < 8000; x++)
            {
                //terrain_points.Add(new Point(x, 50 * terrain_gen_function(x * 0.02) + 350));
                terrain_points.Add(new Point(x, terrain_gen_function(x)));

            }
            terrain_points.Add(new Point(8000, 1200));

            game_object.terrain.Points = terrain_points;
            game_object.Main_canvas.Children.Add(game_object.terrain);
        }

    }

    private static class Movement
    {

        private static void forward_movement(game_state game_State)
        {
            Vector rel_movement = helper.abs_movement_rel_movement(game_State.car_velocity_abs, game_State.actual_rotation);

            if (rel_movement.X < game_State.max_speed)
            {
                rel_movement.X += game_State.acceleration;
            }

            game_State.car_velocity_abs = helper.rel_movement_to_abs_movent(rel_movement, game_State.actual_rotation);
        }
        private static void backward_movement(game_state game_State)
        {
            Vector rel_movement = helper.abs_movement_rel_movement(game_State.car_velocity_abs, game_State.actual_rotation);

            if (rel_movement.X > -game_State.max_speed)
            {
                rel_movement.X -= game_State.acceleration;
            }
            game_State.car_velocity_abs = helper.rel_movement_to_abs_movent(rel_movement, game_State.actual_rotation);

        }
        private static void up_ward_movement(game_state game_State)
        {

        }
        private static void down_ward_movement(game_state game_State)
        {

        }
        public static void slow_down(game_state game_State)
        {
            Vector rel_movement = helper.abs_movement_rel_movement(game_State.car_velocity_abs, game_State.actual_rotation);

            if (rel_movement.X > 0)
            {
                rel_movement.X -= game_State.deceleration;
                if (rel_movement.X < 0) rel_movement.X = 0;
            }
            else if (rel_movement.X < 0)
            {
                rel_movement.X += game_State.deceleration;
                if (rel_movement.X > 0) rel_movement.X = 0;
            }
            game_State.car_velocity_abs = helper.rel_movement_to_abs_movent(rel_movement, game_State.actual_rotation);

        }

        /// <summary>
        /// does the keyboard_input 
        /// </summary>
        /// <param name="WASDorARROW">true does WASD False does Arrow</param>
        public static void keyboard_input(bool WASDorARROW, game_state game_State)
        {
            if (WASDorARROW)
            {

                if (Keyboard.IsKeyDown(Key.Up))
                {
                    up_ward_movement(game_State);

                }
                if (Keyboard.IsKeyDown(Key.Down))
                {
                    down_ward_movement(game_State);

                }
                if (Keyboard.IsKeyDown(Key.Right))
                    forward_movement(game_State);
                {
                }
                if (Keyboard.IsKeyDown(Key.Left))
                {
                    backward_movement(game_State);
                }
            }
            else
            {
                if (Keyboard.IsKeyDown(Key.W))
                {
                    up_ward_movement(game_State);
                }
                if (Keyboard.IsKeyDown(Key.S))
                {
                    down_ward_movement(game_State);
                }
                if (Keyboard.IsKeyDown(Key.A))
                {
                    backward_movement(game_State);
                }
                if (Keyboard.IsKeyDown(Key.D))
                {
                    forward_movement(game_State);
                }
            }
        }

    }
    private static class helper
    {
        public static double rad_to_degree(double radians)
        {
            return radians * (180.0 / Math.PI);
        }
        public static double degree_to_rad(double degree)
        {
            return degree * (Math.PI / 180);
        }

        public static Vector abs_movement_rel_movement(Vector abs_movement, double rotation_angle)
        {
            Vector relative_movement = new Vector();
            double degree = degree_to_rad(rotation_angle);
            relative_movement.X = abs_movement.X * Math.Cos(-degree_to_rad(rotation_angle)) - abs_movement.Y * Math.Sin(-degree_to_rad(rotation_angle));
            relative_movement.Y = abs_movement.X * Math.Sin(-degree_to_rad(rotation_angle)) + abs_movement.Y * Math.Cos(-degree_to_rad(rotation_angle));
            return relative_movement;
        }
        public static Vector rel_movement_to_abs_movent(Vector rel_movement, double rotation_angle)
        {
            Vector absolute_movement = new Vector();
            double rad = degree_to_rad(rotation_angle);
            absolute_movement.X = rel_movement.X * Math.Cos(rad) - rel_movement.Y * Math.Sin(rad);
            absolute_movement.Y = rel_movement.X * Math.Sin(rad) + rel_movement.Y * Math.Cos(rad);
            return absolute_movement;
        }

    }

    private static class physics
    {
        //collision
        private static Point absolute_position_inside_canvas(Game_objects Game_objects, UIElement reference_object)
        {
            var transform = Game_objects.inner_canvas.RenderTransform;

            Point relative_point = new Point(Canvas.GetLeft(reference_object), Canvas.GetTop(reference_object));

            if (transform != null)
            {
                relative_point = transform.Transform(relative_point);
            }

            Point absolute_point = new Point(relative_point.X + Canvas.GetLeft(Game_objects.inner_canvas), relative_point.Y + Canvas.GetTop(Game_objects.inner_canvas));

            return absolute_point;
        }

        public static void car_rotation_calc(Game_objects Game_objects, game_state game_State)
        {
            Point absolute_position_wheel_back = absolute_position_inside_canvas(Game_objects, Game_objects.wheel_back);
            Point absolute_position_wheel_front = absolute_position_inside_canvas(Game_objects, Game_objects.wheel_front);
            game_State.actual_rotation = Math.Atan2(absolute_position_wheel_back.Y - absolute_position_wheel_front.Y, absolute_position_wheel_back.X - absolute_position_wheel_front.X);

           
#if DEBUG
            Console.WriteLine(game_State.actual_rotation);
#endif
        }

        private static double collision_depth(Game_objects Game_objects, UIElement reference_object, game_state game_State)
        {
            Point location = absolute_position_inside_canvas(Game_objects, Game_objects.wheel_back);

            return location.Y - Terrain_methods.terrain_gen_function(location.X + game_State.car_position.X);
        }

        public static void collision(Game_objects Game_objects, game_state game_State)
        {

            Point absolute_position_wheel_back = absolute_position_inside_canvas(Game_objects, Game_objects.wheel_back);
            Point absolute_position_wheel_front = absolute_position_inside_canvas(Game_objects, Game_objects.wheel_front);

            bool back_wheel_collision = absolute_position_wheel_back.Y >= Terrain_methods.terrain_gen_function(absolute_position_wheel_back.X + game_State.car_position.X);
            bool front_wheel_collision = absolute_position_wheel_front.Y >= Terrain_methods.terrain_gen_function(absolute_position_wheel_front.X + game_State.car_position.X);

            if (back_wheel_collision || front_wheel_collision)
            {

                game_State.car_position.Y = Math.Min(Terrain_methods.terrain_gen_function(absolute_position_wheel_back.X + game_State.car_position.X), Terrain_methods.terrain_gen_function(absolute_position_wheel_front.X + game_State.car_position.X)) - Game_objects.carImage.Height + 10;
                game_State.is_touching_ground = true;
             
            }
            else
            {
                game_State.is_touching_ground = false;

            }
        }

        //movement
        public static void movement(game_state game_State, Game_objects game_objects)
        {
            //game_State.car_velocity_abs = helper.rel_movement_to_abs_movent(game_State.car_velocity_rel, game_State.actual_rotation);ññ
            Movement.slow_down(game_State);
            Gravity(game_State);
            game_State.car_position += game_State.car_velocity_abs;



            //Movement.slow_down(current_game_state);

        }



        private static void Gravity(game_state game_State)
        {
            if (!game_State.is_touching_ground)
            {
                if (game_State.car_velocity_abs.Y < game_State.terminal_velocity_car)
                {

                    game_State.car_velocity_abs.Y += game_State.gravity;
                }
            }
            else
            {
                game_State.car_velocity_abs.Y = 0;
            }
        }

    }

    game_state current_game_state = new game_state();
    Game_objects game_objects = new Game_objects();

    /// <summary>
    /// Initialize the game
    /// </summary>
    /// <param name="my_canvas">this is the canvas you input to the function</param>
    void game_init_state(Canvas main_canvas)
    {
        main_canvas.Children.Clear(); //clear the canvas from everything
        game_objects.init(main_canvas);
        Terrain_methods.terrain_gen(game_objects);
        //Gam.Children.Add(game_objects.terrain);

    }


    public Stopwatch sw = new Stopwatch();
    //game_loop
    public async Task Game_loop(Canvas main_canvas, bool WASDorARROW)
    {
        sw.Start();
        game_init_state(main_canvas);

        //sw = Stopwatch.StartNew();
     ;
        while (true)
        {
            // Handle keyboard input
            Movement.keyboard_input(WASDorARROW, current_game_state);

            // Apply physics
            physics.movement(current_game_state, game_objects);
            physics.car_rotation_calc(game_objects, current_game_state);
            physics.collision(game_objects, current_game_state);

            // Update canvas
            Update_canvas();

            if (current_game_state.car_position.X > 2000)
            {
      
          
                break;
            }
          
            await Task.Delay(10);
        }
        sw.Stop();
        Label end_screen = new Label
        {
            Content = string.Format("your time is \n{0}", sw.Elapsed.ToString("mm\\:ss\\.ff")),
            FontSize = 50
        };
        main_canvas.Children.Add(end_screen);
        Canvas.SetLeft(end_screen, 50);
        Canvas.SetTop(end_screen, 50);
    }

    private void Update_canvas()
    {
        // Update the car's position on the canvas
        Canvas.SetTop(game_objects.inner_canvas, current_game_state.car_position.Y);
        //Canvas.SetLeft(carImage, car_position.X);

        // Update the terrain's position on the canvas
        Canvas.SetLeft(game_objects.terrain, -(current_game_state.car_position.X));
    }


}

