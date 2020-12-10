﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HospitalMap.Code.Model.Canvas;
using HospitalMap.Code.Repository.RectangleRepository;
using HospitalMap.Code.Repository;
using HospitalMap.WPF;
using HospitalMap.Repository;
using HospitalMap.WPF.ModelWPF;
using HospitalMap.Code.Model;
using HospitalMap.Code.Repository.RoomInformatioRepository;
using HospitalMap.Code.Repository.DoctorsRepository;

namespace HospitalMap.WPF
{
    /// <summary>
    /// Interaction logic for prizemlje.xaml
    /// </summary>
    public partial class GroundFloor2 : Window
    {

        public Rectangle Dinamicly = new Rectangle();
        public ObservableCollection<Rectangles> Rectangle { get; set; }
        public ObservableCollection<DoctorRoomView> DrOfficeInfo { get; set; }

        public ObservableCollection<StorageModel> storage { get; set; }

        public ObservableCollection<WorkTimeViewModel> workTime { get; set; }

        public Rectangles SearchedRectangle = new Rectangles();

        public GroundFloor2()
        {
            InitializeComponent();
            CreateDynamicCanvas();
            GroundFloor2Repository.GetInstance();
            InformationEditRepository.GetInstance();
            StorageRepository.GetInstance();
            RoomWorkTimeRepository.GetInstance();

        }


        public GroundFloor2(string Id)
        {
            InitializeComponent();
            CreateDynamicCanvas();
            GroundFloor2Repository.GetInstance();
            DoctorsRoomRepository.GetInstance();
            DrawSelectedRectangle(Id);
            InformationEditRepository.GetInstance();
            StorageRepository.GetInstance();
            RoomWorkTimeRepository.GetInstance();
        }

        private void DrawSelectedRectangle(string Id)
        {
            SearchedRectangle = GroundFloor2Repository.GetInstance().GetById(Id);

            Rectangle rect = new Rectangle()
            {

                Fill = Brushes.Transparent,
                Height = SearchedRectangle.Height,
                Width = SearchedRectangle.Width,
                Name = SearchedRectangle.Id,
                Stroke = Brushes.Red,
                StrokeThickness = 5

            };
            Canvas.SetLeft(rect, SearchedRectangle.Left);
            Canvas.SetTop(rect, SearchedRectangle.Top);
            canvas.Children.Add(rect);
        }

        private void CreateDynamicCanvas()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = GroundFloor2Repository.GetInstance().GetAllRectangles();
            DrOfficeInfo = DoctorsRoomRepository.GetInstance().GetAll();
            storage = StorageRepository.GetInstance().GetAllStorage();
            workTime = RoomWorkTimeRepository.GetInstance().GetAll();

            foreach (Rectangles r in Rectangle)
            {
                Rectangle rect = new Rectangle()
                {
                    Fill = r.Paint,
                    Height = r.Height,
                    Width = r.Width,
                    Name=r.Id
                };

                TextBlock txtb = new TextBlock()
                {
                    Width = r.WidthText,
                    Height = r.HeightText,
                    Text = r.Text,
                    Background = r.Background
                };
                canvas.Children.Add(txtb);
                foreach (DoctorRoomView room in DrOfficeInfo)
                {
                    if (r.Id.Equals(room.IdOfRoom))
                    {
                        rect.MouseDown += RoomInformation;
                    }
                }

                foreach (StorageModel s in storage)
                {
                    if (r.Id.Equals(s.IdS))
                    {
                        rect.MouseDown += StorageInfo;
                        break;
                    }
                }

                foreach (WorkTimeViewModel s in workTime)
                {
                    if (r.Id.Equals(s.IdOfRoom))
                    {
                        rect.MouseDown += WorkTimeInfo;
                    }
                }

                Canvas.SetLeft(txtb, r.LeftText);
                Canvas.SetTop(txtb, r.TopText);
                Canvas.SetLeft(rect, r.Left);
                Canvas.SetTop(rect, r.Top);
                canvas.Children.Add(rect);

            }

        }

        private void WorkTimeInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            WorkTimeView s = new WorkTimeView(rect.Name);
            s.Show();
        }
        private void GroundFloorClick(object sender, RoutedEventArgs e)
        {
            GroundFloor p = new GroundFloor();
            p.Show();
            this.Close();
            

        }

        private void StorageInfo(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            RoomItems s = new RoomItems("", rect.Name);
            s.Show();
        }

        private void RoomInformation(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            DoctorOfficeInformation worktime1 = new DoctorOfficeInformation(rect.Name);
            worktime1.Show();
        }
        private void FirstFloor(object sender, RoutedEventArgs e)
        {
            FirstFloor firstf = new FirstFloor();
            firstf.Show();
            this.Close();
        }

        private void Map(object sender, RoutedEventArgs e)
        {
            MainWindow map = new MainWindow(3);
            map.Show();
            this.Close();
        }

        private void GroundFloor(object sender, RoutedEventArgs e)
        {
            GroundFloor2 p = new GroundFloor2();
            p.Show();
            this.Close();

        }

        private void SecondFloor(object sender, RoutedEventArgs e)
        {
            FirstFloor secondf = new FirstFloor();
            secondf.Show();
            this.Close();
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            HospitalMap.WPF.Login.role = 0;
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }

}
