using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupplyDepot.Client.DTOService
{
    public class ItemDto
    {
        private ItemDto(int id, string name, double value, string designation, string type, int mode)
        {
            Id = id;
            Name = name;
            Value = value;
            Designation = designation;
            Type = type;
            Mode = mode;
        }

        private static ItemDto _instance;
        private static readonly object _lock = new object();

        public static ItemDto GetInstance(int id, string name, double value, string designation, string type, int mode)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ItemDto(id, name, value, designation, type, mode);
                    }
                }
            }
            return _instance;
        }
        public static ItemDto GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = null;
                    }
                }
            }
            return _instance;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
        public int Mode { get; set; }
    }
}
