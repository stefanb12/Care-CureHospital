﻿using HospitalMap.Code.Model.Canvas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;

namespace HospitalMap.Code.Repository.RectangleRepository
{
    public class GroundFloor2Repository
    {
        private const String _path = @"./../../../Code/Resources/Data/GroundFloor2.txt";

        private static GroundFloor2Repository _instance = null;

        public static GroundFloor2Repository GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GroundFloor2Repository();
            }
            return _instance;
        }

        public ObservableCollection<Rectangles> Rectangle
        {
            get;
            set;

        }

        public GroundFloor2Repository()
        {
            Rectangle = new ObservableCollection<Rectangles>();
            Rectangle = GetAllRectangles();
            SaveAllRectangles(Rectangle);

        }

        public ObservableCollection<Rectangles> GetAllRectangles()
        {
            String text = "";

            if (File.Exists(_path))
                text = File.ReadAllText(_path);

            return JsonConvert.DeserializeObject<ObservableCollection<Rectangles>>(text);

        }


        public void SaveAllRectangles(ObservableCollection<Rectangles> rectangles)
        {
            string json = JsonConvert.SerializeObject(rectangles, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(_path, json);
        }

        public Rectangles GetById(String id)
        {
            foreach (Rectangles rect in Rectangle)
            {
                if (rect.Id.Equals(id))
                {
                    return rect;
                }
            }
            return null;

        }

    }
}
