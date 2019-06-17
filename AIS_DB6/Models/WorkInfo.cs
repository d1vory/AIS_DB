using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIS_DB6.Models
{
    public class WorkInfo
    {
        private DateTime _startDate;

        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = value;
        }

        private string _typeOfWork;

        public string TypeOfWork
        {
            get => _typeOfWork;
            set => _typeOfWork = value;
        }

        private double _workCost;

        public double WorkCost
        {
            get => _workCost;
            set => _workCost = value;
        }

        private int _workerId;

        public int WorkerId
        {
            get => _workerId;
            set => _workerId = value;
        }
    }
}
