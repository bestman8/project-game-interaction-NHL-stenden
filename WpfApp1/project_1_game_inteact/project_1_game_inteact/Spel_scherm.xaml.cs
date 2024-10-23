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
using UItest;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using project_1_game_inteact;
//using static System.Net.Mime.MediaTypeNames;
//using static System.Net.Mime.MediaTypeNames;

namespace project_1_game_inteact
{
    static class game_timer_data
    {
        public static int tijd = 0;
    }

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
            BackgroundMusicPlayer.Instance.Play();
           
        }
#if DEBUG
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        #endif
        private void Upgrades_button_Click(object sender, RoutedEventArgs e)
        {
            Upgrades upgradesWindow = new Upgrades();
            upgradesWindow.Show();
            this.Close();
        }
        //Klok voor de countdown en timer
        private void Timer(object sender, EventArgs e)
        {

            if (Countdown <= 0 && Go == true)
            {
                LabelCountdown.Visibility = Visibility.Hidden;
                Label2Countdown.Visibility = Visibility.Hidden;
                tijd++;
                game_timer_data.tijd++;
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
            game_timer_data.tijd= 0;
            //create instances of game
            Game left = new Game();
            Game right = new Game();
            left.current_game_state.max_speed = SharedData.Instance.max_Speed1;      //change max speed of player 1
            left.current_game_state.acceleration = SharedData.Instance.acceleration1;   //change acceleration of player 1
            left.current_game_state.gravity = SharedData.Instance.gravity1;        //change gravity player 1
            left.current_game_state.deceleration = SharedData.Instance.deceleration1;

            right.current_game_state.max_speed = SharedData.Instance.max_Speed2;      //change max speed of player 2
            right.current_game_state.acceleration = SharedData.Instance.acceleration2;   //change acceleration of player 2
            right.current_game_state.gravity = SharedData.Instance.gravity2;
            left.current_game_state.deceleration = SharedData.Instance.deceleration2; //change gravity player 2

            //run game async and continue when both are done
            await Task.WhenAll(left.Game_loop(LeftCanvas, true), right.Game_loop(RightCanvas, false));

            Console.WriteLine("this should run after the game loop");
            Console.WriteLine("game timer left " + left.game_timer.Elapsed.ToString("mm\\:ss\\.ff"));
            Console.WriteLine("game timer right " + right.game_timer.Elapsed.ToString("mm\\:ss\\.ff"));

            double timesp1 = left.game_timer.Elapsed.TotalSeconds;
            double timesp2 = right.game_timer.Elapsed.TotalSeconds;
            //Console.WriteLine("this should run after the game loop");
            SharedData.Instance.time1[0] = timesp1;
            SharedData.Instance.time2[0] = timesp2;

            project_1_game_inteact.endscreen endscreen = new endscreen();
            endscreen.Show();
            this.Close();
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
    public class game_state
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


        public double acceleration = 0.1;
        public double deceleration = 0.07;
        public double max_speed = 5;
        public double gravity = 0.1; //0.01 is natural ish
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
            inner_canvas.Children.Add(center_point);


            Canvas.SetLeft(center_point, 40);
            Canvas.SetTop(center_point, 25);
            Canvas.SetLeft(wheel_back, 12);
            Canvas.SetTop(wheel_back, 33);
            Canvas.SetLeft(wheel_front, 80 - 15);
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
        public RotateTransform rotation_inner_canvas = new RotateTransform();
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

        /// <summary>
        /// the collision point for the front wheel
        /// </summary>
        public Ellipse center_point = new Ellipse
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
        private static double terrain_1(double X)
        {
            //Console.WriteLine(X);
            X *= 0.02;
            double large_terrain = (Math.Sin(X * 0.3) + Math.Sin(X * 0.75 + 10) + Math.Sin(X * 1 + 486) + Math.Sin(X * 1.3 + 123) + Math.Sin(X * 1.5 + 7846)) / 5;
            double bumbs_terrain = 1 + 0.1 * (Math.Sin(X * 3 + 14416) * Math.Sin(X * 4 + 32));
            double result = 1.6 * large_terrain * bumbs_terrain;


            return 50 * result + 400;
        }
        private static double terrain_2(double X)
        {
            X *= 0.02;
            double large_terrain = (Math.Sin(X * 0.8) + Math.Sin(X * 0.90 + 10) + Math.Sin(X * 1 + 500) + Math.Sin(X * 1.7 + 199) + Math.Sin(X * 1.4 + 8111)) / 5;
            double bumbs_terrain = 1 + 0.1 * (Math.Sin(X * 3 + 14416) * Math.Sin(X * 3 + 30));
            double result = 1.8 * large_terrain * bumbs_terrain;


            return 50 * result + 400;
        }
        private static double terrain_3(double X)
        {
            X *= 0.02;
            double large_terrain = (Math.Sin(X * 0.7) + Math.Sin(X * 0.58 + 10) + Math.Sin(X * 1 + 1000) + Math.Sin(X * 1.5 + 273) + Math.Sin(X * 1.7 + 8646)) / 5;
            double bumbs_terrain = 1 + 0.2 * (Math.Sin(X * 3 + 18656) * Math.Sin(X * 6 + 46));
            double result = 1.6 * large_terrain * bumbs_terrain;


            return 50 * result + 400;
        }
        private static double terrain_4(double X)
        {
            X *= 0.02;
            double large_terrain = (Math.Sin(X * 0.6) + Math.Sin(X * 0.96 + 15) + Math.Sin(X * 1 + 786) + Math.Sin(X * 1.6 + 423) + Math.Sin(X * 1.9 + 9000)) / 5;
            double bumbs_terrain = 1 + 0.3 * (Math.Sin(X * 3 + 17856) * Math.Sin(X * 4 + 60));
            double result = 1.6 * large_terrain * bumbs_terrain;


            return 50 * result + 400;
        }

        public static double terrain_gen_function(double X)
        {
            switch (SharedData.Instance.levels)
            {
                case (0):
                    return terrain_1(X);
                case (1):
                    return terrain_2(X);
                case (2):
                    return terrain_3(X);
                case (3):
                    return terrain_4(X);
                default: return 0;

            }
        }

        public static void terrain_gen(Game_objects game_object)
        {
            PointCollection terrain_points = new PointCollection();

            terrain_points.Add(new Point(-500, 1200));
            for (int x = -500; x < 8000; x+=3)
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
                rel_movement.X += Math.Cos(helper.degree_to_rad(game_State.actual_rotation - 25)) * 1.2 * game_State.acceleration;

            }
            game_State.car_velocity_abs = helper.rel_movement_to_abs_movement(rel_movement, game_State.actual_rotation);
        }
        private static void backward_movement(game_state game_State)
        {
            Vector rel_movement = helper.abs_movement_rel_movement(game_State.car_velocity_abs, game_State.actual_rotation);

            if (rel_movement.X > -game_State.max_speed)
            {
                rel_movement.X -= Math.Cos(helper.degree_to_rad(game_State.actual_rotation+25))*1.2 * game_State.acceleration;
            }
            game_State.car_velocity_abs = helper.rel_movement_to_abs_movement(rel_movement, game_State.actual_rotation);

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
            game_State.car_velocity_abs = helper.rel_movement_to_abs_movement(rel_movement, game_State.actual_rotation);

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
        public static Vector difference_distance_between_points(UIElement from, UIElement to)
        {
            double x1 = Canvas.GetLeft(from);
            double x2 = Canvas.GetLeft(to);
            double y1 = Canvas.GetTop(from);
            double y2 = Canvas.GetTop(to);

            double dx = x1 - x2;
            double dy = y1 - y2;

            return new Vector(dx, dy);
        }
        public static double pythagoras(Vector difference)
        {
            return Math.Sqrt(Math.Pow(difference.X, 2) + Math.Pow(difference.Y, 2));
        }

        public static Vector abs_movement_rel_movement(Vector abs_movement, double rotation_angle)
        {
            Vector relative_movement = new Vector();
            double rad = degree_to_rad(rotation_angle);
            relative_movement.X = abs_movement.X * Math.Cos(rad) + abs_movement.Y * Math.Sin(rad);
            relative_movement.Y = -abs_movement.X * Math.Sin(rad) + abs_movement.Y * Math.Cos(rad);
            return relative_movement;
        }

        public static Vector rel_movement_to_abs_movement(Vector rel_movement, double rotation_angle)
        {
            Vector absolute_movement = new Vector();
            double rad = degree_to_rad(rotation_angle);
            absolute_movement.X = rel_movement.X * Math.Cos(rad) - rel_movement.Y * Math.Sin(rad);
            absolute_movement.Y = rel_movement.X * Math.Sin(rad) + rel_movement.Y * Math.Cos(rad);
            return absolute_movement;
        }

        public static Point absolute_position_inside_canvas(Game_objects Game_objects, UIElement reference_object)
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


    }

    private static class physics
    {





        private static double collision_depth(Game_objects Game_objects, UIElement reference_object, game_state game_State)
        {
            Point location = helper.absolute_position_inside_canvas(Game_objects, reference_object);

            return location.Y - Terrain_methods.terrain_gen_function(location.X + game_State.car_position.X);
        }

        private static void solve_collision(game_state game_State, Game_objects game_Objects, double collision_depth, bool front_or_back, double collision_depth_other)
        {
            // Adjust the car's position based on the collision depth

            
            if (front_or_back)
            {
                // Collision with the front wheel
                // Move the car back by the collision depth
                game_State.car_position.Y -= collision_depth; // Move up to resolve collision
                game_State.car_velocity_abs.Y = 0; // Stop vertical movement
                game_State.is_touching_ground = true; // Assume it is touching ground after collision

                if (collision_depth_other < -1)
                {
                    double distance_from_wheel_to_center = helper.pythagoras( helper.difference_distance_between_points(game_Objects.wheel_front,game_Objects.center_point));

                    helper.difference_distance_between_points(game_Objects.wheel_front, game_Objects.wheel_back);
                    game_State.actual_rotation -= 8;
                    //game_State.car_position.X += distance_from_wheel_to_center * Math.Cos(helper.degree_to_rad(-2)); 
                    //game_State.car_position.Y += distance_from_wheel_to_center * Math.Sin(helper.degree_to_rad(-2));

                }
            }
            else
            {
                // Collision with the back wheel
                // Move the car back by the collision depth
                game_State.car_position.Y -= collision_depth; // Move up to resolve collision
                game_State.car_velocity_abs.Y = 0; // Stop vertical movement
                game_State.is_touching_ground = true; // Assume it is touching ground after collision

                if (collision_depth_other < -1)
                {
                    double distance_from_wheel_to_center = helper.pythagoras(helper.difference_distance_between_points(game_Objects.wheel_back, game_Objects.center_point));

                    helper.difference_distance_between_points(game_Objects.wheel_front, game_Objects.wheel_back);
                    game_State.actual_rotation += 2;
                    //game_State.car_position.X += distance_from_wheel_to_center * Math.Cos(helper.degree_to_rad(2));
                    //game_State.car_position.Y += distance_from_wheel_to_center * Math.Sin(helper.degree_to_rad(2));


                }
            }
        }

        //movement
        public static void movement(game_state game_State, Game_objects game_objects)
        {
            //game_State.car_velocity_abs = helper.rel_movement_to_abs_movent(game_State.car_velocity_rel, game_State.actual_rotation);ññ
            Movement.slow_down(game_State);
            Gravity(game_State);
            game_State.car_position += game_State.car_velocity_abs;

            double collision_depth_front = collision_depth(game_objects, game_objects.wheel_front, game_State);
            double collision_depth_back = collision_depth(game_objects, game_objects.wheel_back, game_State);
            if (collision_depth_front > 0 || collision_depth_back >0)
            {
                game_State.is_touching_ground = true ;
                bool front_or_back;
                double collision_depth_other =0;
                double largest_collision_depth;
                if (collision_depth_front >= collision_depth_back)
                {
                    largest_collision_depth=collision_depth_front;
                    collision_depth_other=collision_depth_back;
                    front_or_back = true;
                }
                else
                {
                    largest_collision_depth = collision_depth_back;
                    collision_depth_other = collision_depth_front;

                    front_or_back = false;
                }

                solve_collision(game_State, game_objects, largest_collision_depth, front_or_back, collision_depth_other);
            }else
            {
                game_State.is_touching_ground=false ;
            }




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

    public game_state current_game_state = new game_state();
    public Stopwatch game_timer = new Stopwatch();
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


    //game_loop
    public async Task Game_loop(Canvas main_canvas, bool WASDorARROW)
    {
        game_init_state(main_canvas);
        game_timer.Start();
        Update_canvas();
        while (game_timer_data.tijd == 0) { 
            await Task.Delay(10);
        }
        while (true)
        {
            
            Movement.keyboard_input(WASDorARROW, current_game_state);
            physics.movement(current_game_state, game_objects); //will be physics and it cannot update any objects
            Update_canvas(); //updates all objects
            await Task.Delay(10);
            if (current_game_state.car_position.X>5000) {break; }
        }
        game_timer.Stop();
    }

    private void Update_canvas()
    {
        // Update the car's position on the canvas
        game_objects.rotation_inner_canvas.Angle = current_game_state.actual_rotation;
        game_objects.inner_canvas.RenderTransform = game_objects.rotation_inner_canvas;
        Canvas.SetTop(game_objects.inner_canvas, current_game_state.car_position.Y);
        //Canvas.SetLeft(carImage, car_position.X);

        // Update the terrain's position on the canvas
        Canvas.SetLeft(game_objects.terrain, -(current_game_state.car_position.X));
    }


}

