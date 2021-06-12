using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SupplyDepot.Shared;

namespace SupplyDepot.Client.DTOService
{
    public class DetailsDto
    {
        private DetailsDto()
        {

        }

        private static DetailsDto _instance;
        private static readonly object _lock = new object();
    
        public static DetailsDto GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DetailsDto();
                    }
                }
            }
            return _instance;
        }
        public void Adapter(Item item)
        {
            _ItemAdoptee = item;
        }
        public void Adapter(SupplyDepot.Shared.Type type)
        {
            _TypeAdoptee = type;
        }
        public string GetDetails()
        {
            if (_ItemAdoptee == null)
                return _TypeAdoptee.GetDetails();
            else
                return _ItemAdoptee.GetDetails();
        }
        public void ReleaseAdapter()
        {
            if (_ItemAdoptee != null)
                _ItemAdoptee = null;
            if (_TypeAdoptee != null)
                _TypeAdoptee = null;
        }
        static Item _ItemAdoptee;
        static SupplyDepot.Shared.Type _TypeAdoptee;
    }
}
